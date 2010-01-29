using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContentNamespace.Web.Code.Entities;
using ContentNamespace.Web.Code.DataAccess.Interfaces;
using ContentNamespace.Web.Code.Service.Interfaces;
using ContentNamespace.Web.Code.Service.SystemServices;
using ContentNamespace.Web.Code.Util;
using ContentNamespace.Web.Code.Service.ConfigurationServices;

namespace ContentNamespace.Web.Code.Service.Base
{
    public class HtmlContentService : IHtmlContentService
    {
        private IHtmlContentRepository _contentRepository;
        private ISettingService _settingService;

        public HtmlContentService(IHtmlContentRepository repository, ISettingService settingService)
        {
            _contentRepository = repository;
            _settingService = settingService;
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
            //return ((IContentManagerBaseService)this).GetData() as IQueryable<HtmlContent>;
            var _setting = _settingService.Get();
            var contents = _contentRepository.Get().Select(x => new HtmlContent
            {
                Id = x.Id,
                Name = x.Name,
                //ContentData = (x.ContentData.Length > 5) ?
                //               x.ContentData.Substring(0, 5) + "..." :
                //               x.ContentData,
                ContentData = (x.ContentData.Length > _setting.ContentExtractLength) ?
                               x.ContentData.Substring(0, _setting.ContentExtractLength) + "..." :
                               x.ContentData,
                //ContentData = x.ContentData,
                ActiveDate = x.ActiveDate,
                ExpireDate = x.ExpireDate,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate,
                ItemState = x.ItemState
            });
            return contents; 
        }

        public IQueryable<HtmlContent> Get(int pageIndex, int pageSize, out int totalCount)
        {
            var _setting = _settingService.Get();
            var contents = _contentRepository.Get(pageIndex, _setting.GridPageSize, out totalCount).AsQueryable().Select(x => new HtmlContent
            {
                Id = x.Id,
                Name = x.Name,
                //ContentData = (x.ContentData.Length > 5) ?
                //               x.ContentData.Substring(0, 5) + "..." :
                //               x.ContentData,
                ContentData = (x.ContentData.Length > _setting.ContentExtractLength) ?
                               x.ContentData.Substring(0, _setting.ContentExtractLength) + "..." :
                               x.ContentData,
                //ContentData = x.ContentData,
                ActiveDate = x.ActiveDate,
                ExpireDate = x.ExpireDate,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate,
                ItemState = x.ItemState
            });
            return contents; 
        }

        public HtmlContent Get(string name, DateTime dt)
        {
            return this._contentRepository.Get()
                .Where(x => x.Name == name && x.ExpireDate >= dt && x.ActiveDate <= dt)
                .Select(x => new HtmlContent
                {
                    Id = x.Id,
                    Name = x.Name,
                    ApplicationId = x.ApplicationId, 
                    ContentData = x.ContentData,
                    ActiveDate = x.ActiveDate,
                    ExpireDate = x.ExpireDate,
                    ModifiedBy = x.ModifiedBy,
                    ModifiedDate = x.ModifiedDate,
                    ItemState = x.ItemState
                }).SingleOrDefault(); 
        }

         
        public HtmlContent Get(int id)
        {
            return this._contentRepository.Get()
                .Where(x => x.Id == id)
                .Select(x => new HtmlContent
            {
                Id = x.Id,
                Name = x.Name,
                ContentData = x.ContentData,
                ActiveDate = x.ActiveDate,
                ExpireDate = x.ExpireDate,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate,
                ItemState = x.ItemState
            }).SingleOrDefault(); 
        }

        public HtmlContent Save(HtmlContent item)
        {
            item.ModifiedDate = DateTime.Now;
            item.Save();
            return this._contentRepository.Save(item);
        }

        public bool Delete(HtmlContent item)
        {
            return this._contentRepository.Delete(item);
        }

        #region IContentManagerBaseService Members...

        public object GetData()
        {
            var _setting = _settingService.Get();
            var contents = _contentRepository.Get().Select(x => new HtmlContent
            {
                Id = x.Id,
                Name = x.Name,
                //ContentData = (x.ContentData.Length > 5) ?
                //               x.ContentData.Substring(0, 5) + "..." :
                //               x.ContentData,
                ContentData = (x.ContentData.Length > _setting.ContentExtractLength) ?
                               x.ContentData.Substring(0, _setting.ContentExtractLength) + "..." :
                               x.ContentData,
                //ContentData = x.ContentData,
                ActiveDate = x.ActiveDate,
                ExpireDate = x.ExpireDate,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate,
                ItemState = x.ItemState
            });

            return contents;
        }

        #endregion



    }
}