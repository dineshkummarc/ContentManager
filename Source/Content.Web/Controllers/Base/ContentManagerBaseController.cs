using System.Web.Mvc;
//
using ContentNamespace.Web.Code.Entities;
using ContentNamespace.Web.Code.Service;
using ContentNamespace.Web.Code.Util;

namespace ContentNamespace.Web.Controllers
{
    public abstract class ContentManagerBaseController<TService> : Controller 
        where TService : IContentManagerBaseService
    {
        #region Fields...

        protected TService _service;

        #endregion

        #region Constructors...

        protected ContentManagerBaseController(TService service)
        {
            _service = service;
        }

        #endregion

        #region Methods...

        protected void GetContentManagerSettings()
        {
            if (Equals(SessionHelper.ContentManagerSettings, null))
            {
                SessionHelper.ContentManagerSettings = _service.GetData() as Settings;
            }
        }

        #endregion
    }
}
