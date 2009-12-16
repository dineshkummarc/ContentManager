using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContentNamespace.Web.Code.DataAccess.Interfaces;
//using Ent = Content.Web.Code.Entities;
using ContentNamespace.Web.Code.Entities; 


namespace ContentNamespace.Web.Code.DataAccess.Fake
{

    public class FakeContentRepository : IContentRepository
    {

        IList<HtmlContent> list= new List<HtmlContent>();

        public FakeContentRepository()
        { 
            for (int i = 0; i < 2; i++ )
            {   
                HtmlContent x = new HtmlContent();
                x.ContentData = "<h1>Hello "+i+" </h1>";
                x.ActiveDate = DateTime.MinValue;
                x.ModifiedBy = "bob@aol.com";
                x.ModifiedDate = new DateTime(2009, 1, 1);
                x.Id = i;
                list.Add(x);
            } 
        }


        #region IContentRepository Members

        public IQueryable<HtmlContent> GetContentList()
        {
            return list.AsQueryable<HtmlContent>();
        }

        public HtmlContent Save(HtmlContent item)
        {
            if (item.Id > 0)
            {
                HtmlContent w = this.list.Where(x => x.Id == item.Id).SingleOrDefault();
                if (w != null)
                {
                    w = item;
                }
                else
                {
                    list.Add(item);
                }
            }
            else
            {
                int maxId = this.list.Max(x => x.Id);
                item.Id = maxId + 1;
                this.list.Add(item);
            }
            return item;
        }

        #endregion



        #region IContentRepository Members

        IQueryable<HtmlContent> IContentRepository.Get()
        {
            return this.list.AsQueryable<HtmlContent>(); 
        }
         


        bool IContentRepository.Delete(HtmlContent item)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}