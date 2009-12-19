using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ent = ContentNamespace.Web.Code.Entities;
using ContentNamespace.Web.Code.Entities;

namespace ContentNamespace.Web.Code.Service.Interfaces
{

    public interface IContentService
    {
        IQueryable<HtmlContent> Get(DateTime dt);
        IQueryable<HtmlContent> Get();
        HtmlContent Get(int id);
        HtmlContent Save(HtmlContent item);
        bool Delete(HtmlContent item);
    }
}


 