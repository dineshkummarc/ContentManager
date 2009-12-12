using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using Content.Web.Code.Entities;

namespace Content.Web.Code.DataAccess.Interfaces
{
    public interface IContentRepository
    {
        IQueryable<HtmlContent> GetContentList();

        HtmlContent Save(HtmlContent item);

        bool Delete(HtmlContent item);
    }
}
