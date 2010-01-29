using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using ContentNamespace.Web.Code.Entities;
using ContentNamespace.Web.Code.Util;

namespace ContentNamespace.Web.Code.DataAccess.Interfaces
{
    public interface IHtmlContentRepository : IRepository<HtmlContent>
    {
        PagedList<HtmlContent> Get(int pageIndex, int pageSize, out int totalCount);
    }
}
