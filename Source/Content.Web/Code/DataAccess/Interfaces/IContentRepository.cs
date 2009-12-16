using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using ContentNamespace.Web.Code.Entities;

namespace ContentNamespace.Web.Code.DataAccess.Interfaces
{
    public interface IContentRepository
    {
        IQueryable<HtmlContent> Get();

        HtmlContent Save(HtmlContent item);

        bool Delete(HtmlContent item);
    }
}
