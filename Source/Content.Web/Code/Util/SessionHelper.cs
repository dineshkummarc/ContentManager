using System.Web;
//
using ContentNamespace.Web.Code.Entities;

namespace ContentNamespace.Web.Code.Util
{
    public class SessionHelper
    {
        #region Constants...

        private const string SettingsSessionVariable = "ContentManagerSettings";

        #endregion

        #region Properties...

        public static Setting ContentManagerSettings
        {
            get { return HttpContext.Current.Session[SettingsSessionVariable] as Setting; }
            set { HttpContext.Current.Session[SettingsSessionVariable] = value; }
        }

        #endregion
    }
}
