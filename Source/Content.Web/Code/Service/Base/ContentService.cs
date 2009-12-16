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

        public IQueryable<HtmlContent> Get()
        {
            IQueryable<HtmlContent> x = this._repository.Get();
            return x;
        }


        public HtmlContent Get(int id)
        {
            return this._repository.Get().Where(x => x.Id == id).Single<HtmlContent>();
        }

        public HtmlContent Save(HtmlContent item)
        {
            return this._repository.Save(item);
        }

        public bool Delete(HtmlContent item)
        {
            return false;
        }

    }
}