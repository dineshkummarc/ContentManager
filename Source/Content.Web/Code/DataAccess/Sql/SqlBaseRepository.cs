using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace ContentNamespace.Web.Code.DataAccess.Sql
{
    public class SqlBaseRepository
    { 
        static string _ConnectionString;
         
        protected virtual string ConnectionString
        {
            get
            {
                if (_ConnectionString == null)
                {
                    _ConnectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
                }
                return  _ConnectionString;
            }
        }
    }
}
