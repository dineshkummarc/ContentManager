using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContentNamespace.Web.Code.Entities;
using ContentNamespace.Web.Code.Util;

namespace ContentNamespace.Web.Code.Service.PersonalizationServices
{

    public class PersonalizationService : IPersonalizationService
    {  
        public PersonalizationService(  )
        {  
        }

        /// <summary>
        /// Loads the user profile
        /// </summary>
        public UserProfile GetProfile(string userName)
        { 
            UserProfile profile = new UserProfile(userName);

            Address a = new Address();
            a.City = "wego";
            a.Country = "USA";
            a.Email = "joe@dfsa.com";
            a.FirstName = "John";
            a.LastName = "James";
            a.Zip = "65556";
            a.UserName = userName;
            profile.AddressBook.Add(a);
            profile.UserName = userName; 

            return profile;
        }
 
         
         
          
    }
}
