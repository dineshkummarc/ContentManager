using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContentNamespace.Web.Code.Service.AuthorizationServices
{
    public class TestAuthorizationService : IAuthorizationService
    {

        #region IAuthorizationService Members

        public bool IsSuperAdmin(string userName)
        {
            return userName.Equals("testuser");
        }

        #endregion
    }
}
