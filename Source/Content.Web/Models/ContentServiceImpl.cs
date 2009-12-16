
using ContentNamespace.Web.Code.Service.Interfaces;
using ContentNamespace.Web.Code.Entities;
using System.Linq;
using System.Collections.Generic;
using System;


namespace NinjectIntegration.Models
{
    public class ContentServiceImpl : IContentService
    {
        #region IContentService Members

        public IQueryable<HtmlContent> Get(System.DateTime dt)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<HtmlContent> Get()
        {
            IList<HtmlContent> list = new List<HtmlContent>();
            for (int i = 0; i < 10; i++)
            {
                HtmlContent x = new HtmlContent();
                x.ContentData = "<b>hello</b>";
                x.ActiveDate = DateTime.Now;
                x.Id = i;
                x.ModifiedBy = "me";
                x.ModifiedDate = DateTime.Now;
                x.ExpireDate = DateTime.MaxValue;
                list.Add(x);
            }
            return list.AsQueryable();
        }

        public HtmlContent Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public HtmlContent Save(HtmlContent item)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(HtmlContent item)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
     
}
