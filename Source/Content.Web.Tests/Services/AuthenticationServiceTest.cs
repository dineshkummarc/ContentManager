using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContentNamespace.Web.Code.Service.AuthorizationServices;
using ContentNamespace.Web.Code.Service.AuthenticationServices;

namespace ContentNamespace.Web.Tests.Services
{
    /// <summary>
    /// Summary description for AuthenticationServiceTest
    /// </summary>
    [TestClass]
    public class AuthenticationTests : TestBase
    {

        [TestMethod]
        public void AuthenticationServiceIsValidLogin_UsingUserNameAndPassword_IsAuthenticated()
        {

            IAuthenticationService authService = new TestAuthenticationService();
            bool isAuthenticated = authService.IsValidLogin("test", "password");
            Assert.IsTrue(isAuthenticated);
        }

        [TestMethod]
        public void AuthenticationServiceIsValidLogin_InvalidUserAndPassword_IsNotAuthenticated()
        {

            IAuthenticationService authService = new TestAuthenticationService();
            bool isAuthenticated = authService.IsValidLogin("poo", "poo");
            Assert.IsFalse(isAuthenticated);
        }

        [TestMethod]
        public void AuthenticationServiceIsValidLogin_UsingAUrl_IsAuthenticated()
        {

            IAuthenticationService authService = new TestAuthenticationService();
            bool isAuthenticated = authService.IsValidLogin(new Uri("http://test.com/"));
            Assert.IsTrue(isAuthenticated);
        }

    }
}
