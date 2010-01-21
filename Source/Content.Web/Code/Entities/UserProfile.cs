using System;
//
using ContentNamespace.Web.Code.Entities.Base;
using ContentNamespace.Web.Code.Util;
using System.Text;

namespace ContentNamespace.Web.Code.Entities
{
    public class UserProfile :  ContentManagerBaseItem
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string OpenIdId { get; set; }
        public DateTime LastSignInDate { get; set; }
        public DateTime RegisterDate { get; set; }

        public LazyList<Enums.UserRoles> UserRoles { get; set; }
        public String UserRolesString 
        { 
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (Enums.UserRoles ur in this.UserRoles)
                {
                    sb.Append(ur.ToString()+ ", ");
                } 
                return sb.ToString();
            }
        } 
        public LazyList<Application> Applications { get; set; }
        public String ApplicationsString
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (Application a in this.Applications)
                {
                    sb.Append(a.Name + ", ");
                }
                return sb.ToString();
            }
        }  


        public UserProfile()
        {
            Id = -2;
            UserRoles = new LazyList<Enums.UserRoles>();
            Applications = new LazyList<Application>();
        }
    }
}

        /* 
public Address GetOpenIDAddress(Uri claimUri)
{
    var openid = new OpenIdRelyingParty();
    Address result = new Address();
    if (openid.Response != null)
    {
        // Stage 2: user submitting Identifier
        var fetch = openid.Response.GetExtension<FetchResponse>();
        if (fetch != null)
        {
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
        }
    }
    else
    {
        var request = openid.CreateRequest(claimUri.AbsoluteUri);
        var fetch = new FetchRequest();
        fetch.AddAttribute(new AttributeRequest("contact/email"));
        fetch.AddAttribute(new AttributeRequest("namePerson/first"));
        fetch.AddAttribute(new AttributeRequest("namePerson/last"));
        fetch.AddAttribute(new AttributeRequest("contact/streetaddressLine1/home"));
        fetch.AddAttribute(new AttributeRequest("contact/streetaddressLine2/home"));
        fetch.AddAttribute(new AttributeRequest("contact/city/home"));
        fetch.AddAttribute(new AttributeRequest("contact/city/stateorprovince"));
        fetch.AddAttribute(new AttributeRequest("contact/country/home"));
        fetch.AddAttribute(new AttributeRequest("contact/postalCode/home"));
        request.AddExtension(fetch);
        request.RedirectToProvider();
    }
    return result;
} 
         */
