using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace ContentNamespace.Web.Code.DataAccess.VistaDb
{
    public class VistaDb : IDisposable
    {
        #region Members...

        //protected ContentManagerEntities _context;

        #endregion

        #region Constructors...

        public VistaDb() { }

        //protected VistaDb(ContentManagerEntities dataContext)
        //{
        //    _context = dataContext;
        //} 

        #endregion

        #region Initialization...
        /*
        protected static VistaDb CreateRepository()
        {
            return new VistaDb(new ContentManagerEntities());
        }
        */
        #endregion

        #region IDisposable Members...
        /*
        public void Dispose()
        {
            if (_context != null) { _context.Dispose(); }
        }
        */
        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
