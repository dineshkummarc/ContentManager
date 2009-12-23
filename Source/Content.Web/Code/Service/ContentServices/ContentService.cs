using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContentNamespace.Web.Code.Entities;
using ContentNamespace.Web.Code.DataAccess.Interfaces;
using ContentNamespace.Web.Code.Service.Interfaces; 

namespace ContentNamespace.Web.Code.Service.Base
{
    public class ContentService : IContentService
    {
        private IContentRepository _repository;
        public ContentService(IContentRepository _rep)
        {
            _repository = _rep;
        }

        public IQueryable<HtmlContent> Get(DateTime dt)
        {
            return null;
        }

        /// <summary>
        /// when you get all then just get a substring for the content data
        /// </summary>
        /// <returns></returns>
        public IQueryable<HtmlContent> Get()
        {
            var contents = this._repository.Get().Select(x => new HtmlContent
            {
                Id = x.Id,
                Name = x.Name,
                ContentData = (x.ContentData.Length > 10) ? x.ContentData.Substring(0, 10) + "..." : x.ContentData,
                ActiveDate = x.ActiveDate,
                ExpireDate = x.ExpireDate,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate
            });
            //var contents = this._repository.Get();

            return contents;  
        }
         
        public HtmlContent Get(int id)
        {
            return this._repository.Get().Where(x => x.Id == id).Single<HtmlContent>();
        }

        public HtmlContent Save(HtmlContent item)
        {
            item.Save();

            return this._repository.Save(item);
        }

        public bool Delete(HtmlContent item)
        {
            return false;
        }

    }
}