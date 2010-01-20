using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContentNamespace.Web.Code.Util
{
    public class Account
    {
        public static string UserDisplayName(string userName)
        {
            string s = userName.Contains('@') ? userName.Substring(0, userName.IndexOf('@')) : userName ;
            return s;
        }
    }
}
