using System.Linq;
//
using ContentNamespace.Web.Code.Entities;

namespace ContentNamespace.Web.Code.Service.UserProfileServices
{
    public interface IUserProfileService
    {
        IQueryable<UserProfile> Get();
        UserProfile Get(int id); 
        UserProfile Save(UserProfile item);
        bool Delete(UserProfile item);
    }
}
