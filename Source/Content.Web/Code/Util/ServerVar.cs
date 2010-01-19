using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContentNamespace.Web.Code.Util
{
    public static class ServerVar
    {

        public static string BaseUrl
        {
            get
            {
                var req = HttpContext.Current.Request;
                var s = "";// string.Format("{0}://{1}{2}", req.Url.Scheme, req.Url.Authority, urlHelper.Content("~"));
                return s;
            }
        }
    }
}
