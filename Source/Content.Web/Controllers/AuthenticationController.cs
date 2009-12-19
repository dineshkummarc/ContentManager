using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Security;
using ContentNamespace.Web.Code.Service.AuthenticationServices;
using ContentNamespace.Web.Code.Entities;

namespace ContentNamespace.Web.Controllers
{
    public class AuthenticationController : Controller
    {
        IAuthenticationService _service;
        public AuthenticationController(IAuthenticationService service)
        {
            _service = service;
        }

        public ActionResult Login()
        {

            string oldUserName = this.GetUserName();

            string login = Request.Form["login"];
            string password = Request.Form["password"];

            if (!String.IsNullOrEmpty(login) && !String.IsNullOrEmpty(password))
            {
                bool isValid = this._service.IsValidLogin(login, password);

                //log them in 
                if (isValid)
                {
                    SetPersonalizationCookie(login, login);
  
                    return AuthAndRedirect(login);
                }
            }
            return View(); 
        }

        public ActionResult OpenIDLogin()
        {
            string claimedUrl = Request["openid.claimed_id"];
            string oldUserName = this.GetUserName();

            if (!String.IsNullOrEmpty(claimedUrl))
            {
                try
                {
                    Uri openIDUri = new Uri(claimedUrl);
                    var svc = new OpenIDAuthenticationService();

                    //you can just check to see if it's valid

                    //or you can use AttributeExchange...
                    Address add = svc.GetOpenIDAddress(openIDUri);

                    if (add != null)
                    {
                        SetPersonalizationCookie(claimedUrl, "");
   
                        return AuthAndRedirect(claimedUrl);
                    }
                }
                catch
                {
                    ViewData["ErrorMessage"] = "Invalid Open ID URI Entered";
                }

            }

            return View("Login");

        }

        ActionResult AuthAndRedirect(string userName)
        {

            string returnUrl = Request.Form["ReturnUrl"];
            FormsAuthentication.SetAuthCookie(userName, false);

            if (!String.IsNullOrEmpty(returnUrl))
            {

                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Checkout", "Order");
            }
        }

        void SetPersonalizationCookie(string userName, string friendlyName)
        {
            Response.Cookies["shopper"].Value = userName;
            Response.Cookies["shopperName"].Value = friendlyName;
            Response.Cookies["shopper"].Expires = DateTime.Now.AddDays(30);
            Response.Cookies["shopperName"].Expires = DateTime.Now.AddDays(30);
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Catalog");

        }
    }
}
