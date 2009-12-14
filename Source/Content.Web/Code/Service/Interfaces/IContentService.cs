using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ent = Content.Web.Code.Entities;
using Content.Web.Code.Entities;

namespace Content.Web.Code.Service.Interfaces
{

    public interface IContentService
    {
        IQueryable<HtmlContent> GetContent(DateTime dt);
        IQueryable<HtmlContent> GetContent();
        HtmlContent GetContent(int id);
        HtmlContent Save(HtmlContent item);
        bool Delete(HtmlContent item);
    }
}


 