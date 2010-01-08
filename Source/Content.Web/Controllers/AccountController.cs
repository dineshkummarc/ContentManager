using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
using DotNetOpenAuth.Messaging;
using DotNetOpenAuth.OpenId;
using DotNetOpenAuth.OpenId.RelyingParty;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
using ContentNamespace.Web.Code.Service.FormsAuthenticationServices;
using ContentNamespace.Web.Code.Service.MembershipServices;
using ContentNamespace.Web.Code.Service.UserProfileServices;
using ContentNamespace.Web.Code.Entities;
using System.Security.Permissions; 

namespace ContentNamespace.Web.Controllers
{

    [HandleError]
    public class AccountController : Controller
    {
        private readonly IUserProfileService _userService;
        private readonly MembershipProvider _membershipProvider;
          

        // This constructor is used by the MVC framework to instantiate the controller using
        // the default forms authentication and membership providers.

        public AccountController(IUserProfileService userService, MembershipProvider membershipProvider) 
        {
            this._userService = userService;
            this._membershipProvider = membershipProvider;
            FormsAuth =   new FormsAuthenticationService();
        }

        // This constructor is not used by the MVC framework but is instead provided for ease
        // of unit testing this type. See the comments at the end of this file for more
        // information.
        //public AccountController(IFormsAuthenticationService formsAuth, IMembershipService service)
        //{
        //    FormsAuth = formsAuth ?? new FormsAuthenticationService();
        //    MembershipService = service ?? new AccountMembershipService();
        //}

        public IFormsAuthenticationService FormsAuth
        {
            get;
            private set;
        }


        public ActionResult Index()
        {
            return View();
        }


        public ActionResult OpenIdLogin()
        {
            string returnUrl = VirtualPathUtility.ToAbsolute("~/");
            var openid = new OpenIdRelyingParty();
            var response = openid.GetResponse();
            if (response == null)
            {
                // Stage 2: user submitting Identifier
                Identifier id;
                if (Identifier.TryParse(Request["openid_identifier"], out id))
                {
                    try
                    {
                        IAuthenticationRequest req = openid.CreateRequest(Request["openid_identifier"]);

                        var fetch = new FetchRequest();
                        //ask for more info - the email address 
                        fetch.Attributes.Add(new AttributeRequest(WellKnownAttributes.Contact.Email, true));
                        fetch.Attributes.Add(new AttributeRequest(WellKnownAttributes.Name.FullName,true));
                        fetch.Attributes.Add(new AttributeRequest(WellKnownAttributes.Name.First,true));
                        fetch.Attributes.Add(new AttributeRequest(WellKnownAttributes.Name.Last, true));
                        fetch.Attributes.Add(new AttributeRequest(WellKnownAttributes.BirthDate.WholeBirthDate, true));
                        fetch.Attributes.Add(new AttributeRequest(WellKnownAttributes.Contact.HomeAddress.City, true));
                        fetch.Attributes.Add(new AttributeRequest(WellKnownAttributes.Contact.HomeAddress.State, true));
                        req.AddExtension(fetch);

                        return req.RedirectingResponse.AsActionResult();
                    }
                    catch (ProtocolException ex)
                    {
                        ViewData["Message"] = ex.Message;
                        return View("Logon");
                    }
                }
                else
                {
                    ViewData["Message"] = "Invalid identifier";
                    return View("Logon");
                }
            }
            else
            {
                // Stage 3: OpenID Provider sending assertion response
                switch (response.Status)
                {
                    case AuthenticationStatus.Authenticated:
                        var fetch = response.GetExtension<FetchResponse>(); 
                        string openIdId = response.ClaimedIdentifier;

                        //string email = (fetch != null 
                        //        && fetch.Attributes.Any(x => x.TypeUri == WellKnownAttributes.Contact.Email))
                        //    ? fetch.Attributes[WellKnownAttributes.Contact.Email].Values[0] : "";

                        string name = UserLoggedIn(this._userService, openIdId , fetch);
                        
                        FormsAuthentication.SetAuthCookie(name, false);

                        if (!string.IsNullOrEmpty(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    case AuthenticationStatus.Canceled:
                        ViewData["Message"] = "Canceled at provider";
                        return View("Logon");
                    case AuthenticationStatus.Failed:
                        ViewData["Message"] = response.Exception.Message;
                        return View("Logon");
                }
            }
            return new EmptyResult();

        }

        //TODO: this should be moved to some other type of business logic
        public string UserLoggedIn(IUserProfileService _userService1, string openIdId , FetchResponse fetch)
        { 
            UserProfile user = _userService1.Get().Where(x => x.OpenIdId == openIdId ).SingleOrDefault();
            if (user == null)
            {
                user = new UserProfile();
                user.OpenIdId = openIdId;
            }
            if (fetch != null)
            {
                user.Name = (fetch.Attributes.Any(x => x.TypeUri == WellKnownAttributes.Name.FullName))
                    ? fetch.Attributes[WellKnownAttributes.Name.FullName].Values[0] :
                    ((fetch.Attributes.Any(x => x.TypeUri == WellKnownAttributes.Name.First))
                    ? fetch.Attributes[WellKnownAttributes.Name.First].Values[0] : ""
                    + " " + ((fetch.Attributes.Any(x => x.TypeUri == WellKnownAttributes.Name.Last))
                    ? fetch.Attributes[WellKnownAttributes.Name.Last].Values[0] : ""));
                user.Email = (fetch.Attributes.Any(x => x.TypeUri == WellKnownAttributes.Contact.Email))
                    ? fetch.Attributes[WellKnownAttributes.Contact.Email].Values[0] : "";
                //username should not include the email - it's creepy. Just use the name of the email
                user.UserName = user.Email.Substring(0, user.Email.IndexOf('@'));
            }
            else
            {
                /*
                http://username.myopenid.com/  	  	  	 
                http://openid.aol.com/username 
                */
                string http = "http://";
                if (openIdId.Contains("myopenid"))
                {
                    user.Name = openIdId.Substring(openIdId.IndexOf(http) + http.Length,
                        openIdId.IndexOf('.') - http.Length);
                }
                else if (openIdId.Contains("http://openid.aol.com/"))
                {
                    user.Name = openIdId.Substring(openIdId.LastIndexOf("/"));
                }
                user.UserName = user.Name;
            }

            user.LastSignInDate = DateTime.Now;  // Important
            _userService1.Save(user);

            return user.UserName;
        }

        public ActionResult LogOn()
        { 
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings",
            Justification = "Needs to take same parameter type as Controller.Redirect()")]
        public ActionResult LogOn(string userName, string password, bool rememberMe, string returnUrl)
        {

            if (!ValidateLogOn(userName, password))
            {
                return View();
            }

            FormsAuth.SignIn(userName, rememberMe);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult LogOff()
        { 
            FormsAuth.SignOut(); 
            return RedirectToAction("Index", "Home");
        }


        //[PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        [Authorize(Roles = "Admin")]
        public ActionResult AdminOnly()
        {
            return View();
        }


         

        public ActionResult ChangePasswordSuccess()
        { 
            return View();
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity is WindowsIdentity)
            {
                throw new InvalidOperationException("Windows authentication is not supported.");
            }
        }

        #region Validation Methods
         
        private bool ValidateLogOn(string userName, string password)
        {
            if (String.IsNullOrEmpty(userName))
            {
                ModelState.AddModelError("username", "You must specify a username.");
            }
            if (String.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("password", "You must specify a password.");
            }
            if (!this._membershipProvider.ValidateUser(userName, password))
            {
                ModelState.AddModelError("_FORM", "The username or password provided is incorrect.");
            }

            return ModelState.IsValid;
        }

        private bool ValidateRegistration(string userName, string email, string password, string confirmPassword)
        {
            if (String.IsNullOrEmpty(userName))
            {
                ModelState.AddModelError("username", "You must specify a username.");
            }
            if (String.IsNullOrEmpty(email))
            {
                ModelState.AddModelError("email", "You must specify an email address.");
            }
            if (password == null || password.Length < this._membershipProvider.MinRequiredPasswordLength)
            {
                ModelState.AddModelError("password",
                    String.Format(CultureInfo.CurrentCulture,
                         "You must specify a password of {0} or more characters.",
                         this._membershipProvider.MinRequiredPasswordLength));
            }
            if (!String.Equals(password, confirmPassword, StringComparison.Ordinal))
            {
                ModelState.AddModelError("_FORM", "The new password and confirmation password do not match.");
            }
            return ModelState.IsValid;
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://msdn.microsoft.com/en-us/library/system.web.security.membershipcreatestatus.aspx for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "Username already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A username for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion
    }

}
