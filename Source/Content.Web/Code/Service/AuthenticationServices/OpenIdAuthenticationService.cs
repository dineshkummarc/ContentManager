using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using ContentNamespace.Web.Code.Entities; 
using DotNetOpenId;
using DotNetOpenId.Extensions.AttributeExchange;
using DotNetOpenId.RelyingParty;

namespace ContentNamespace.Web.Code.Service.AuthenticationServices
{
    public class OpenIDAuthenticationService : IAuthenticationService
    {

        //ref: http://wekeroad.com/webcasts/MVCStorefront_Part16.wmv
        //http://blog.wekeroad.com/2008/07/03/mvcstore-part-16

        public bool IsValidLogin(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public bool IsValidLogin(Uri serviceUri)
        {
            bool result = false;
            var openid = new OpenIdRelyingParty();
            if (openid.Response == null)
            {
                // Stage 2: user submitting Identifier
                openid.CreateRequest(serviceUri.AbsoluteUri).RedirectToProvider();
            }
            else
            {
                result = openid.Response.Status == AuthenticationStatus.Authenticated;

                if (result)
                {
                    //synch the users

                }


            }
            return result;
        }


        public object RegisterUser(string userName, string password, string confirmPassword, string email, string reminderQuestion, string reminderAnswer)
        {
            throw new NotImplementedException();
        }


        bool IAuthenticationService.IsValidLogin(string logonToken)
        {
            throw new NotImplementedException();
        }
         
        string GetFetchValue(FetchResponse fetch, string key)
        {

            string schema = "http://schema.openid.net/";
            IList<string> results = fetch.GetAttribute(schema + key).Values;
            string result = results.Count > 0 ? results[0] : "";
            return result;
        }
    }
}
