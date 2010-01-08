using ContentNamespace.Web.Code.Entities;

namespace ContentNamespace.Web.Code.Service.Interfaces
{
    public interface ISettingService : IContentManagerBaseService
    {
        Settings Save(Settings settings);
    }
}
