using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//
using ContentNamespace.Web.Code.Entities.Base;

namespace ContentNamespace.Web.Code.Entities
{
    public class HtmlContent : ContentManagerBaseItem
    {
        public string Name { get; set; }
        public string ContentData { get; set; }
        public Enum.ContentStatus ContentStatus { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime ActiveDate { get; set; }

        public HtmlContent()
        {
            Id = -2;
        }
    }
}