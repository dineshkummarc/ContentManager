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
    public class HtmlContentController : Controller
    {

        private readonly IContentService _service;

        public HtmlContentController(IContentService serv)
        {
            this._service = serv;
        }

        // GET: /HtmlContent/
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
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                HtmlContent c = new HtmlContent();
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < collection.Keys.Count; i++)
                {
                    sb.Append(", " + collection.Keys[i] + "=" + collection[collection.Keys[i]]);
                }
                c.ContentData = collection["ContentData"];
                c.ModifiedBy = collection["ModifiedBy"];
                c.ActiveDate = DateTime.Now ; //collection["ActiveDate"];
                c.ExpireDate = DateTime.MaxValue;
                c.ModifiedDate = DateTime.Now;
                this._service.Save(c);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /HtmlContent/Edit/5

        public ActionResult Edit(int id)
        {
            return View(this._service.Get(id));
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
                c.ModifiedBy = collection["ModifiedBy"];
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
    }
}
