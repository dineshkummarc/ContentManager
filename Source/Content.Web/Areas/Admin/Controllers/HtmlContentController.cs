using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using ContentNamespace.Web.Code.Service.Interfaces;
using ContentNamespace.Web.Code.Entities;
using System.Text;
using System.Web.Routing;
using ContentNamespace.Web.Code.Service.ApplicationServices;
using ContentNamespace.Web.Code.Service.ConfigurationServices;
using ContentNamespace.Web.Code.DataAccess.Interfaces; 

namespace ContentNamespace.Web.Controllers
{
    public class HtmlContentController : Controller
    {
        private readonly IContentService _contentService;
        private readonly IApplicationService _applicationService;
        private ISettingService _settingService;

        // GET: /HtmlContent/
        public HtmlContentController(IContentService service,
            IApplicationService applicationService, 
            ISettingService settingService)
        {
            this._contentService = service;
            this._applicationService = applicationService;
            this._settingService = settingService;
        }

        public ActionResult Index(int? targetPage)
        {
            // TODO: This is a little strange, since the default "grid page size" is already available
            // in the ContentService, but if we leave off the parameter, then we can't easily distinguish
            // the Get() methods
            if (targetPage == null) { targetPage = 0; }

            int totalCount = 0;

            var settings = (_settingService.GetData() as Settings);
            var resultList = this._contentService.Get((int)targetPage, 0, out totalCount).ToList();
            var maximumPage = totalCount / settings.GridPageSize;
            var currentPageViewModel = new HtmlContentIndexViewModel(resultList, (int)targetPage, maximumPage);

            return View(currentPageViewModel);
        }

        //
        // GET: /HtmlContent/Details/5 
        public ActionResult Details(int id)
        {
            return View(this._contentService.Get(id));
        }

        //
        // GET: /HtmlContent/Create

        public ActionResult Create()
        {
            HtmlContent item = new HtmlContent();
            return View(new HtmlContentViewModel(item, this._applicationService));
        }

        //
        // POST: /HtmlContent/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([Bind(Exclude = "Id")] HtmlContent c)
        {  
            c.ModifiedBy = "XXXX";//TODO: should be loged in user
            c.ModifiedDate = DateTime.Now;
            c.ExpireDate = DateTime.MaxValue;
            c.ActiveDate = new DateTime(1900, 1, 1); 
            c.ContentData = "Hello <b>World</b>";
            c.CreatedBy = "XXXX";//TODO: should be loged in user
            c.CreatedDate = DateTime.Now;
            if (!this.Validate(c))
            {
                return View();
            }
            this._contentService.Save(c);
            return RedirectToAction("Edit/" + c.Id);
        }

        //
        // GET: /HtmlContent/Edit/5 
        public ActionResult Edit(int id)
        {
            var editContent = this._contentService.Get(id);

            editContent.Edit();

            return View(editContent);
        }

        //ref: http://tinyurl.com/d6xolp      
        // POST: /HtmlContent/Edit/5 
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Edit(int id, [Bind(Exclude = "Id")] HtmlContent c)
        {
            try
            {
                c.Id = id;

                this._contentService.Save(c);

                return RedirectToAction("Details", new { id = id });
                // return RedirectToAction("Details", new RouteValueDictionary(new { id = id }));
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /HtmlContent/EditExtra/5 
        public ActionResult EditExtra(int id)
        {
            var editContent = this._contentService.Get(id);

            editContent.Edit();

            return View(editContent);
        }

        //ref: http://tinyurl.com/d6xolp      
        // POST: /HtmlContent/EditExtra/5 
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditExtra(int id, [Bind(Exclude = "Id,ContentData")] HtmlContent c)
        {
            try
            {
                c.Id = id;
                c.ContentData = this._contentService.Get(id).ContentData;
                this._contentService.Save(c);

                return RedirectToAction("Details", new { id = id });
                // return RedirectToAction("Details", new RouteValueDictionary(new { id = id }));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Submit(int id)
        {
            var editContent = this._contentService.Get(id);

            editContent.Submit(); // Change workflow state

            _contentService.Save(editContent);

            return RedirectToAction("../HtmlContent/Details", new { id });
        }

        public ActionResult Content(string id)
        {
            var c = this._contentService.Get(Convert.ToInt32(id));
            return PartialView("Content", c);
        }


        public ActionResult ContentPage(int id)
        {
            var x = this._contentService.Get(id); 
            return View(x);
        }
        

        // GET: /AjaxTest/
        public ActionResult TestContents()
        { 
            return View();
        }
         


        protected bool Validate(HtmlContent item)
        {
            if (item.Name.Trim().Length == 0)
                ModelState.AddModelError("Name", "Name name is required.");
            //if (contactToCreate.LastName.Trim().Length == 0)
            //    ModelState.AddModelError("LastName", "Last name is required.");
            //if (contactToCreate.Phone.Length > 0 && !Regex.IsMatch(contactToCreate.Phone, @"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"))
            //    ModelState.AddModelError("Phone", "Invalid phone number.");
            //if (contactToCreate.Email.Length > 0 && !Regex.IsMatch(contactToCreate.Email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
            //    ModelState.AddModelError("Email", "Invalid email address."); 
            return ModelState.IsValid;
        }

    }

    public class HtmlContentViewModel
    {
        // Properties
        public HtmlContent HtmlContent { get; private set; }
        public SelectList Applications { get; private set; }

        // Constructor
        public HtmlContentViewModel(HtmlContent htmlContent, IApplicationService appService)
        {
            this.HtmlContent = htmlContent;
            this.Applications = new SelectList(
                appService.Get().Select(x => x.Name).AsEnumerable(),
                1 /*this.HtmlContent.ApplicationId*/
            );
        }
    }

    public class HtmlContentIndexViewModel
    {
        // Properties
        public List<HtmlContent> HtmlContentList { get; set; }
        public int CurrentPage { get; set; }
        public int MaximumPage { get; set; }

        // Constructor
        public HtmlContentIndexViewModel(List<HtmlContent> htmlContent, int currentPage, int maximumPage)
        {
            this.HtmlContentList = htmlContent;
            this.CurrentPage = currentPage;
            this.MaximumPage = maximumPage;
        }
    }
}
