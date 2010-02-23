using System;
using System.Linq;
//
using AutoMapper;
//
using ContentNamespace.Web.Code.Entities;
using ContentNamespace.Web.Code.DataAccess.Interfaces;
using ContentNamespace.Web.Code.Service.Interfaces;

namespace ContentNamespace.Web.Code.Service.HtmlContentServices
{
    public class HtmlContentService : IHtmlContentService
    {
        private readonly IHtmlContentRepository _contentRepository;
        private readonly ISettingService _settingService;

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
            var contents = _contentRepository.Get();
            return contents; 
        }

        public IQueryable<HtmlContent> Get(int pageIndex, int pageSize, out int totalCount)
        {
            var setting = _settingService.Get();
            var contents = _contentRepository.Get(pageIndex, setting.GridPageSize, out totalCount)
                .Select(x => Mapper.Map<HtmlContent, HtmlContent>(x)).AsQueryable();

            return contents; 
        }

        public HtmlContent Get(string name, DateTime dt)
        {
            return _contentRepository.Get().ToList()
                .Where(x => x.Name == name && x.ExpireDate >= dt && x.ActiveDate <= dt).SingleOrDefault(); 
        }

        public HtmlContent Get(int id)
        {
            var item = _contentRepository.Get().ToList()
                .Where(x => x.Id == id).SingleOrDefault();
            
            return item;
        }

        public HtmlContent Save(HtmlContent item)
        {
            item.ModifiedDate = DateTime.Now;
            item.Save();

            return _contentRepository.Save(item);
        }

        public bool Delete(HtmlContent item)
        {
            return _contentRepository.Delete(item);
        }

        #region IContentManagerBaseService Members...

        public object GetData()
        {
            var contents = _contentRepository.Get();

            return contents;
        }

        #endregion
    }
}