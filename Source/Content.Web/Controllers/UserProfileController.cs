using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using ContentNamespace.Web.Code.Service.UserProfileServices;
using ContentNamespace.Web.Code.Entities;
using System.Text;

namespace ContentNamespace.Web.Controllers
{
    public class UserProfileController : Controller
    {

        private readonly IUserProfileService _service;

        public UserProfileController(IUserProfileService serv)
        {
            this._service = serv;
        }

        // GET: /UserProfile/
        public ActionResult Index()
        {
            return View(this._service.Get());
        }


        //
        // GET: /UserProfile/Details/5 
        public ActionResult Details(int id)
        {
            return View(this._service.Get(id));
        }

        //
        // GET: /UserProfile/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /UserProfile/Create

        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                UserProfile c = new UserProfile();
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < collection.Keys.Count; i++)
                {
                    sb.Append(", " + collection.Keys[i] + "=" + collection[collection.Keys[i]]);
                }
                //c.ContentData = collection["ContentData"];
                c.ModifiedBy = collection["ModifiedBy"];
                c.Name = collection["Name"];
                //c.ActiveDate = DateTime.Now; //collection["ActiveDate"];
                //c.ExpireDate = DateTime.MaxValue;
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
        // GET: /UserProfile/Edit/5

        public ActionResult Edit(int id)
        {
            return View(this._service.Get(id));
        }

        //ref: http://tinyurl.com/d6xolp      
        // POST: /UserProfile/Edit/5 
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                UserProfile c = this._service.Get(id);
                //c.ContentData = collection["ContentData"];
                //c.ModifiedBy = collection["ModifiedBy"];
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
