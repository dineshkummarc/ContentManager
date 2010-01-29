using System;
using ContentNamespace.Web.Code.Entities.Base;

namespace ContentNamespace.Web.Code.Entities
{
    /// <summary>
    /// Global application settings governing general display and behavior for all users. This class will typically be serialized 
    /// for storage and deserialized & cached once per application load.
    /// </summary>
    [Serializable]
    public class Setting : ContentManagerBaseItem
    {
        // System
        // How long settings data remains in cache before being refreshed
        public int SettingsCacheTimeInMinutes { get; set; }         
        
        // Rendering 
        // Show this many records in grids before paging; default: 10
        public int GridPageSize { get; set; }                       
        // If content data is longer than <ContentExtractLength> characters, show an ellipsis (...); default: true
        public bool ShowContentEllipsis { get; set; }               
        // How long content can be before the ellipsis logic kicks in; default: 10-15 characters
        public int ContentExtractLength { get; set; }               
        
        // Workflow
        // Can rejected content be re-activated (by admin)?; default: false
        public bool AllowRejectedContentReActivation { get; set; }  
        // Can expired content be re-activated (by admin)?; default: true   
        public bool AllowExpiredContentReActivation { get; set; }   
    }
}
