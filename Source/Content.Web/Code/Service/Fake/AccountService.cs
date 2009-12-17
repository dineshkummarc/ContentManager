


using System;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContentNamespace.Web;
using ContentNamespace.Web.Controllers;

namespace ContentNamespace.Web.Code.Service.Fake
{

    public class MockFormsAuthentication : IFormsAuthentication
    {
        public void SignIn(string userName, bool createPersistentCookie)
        {
        }

        public void SignOut()
        {
        }
    }

    public class MockIdentity : IIdentity
    {
        public string AuthenticationType
        {
            get
            {
                return "MockAuthentication";
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return true;
            }
        }

        public string Name
        {
            get
            {
                return "someUser";
            }
        }
    }

    public class MockPrincipal : IPrincipal
    {
        IIdentity _identity;

        public IIdentity Identity
        {
            get
            {
                if (_identity == null)
                {
                    _identity = new MockIdentity();
                }
                return _identity;
            }
        }

        public bool IsInRole(string role)
        {
            return false;
        }
    }

    public class MockMembershipUser : MembershipUser
    {
        public override bool ChangePassword(string oldPassword, string newPassword)
        {
            return newPassword.Equals("newPass");
        }
    }

    public class MockHttpContext : HttpContextBase
    {
        private IPrincipal _user;

        public override IPrincipal User
        {
            get
            {
                if (_user == null)
                {
                    _user = new MockPrincipal();
                }
                return _user;
            }
            set
            {
                _user = value;
            }
        }
    }

    public class MockMembershipProvider : MembershipProvider
    {
        string _applicationName;

        public override string ApplicationName
        {
            get
            {
                return _applicationName;
            }
            set
            {
                _applicationName = value;
            }
        }

        public override bool EnablePasswordReset
        {
            get
            {
                return false;
            }
        }

        public override bool EnablePasswordRetrieval
        {
            get
            {
                return false;
            }
        }

        public override int MaxInvalidPasswordAttempts
        {
            get
            {
                return 0;
            }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get
            {
                return 0;
            }
        }

        public override int MinRequiredPasswordLength
        {
            get
            {
                return 6;
            }
        }

        public override string Name
        {
            get
            {
                return null;
            }
        }

        public override int PasswordAttemptWindow
        {
            get
            {
                return 3;
            }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get
            {
                return MembershipPasswordFormat.Clear;
            }
        }

        public override string PasswordStrengthRegularExpression
        {
            get
            {
                return null;
            }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get
            {
                return false;
            }
        }

        public override bool RequiresUniqueEmail
        {
            get
            {
                return false;
            }
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, 
            string email, string passwordQuestion, string passwordAnswer, 
            bool isApproved, Object providerUserKey, out MembershipCreateStatus status)
        {
            MockMembershipUser user = new MockMembershipUser();

            if (username.Equals("someUser") && password.Equals("goodPass") && email.Equals("email"))
            {
                status = MembershipCreateStatus.Success;
            }
            else
            {
                // the 'email' parameter contains the status we want to return to the user
                status = (MembershipCreateStatus)Enum.Parse(typeof(MembershipCreateStatus), email);
            }

            return user;
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, 
            int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, 
            int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, 
            int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(Object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            return new MockMembershipUser();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateUser(string username, string password)
        {
            return password.Equals("goodPass");
        }

    }

    /*public class MockMembershipService : IMembershipService
    {
        #region IMembershipService Members

        public int MinPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public bool ValidateUser(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public MembershipCreateStatus CreateUser(string userName, string password, string email)
        {
            throw new NotImplementedException();
        }

        public bool ChangePassword(string userName, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        #endregion
    }*/
}
 