using System.Linq;
//
using ContentNamespace.Web.Code.DataAccess.Interfaces;
using ContentNamespace.Web.Code.Entities;
using ContentNamespace.Web.Code.Service.Interfaces;

namespace ContentNamespace.Web.Code.Service.ConfigurationServices
{
    public class ConfigurationService : IConfigurationService
    {
        #region Fields...

        private readonly IConfigurationRepository _repository;
        
        #endregion

        #region Constructors...

        public ConfigurationService(IConfigurationRepository repository)
        {
            _repository = repository;
        }

        #endregion

        #region IConfigurationService Members...

        public Settings Get()
        {
            return ((IContentManagerBaseService)this).GetData() as Settings;
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
