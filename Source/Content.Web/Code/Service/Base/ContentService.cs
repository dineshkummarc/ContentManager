using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Content.Web.Code.Entities;
using Content.Web.Code.DataAccess.Interfaces; 

namespace Content.Web.Code.Service.Base
{
    public class ContentService
    {
        private IContentRepository _repository;
        public ContentService(IContentRepository _rep)
        {
            _repository = _rep;
        }

        public IQueryable<HtmlContent> GetContent(DateTime dt)
        {
            return null;
        }

        public IQueryable<HtmlContent> GetContent()
        {
            IQueryable<HtmlContent> x = this._repository.Get();
            return x;
        }
        

        public HtmlContent GetContent(int id)
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