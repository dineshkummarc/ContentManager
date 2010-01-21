using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using ContentNamespace.Web.Code.Entities.Base;
using ContentNamespace.Web.Code.Util;



namespace ContentNamespace.Web.Code.Entities
{
    public class Application : ContentManagerBaseItem
    {
        public string Name { get; set; }
        public LazyList<UserProfile> UserProfiles { get; set; }

        public String UserProfilesString
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (UserProfile up in this.UserProfiles)
                {
                    sb.Append(up.Name + ", ");
                }
                return sb.ToString();
            }
        }

        public Application()
        {
            Id = -2;
            UserProfiles = new LazyList<UserProfile>(); 
        }

    }
}

