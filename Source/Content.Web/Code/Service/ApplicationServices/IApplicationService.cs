using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContentNamespace.Web.Code.Entities;

namespace ContentNamespace.Web.Code.Service.ApplicationServices
{
    public interface IApplicationService 
    {
        IQueryable<Application> Get();
        Application Get(int id);
        Application Save(Application item);
        bool Delete(Application item);
    }
}
