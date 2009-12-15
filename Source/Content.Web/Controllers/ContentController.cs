using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Content.Web.Code.Service.Interfaces;
using Content.Web.Code.Entities;

namespace Content.Web.Controllers
{
    public class ContentController : Controller
    {
        IContentService _service ;

        public ContentController(IContentService serv)
        {
            this._service = serv;
        }


        //
        // GET: /Content/

        public ActionResult Index()
        {
            return View(this._service.Get());

 
            //int pageNumber = 1;
            //string sPage = Request.Form["pg"];
            //string sortBy = Request.QueryString["s"];
            //string sortDir = Request.QueryString["dir"] ?? "";
            //string query = Request.Form["q"];


            ////handle the search
            //if (!string.IsNullOrEmpty(query))
            //{
            //    var item = this._service.Get().First();  
            //    return RedirectToAction("Edit", new { id = item.Id });
            //}
            //else
            //{ 
            //    if (sortDir.Equals("desc") && !String.IsNullOrEmpty(sortBy))
            //        sortBy += " desc";

            //    if (!String.IsNullOrEmpty(sPage))
            //        int.TryParse(sPage, out pageNumber);

            //    IQueryable<HtmlContent> items = this._service.Get().Skip(0).Take(10);
            //    return View(items);
            //}
        }

        //
        // GET: /Content/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Content/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Content/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Content/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Content/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
