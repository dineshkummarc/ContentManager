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

namespace ContentNamespace.Web.Code.Entities
{
    /// <summary>
    /// Global application settings governing general display and behavior for all users. This class will typically be serialized 
    /// for storage and deserialized & cached once per application load.
    /// </summary>
    [Serializable]
    public class Settings
    {
        public int GridPageSize;                        // Show this many records in grids before paging; default: 10
        public bool ShowContentEllipsis;                // If content data is longer than <ContentExtractLength> characters, show an ellipsis (...); default: true
        public int ContentExtractLength;                // How long content can be before the extract ellipsis logic kicks in; default: 10-15 characters
        public bool AllowRejectedContentReActivation;   // Can rejected content be re-activated (by admin)?; default: false
        public bool AllowExpiredContentReActivation;    // Can expired content be re-activated (by admin)?; default: true
    }
}
