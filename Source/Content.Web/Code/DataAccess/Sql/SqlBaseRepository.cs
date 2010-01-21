using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

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
                    _ConnStr = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
                }
                return  _ConnStr;
            }
        }
    }
}
