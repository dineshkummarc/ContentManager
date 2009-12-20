using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContentNamespace.Web.Code.Entities
{
    public class Enum
    {
        /// <summary>
        /// The types of roles (typically, levels of privilege) that a user can have.
        /// </summary>
        public enum UserRoles
        {
            Admin = 0,          // Superuser: all admin functions, content publish/edit rights over all content
            Contributor = 1,    // Power user: content publish/edit rights over own content
            Reader = 2          // User: read only rights
        }

        /// <summary>
        /// Various states a content item can be in.
        /// </summary>
        public enum ContentStatus
        {
            Created = 0,        // Created and/or editing
            Submitted = 1,      // Editing completed, submitted for approval workflow, if any
            Published = 2,      // Passed approval workflow, if any, and published for viewing
            Rejected = 99       // Rejected and not published
        }
    }
}