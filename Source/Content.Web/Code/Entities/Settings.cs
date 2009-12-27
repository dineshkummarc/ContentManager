using System;

namespace ContentNamespace.Web.Code.Entities
{
    /// <summary>
    /// Global application settings governing general display and behavior for all users. This class will typically be serialized 
    /// for storage and deserialized & cached once per application load.
    /// </summary>
    [Serializable]
    public class Settings
    {
        // System
        public int SettingsCacheTimeInMinutes { get; set; }         // How long settings data remains in cache before being refreshed
        
        // Rendering
        public int GridPageSize { get; set; }                       // Show this many records in grids before paging; default: 10
        public bool ShowContentEllipsis { get; set; }               // If content data is longer than <ContentExtractLength> characters, show an ellipsis (...); default: true
        public int ContentExtractLength { get; set; }               // How long content can be before the ellipsis logic kicks in; default: 10-15 characters
        
        // Workflow
        public bool AllowRejectedContentReActivation { get; set; }  // Can rejected content be re-activated (by admin)?; default: false
        public bool AllowExpiredContentReActivation { get; set; }   // Can expired content be re-activated (by admin)?; default: true   
    }
}
