namespace ContentNamespace.Web.Code.Entities
{
    public class Enums
    {
        #region Infrastructure...

        public enum EmailType
        {
            ContentPublished = 0,
            ContentRejected = 1
        }

        #endregion

        #region User...

        /// <summary>
        /// The types of roles (typically, levels of privilege) that a user can have.
        /// </summary>
        public enum UserRoles
        {
            Admin = 0,          // Superuser: all admin functions, content publish/edit rights over all content
            Contributor = 1,    // Power user: content publish/edit rights over own content
            Reader = 2          // User: read only rights
        }

        #endregion

        #region Workflow...

        /// <summary>
        /// Various states a content item can be in.
        /// </summary>
        public enum ContentState
        {
            Created = 0,        // Created, but before any other action has taken place
            InProgress = 1,     // Editing
            Submitted = 2,      // Editing completed, submitted for approval
            Published = 3,      // Approved and published for viewing
            Expired = 4,        // Content has passed its specified active window and has been de-published
            Rejected = 99       // Rejected and not published
        }

        /// <summary>
        /// Various transitions a content item can undergo between states
        /// </summary>
        public enum ContentTransition
        {
            Save = 0,
            Delete = 1,
            Edit = 2,
            Submit = 3,
            RequireEdit = 4,
            Accept = 5,
            Expire = 6,
            Reject = 99
        }

        #endregion
    }
}