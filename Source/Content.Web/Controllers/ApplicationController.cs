using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using ContentNamespace.Web.Code.Service.ApplicationServices;
using ContentNamespace.Web.Code.Entities;

namespace ContentNamespace.Web.Controllers
{
    public class ApplicationController : Controller
    {

        private readonly IApplicationService _applicationService; 


        // GET: /UserProfile/
        public ApplicationController(IApplicationService  applicationService  )
        {
            this._applicationService =  applicationService; 
        }


        //
        // GET: /Application/

        public ActionResult Index()
        {
            return View(this._applicationService.Get()) ;
        }

        //
        // GET: /Application/Details/5

        public ActionResult Details(int id)
        {
            var item = this._applicationService.Get(id);
            return View(item);
        }

        //
        // GET: /Application/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Application/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([Bind(Exclude = "Id")] Application item)
        {
            try
            { 
                this._applicationService.Save(item);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Application/Edit/5
 
        public ActionResult Edit(int id)
        {
            var item = this._applicationService.Get(id);
            return View(item);
        }

        //
        // POST: /Application/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, [Bind(Exclude = "Id")] Application item)
        {
            try
            {
                item.Id = id;
                this._applicationService.Save(item);
                return RedirectToAction("Details", new { id = id });
            }
            catch
            {
                return View();
            }
        }
    }
}
