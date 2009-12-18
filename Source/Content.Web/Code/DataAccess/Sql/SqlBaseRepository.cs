using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContentNamespace.Web.Code.DataAccess.Sql
{
    public class SqlBaseRepository
    {

        static string _ConnStr;


        protected virtual string ConnStr
        {
            get
            {
                if (_ConnStr == null)
                {
                    throw new Exception("No Connection String Set");
                }
                return _ConnStr;
            }
        }
    }
}
