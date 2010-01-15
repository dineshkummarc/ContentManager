using System;
using System.Linq;
//
using ContentNamespace.Web.Code.Entities;

namespace ContentNamespace.Web.Code.Service.Interfaces
{
    public interface IContentService : IContentManagerBaseService
    {
        IQueryable<HtmlContent> Get(DateTime dt);
        IQueryable<HtmlContent> Get();
        HtmlContent Get(int id);
        HtmlContent Save(HtmlContent item);
        bool Delete(HtmlContent item);  
    }
}


 