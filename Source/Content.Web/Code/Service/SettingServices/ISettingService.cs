using ContentNamespace.Web.Code.Entities;

namespace ContentNamespace.Web.Code.Service.Interfaces
{
    public interface ISettingService
    {
        Setting Get();
        Setting Save(Setting settings);
    }
}
