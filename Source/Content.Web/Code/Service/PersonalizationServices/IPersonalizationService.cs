using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContentNamespace.Web.Code.Entities;

namespace ContentNamespace.Web.Code.Service.PersonalizationServices
{
    public interface IPersonalizationService
    {
        UserProfile GetProfile(string userName); 
    }
}
