using System;
using System.Linq;
//
using ContentNamespace.Web.Code.Entities;

namespace ContentNamespace.Web.Code.Service.Interfaces
{
    public interface IHtmlContentService
    {
        IQueryable<HtmlContent> Get(DateTime dt);
        IQueryable<HtmlContent> Get();
        IQueryable<HtmlContent> Get(int pageIndex, int pageSize, out int totalCount);
        HtmlContent Get(int id);
        HtmlContent Get(string name, DateTime dt);
        HtmlContent Save(HtmlContent item);
        bool Delete(HtmlContent item);  
    }
}


 