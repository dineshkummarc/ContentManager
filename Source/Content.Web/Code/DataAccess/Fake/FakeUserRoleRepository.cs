using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContentNamespace.Web.Code.Entities;
using ContentNamespace.Web.Code.DataAccess.Interfaces;
using ContentNamespace.Web.Code.Util;

namespace ContentNamespace.Web.Code.DataAccess.Fake
{
    public class FakeUserRoleRepository: IUserRoleRepository
    {
        IList<Enums.UserRoles> list = new List<Enums.UserRoles>();


        public FakeUserRoleRepository()
        {
            list = EnumHelper.EnumToList<Enums.UserRoles>().FindAll(
                delegate(Enums.UserRoles x)
                {
                    return true; //  x != Enums.UserRoles.Reader &&  x != Enums.UserRoles.Admin;
                }
            );
        }
         
        public IQueryable<Enums.UserRoles> Get()
        {
            return list.AsQueryable<Enums.UserRoles>();
        }

        public Enums.UserRoles Save(Enums.UserRoles item)
        {
            throw new NotImplementedException();
        }


        public bool Delete(Enums.UserRoles entity)
        {
            throw new NotImplementedException();
        }

    }
}
