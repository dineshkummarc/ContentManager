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
        public LazyList<UserProfile> Users { get; set; } 

        public String UsersString
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (UserProfile up in this.Users)
                {
                    sb.Append(up.Name + ", ");
                }
                return sb.ToString();
            }
        }  
    }
}

