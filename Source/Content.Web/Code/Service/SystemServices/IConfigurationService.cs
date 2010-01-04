using ContentNamespace.Web.Code.Entities;

namespace ContentNamespace.Web.Code.Service.Interfaces
{
    public interface IConfigurationService : IContentManagerBaseService
    {
        Settings Save(Settings settings);
    }
}
