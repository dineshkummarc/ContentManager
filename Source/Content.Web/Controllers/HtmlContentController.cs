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

namespace ContentNamespace.Web.Controllers
{
    public class HtmlContentController : ContentManagerBaseController
    {
        private readonly IContentService _service;

        // GET: /HtmlContent/
        public HtmlContentController(IContentService service)
        {
            this._service = service;
        }

        public ActionResult Index()
        {
            return View(this._service.Get());
        }

        //
        // GET: /HtmlContent/Details/5 
        public ActionResult Details(int id)
        {
            return View(this._service.Get(id));
        }

        //
        // GET: /HtmlContent/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /HtmlContent/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection) // ([Bind(Exclude = "Id")] HtmlContent item)
        {
            //this.ValidateItem(item);
            //if (!ModelState.IsValid)
            //    return View();

            HtmlContent c = new HtmlContent();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < collection.Keys.Count; i++)
            {
                sb.Append(", " + collection.Keys[i] + "=" + collection[collection.Keys[i]]);
            }
            c.ModifiedBy = "XXXX";//TODO: should be loged in user
            c.ModifiedDate = DateTime.Now;
            c.ExpireDate = DateTime.MaxValue;
            c.ActiveDate = new DateTime(1900, 1, 1);
            c.Name = collection["Name"];
            c.ContentData = "Hello <b>World</b>"; 
            this._service.Save(c);

            return RedirectToAction("Edit/" + c.Id);
        }

        //
        // GET: /HtmlContent/Edit/5

        public ActionResult Edit(int id)
        {
            var editContent = this._service.Get(id);

            editContent.Edit();

            return View(editContent);
        }

        //ref: http://tinyurl.com/d6xolp      
        // POST: /HtmlContent/Edit/5 
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                HtmlContent c = this._service.Get(id);
                c.ContentData = collection["ContentData"]; 
                c.ModifiedBy = "XXXX";//TODO: should be loged in user
                c.ModifiedDate = DateTime.Now;
                c.ExpireDate = DateTime.MaxValue;
                c.ActiveDate = new DateTime(1900, 1, 1);  
                this._service.Save(c);

                //return RedirectToAction("Index");
                return RedirectToAction("Details", new { id = id });
                // return RedirectToAction("Details", new RouteValueDictionary(new { id = id }));
            }
            catch
            {
                return View();
            }
        }


        protected void ValidateItem(HtmlContent item)
        {
            if (item.Name.Trim().Length == 0)
                ModelState.AddModelError("Name", "Name name is required."); 
        }

    }
}
