using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContentNamespace.Web.Code.Entities.Base;
using ContentNamespace.Web.Code.Entities;

namespace ContentNamespace.Web.Code.Entities
{
    public class UserProfile :  ContentManagerBaseItem
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        //public List<UserRoles> Roles { get; set; } 
        public DateTime LastSignInDate { get; set; }
        public DateTime RegisterDate { get; set; }

        /*
           result.Email = GetFetchValue(fetch, "contact/email");
           result.FirstName = GetFetchValue(fetch, "namePerson/first");
           result.LastName = GetFetchValue(fetch, "namePerson/last");
           result.Street1 = GetFetchValue(fetch, "contact/streetaddressLine1/home");
           result.Street2 = GetFetchValue(fetch, "contact/streetaddressLine2/home");
           result.City = GetFetchValue(fetch, "contact/city/home");
           result.StateOrProvince = GetFetchValue(fetch, "contact/city/stateorprovince");
           result.Country = GetFetchValue(fetch, "contact/country/home");
           result.Zip = GetFetchValue(fetch, "contact/postalCode/home");
           result.UserName = openid.Response.ClaimedIdentifier;
         */
        public UserProfile()
        {
            Id = -2;
        }

    }
}
