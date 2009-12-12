using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Content.Web.Code.Entities; 

namespace Content.Web.Code.Service.Base
{
    public class ContentService
    {
        public IQueryable<HtmlContent> GetContent(DateTime dt)
        {
            return null;
        }

        public IQueryable<HtmlContent> GetContent()
        {
            return null;
        }

        public HtmlContent GetContent(int id)
        {
            return null;
        }

        public HtmlContent Save(HtmlContent item)
        {
            return null;
        }

        public bool Delete(HtmlContent item)
        {
            return false;
        }

    }
}