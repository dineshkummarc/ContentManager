using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using ContentNamespace.Web.Code.Service.Interfaces;
using ContentNamespace.Web.Code.Entities;
using System.Text;

namespace ContentNamespace.Web.Controllers
{
    public class TestController : Controller
    {
        
        private readonly IContentService _service;

        public TestController(IContentService serv)
        {
            this._service = serv;
        }
         
        // GET: /Test/
        public ActionResult Index()
        {
            return View(this._service.Get()); 
        }
  
        //
        // GET: /Test/Details/5 
        public ActionResult Details(int id)
        {
            return View(this._service.Get(id));
        }

        //
        // GET: /Test/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Test/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                HtmlContent c = new HtmlContent();
                StringBuilder sb = new StringBuilder();
                for(int i =0; i<collection.Keys.Count ; i++)
                {
                    sb.Append(", " + collection.Keys[i] + "=" + collection[collection.Keys[i]]);
                }
                c.ActiveDate = DateTime.Now;
                c.ContentData = "<b>dsafafsd</b>";
                c.ExpireDate = DateTime.MaxValue;
                c.ModifiedBy = "me";
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
        // GET: /Test/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View(this._service.Get(id));
        }

        //
        // POST: /Test/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                HtmlContent c = this._service.Get(id);
                c.ModifiedDate = DateTime.Now;
                c.ModifiedBy = "new updater";
                this._service.Save(c);
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
