﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Collections.Specialized;

namespace ContentNamespace.Web.Code.Service.AuthenticationServices
{
    public class AspNetAuthenticationService : IAuthenticationService
    {
        #region IAuthenticationService Members

        public bool IsValidLogin(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public bool IsValidLogin(Uri serviceUri)
        {
            throw new NotImplementedException();
        }

        public bool IsValidLogin(string logonToken)
        {
            throw new NotImplementedException();
        }


        public object RegisterUser(string userName, string password, string confirmPassword, string email, string reminderQuestion, string reminderAnswer)
        {
            bool result = false;
            MembershipCreateStatus status;

            Membership.CreateUser(userName, password, email, reminderQuestion, reminderAnswer, true, out status);

            if (status == MembershipCreateStatus.Success)
            {
                result = true;

            }
            else
            {

                if (status == MembershipCreateStatus.DuplicateEmail)
                {
                    throw new InvalidOperationException("This email is already in our system");

                }
                if (status == MembershipCreateStatus.DuplicateUserName)
                {
                    throw new InvalidOperationException("Need to use another login - this one's taken");

                }
                if (status == MembershipCreateStatus.InvalidEmail)
                {
                    throw new InvalidOperationException("Invalid email address");

                }
                if (status == MembershipCreateStatus.InvalidPassword)
                {
                    throw new InvalidOperationException("Invalid password. Needs to be stronger");

                }
                if (status == MembershipCreateStatus.UserRejected)
                {
                    throw new InvalidOperationException("Cannot register at this time");

                }
            }

            return result;
        }



        #endregion
    }
}
