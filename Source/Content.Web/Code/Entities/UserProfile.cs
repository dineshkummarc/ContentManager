using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContentNamespace.Web.Code.Util;

namespace ContentNamespace.Web.Code.Entities
{

    public class UserProfile
    {
        public string UserName { get; set; }
        public LazyList<Address> AddressBook { get; set; }
        public LazyList<Enum.UserRoles> UserRoles { get; set; }

        public Address DefaultAddress
        {
            get
            {
                return AddressBook.Where(x => x.IsDefault)
                    .SingleOrDefault();
            }
        }

        public string FullName
        {
            get
            {
                string result = UserName;
                if (DefaultAddress != null)
                {
                    result = DefaultAddress.FullName;
                }
                return result;
            }
        }

        public UserProfile(string userName)
        { 
            AddressBook = new LazyList<Address>();
            this.UserName = userName;
        }
    }
}
