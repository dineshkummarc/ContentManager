using System.Linq;
//
using ContentNamespace.Web.Code.DataAccess.Interfaces;
using ContentNamespace.Web.Code.DataAccess.Db4o;
using ContentNamespace.Web.Code.Entities;
using ContentNamespace.Web.Code.Service.Interfaces;

namespace ContentNamespace.Web.Code.Service.ConfigurationServices
{
    public class ConfigurationService : ISettingService
    {
        #region Fields...

        private readonly ISettingRepository _repository;
        
        #endregion

        #region Constructors...

        public ConfigurationService(ISettingRepository repository)
        {
            _repository = repository;
        }

        #endregion

        #region IConfigurationService Members...

        public Settings Get()
        {
            return ((IContentManagerBaseService)this).GetData() as Settings;
        }

        public Settings Save(Settings settings)
        {
            return _repository.Save(settings);
        }

        #endregion

        #region IContentManagerBaseService Members...

        object IContentManagerBaseService.GetData()
        {
            return _repository.Get().FirstOrDefault();
        }

        #endregion
    }
}
