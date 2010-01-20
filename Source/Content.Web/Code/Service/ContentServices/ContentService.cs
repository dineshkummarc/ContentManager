﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContentNamespace.Web.Code.Entities;
using ContentNamespace.Web.Code.DataAccess.Interfaces;
using ContentNamespace.Web.Code.Service.Interfaces;
using ContentNamespace.Web.Code.Service.SystemServices;
using ContentNamespace.Web.Code.Util;

namespace ContentNamespace.Web.Code.Service.Base
{
    public class ContentService : ContentManagerBaseService<IContentRepository, HtmlContent>, IContentService
    {
        //private IContentRepository _repository; 


        public ContentService(IContentRepository repository) : base(repository)
        {
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
            return ((IContentManagerBaseService)this).GetData() as IQueryable<HtmlContent>;
        }

        public HtmlContent Get(string name, DateTime dt)
        {
            return this._repository.Get()
                .Where(x => x.Name == name && x.ExpireDate >= dt && x.ActiveDate <= dt)
                .Select(x => new HtmlContent
                {
                    Id = x.Id,
                    Name = x.Name,
                    ContentData = x.ContentData,
                    ActiveDate = x.ActiveDate,
                    ExpireDate = x.ExpireDate,
                    ModifiedBy = x.ModifiedBy,
                    ModifiedDate = x.ModifiedDate,
                    ItemState = Enums.ContentState.InProgress //x.ItemState
                }).SingleOrDefault(); 
        }

         
        public HtmlContent Get(int id)
        {
            return this._repository.Get().Where(x => x.Id == id).FirstOrDefault();//.Select(x => new HtmlContent
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    ContentData = x.ContentData,
            //    ActiveDate = x.ActiveDate,
            //    ExpireDate = x.ExpireDate,
            //    ModifiedBy = x.ModifiedBy,
            //    ModifiedDate = x.ModifiedDate,
            //    ItemState = Enums.ContentState.InProgress
            //}).SingleOrDefault(); 
        }

        public HtmlContent Save(HtmlContent item)
        {
            item.Save();

            return this._repository.Save(item);
        }

        public bool Delete(HtmlContent item)
        {
            return this._repository.Delete(item);
        }

        #region IContentManagerBaseService Members...

        object IContentManagerBaseService.GetData()
        {
            var contents = _repository.Get();
                //.Select(x => new HtmlContent
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    //ContentData = (x.ContentData.Length > 5) ?
            //    //               x.ContentData.Substring(0, 5) + "..." :
            //    //               x.ContentData,
            //    ContentData = (x.ContentData.Length > _settings.ContentExtractLength) ?
            //                   x.ContentData.Substring(0, _settings.ContentExtractLength) + "..." :
            //                   x.ContentData,
            //    //ContentData = x.ContentData,
            //    ActiveDate = x.ActiveDate,
            //    ExpireDate = x.ExpireDate,
            //    ModifiedBy = x.ModifiedBy,
            //    ModifiedDate = x.ModifiedDate//,
            //    //ItemState = x.ItemState
            //});

            return contents;
        }

        #endregion



    }
}