using System;
//
using ContentNamespace.Web.Code.Entities.Base;
using ContentNamespace.Web.Code.Util;
//
using Stateless;

namespace ContentNamespace.Web.Code.Entities
{
    public class HtmlContent : WorkflowParticipantBaseItem
    {
        #region Fields...

        private readonly StateMachine<Enum.ContentState, Enum.ContentTransition> _contentStateMachine;
        private Enum.ContentState _contentState = Enum.ContentState.Created;

        #endregion

        #region Properties...

        public string Name { get; set; }
        public string ContentData { get; set; }
        
        public Enum.ContentState ContentState
        {
            get { return _contentStateMachine.State; } 
        }
        
        public DateTime ExpireDate { get; set; }
        public DateTime ActiveDate { get; set; }
        
        public int OwnerUserId { get; set; }

        public static bool HasEditRights
        {
            get
            {
                return true; // TODO: Evaluate if user is owner
            }
        }

        public static bool IsAdminUser
        {
            get
            {
                return true; // TODO: Evaluate if user is admin
            }
        }

        #endregion

        #region Constructors...

        public HtmlContent()
        {
            Id = -2;

            _contentStateMachine = new StateMachine<Enum.ContentState, Enum.ContentTransition>(() => _contentState,
                r => _contentState = r);

            _contentStateMachine = new StateMachine<Enum.ContentState, Enum.ContentTransition>(Enum.ContentState.Created);

            // See: \Documents\Workflow State Machine.txt for additional information
            ConfigureWorkflow(_contentStateMachine);
        }

        #endregion

        #region Methods...

        public void Edit()
        {
            _contentStateMachine.Fire(Enum.ContentTransition.Edit);
        }

        public void Save()
        {
            _contentStateMachine.Fire(Enum.ContentTransition.Save);
        }

        protected override sealed void ConfigureWorkflow(StateMachine<Enum.ContentState, Enum.ContentTransition> contentWorkflow)
        {
            // State: Created; only allow the transition to InProgress if the user has edit rights (either the owner of the content
            // or an admin)
            contentWorkflow.Configure(Enum.ContentState.Created)
                .PermitIf(Enum.ContentTransition.Edit, Enum.ContentState.InProgress, () => HasEditRights)
                .PermitIf(Enum.ContentTransition.Save, Enum.ContentState.InProgress, () => HasEditRights);

            // State: InProgress
            contentWorkflow.Configure(Enum.ContentState.InProgress)
                .PermitReentryIf(Enum.ContentTransition.Save, () => HasEditRights) // Returns to InProgress state
                .PermitIf(Enum.ContentTransition.Submit, Enum.ContentState.Submitted, () => HasEditRights);

            // State: Submitted
            contentWorkflow.Configure(Enum.ContentState.Submitted)
                .PermitIf(Enum.ContentTransition.RequireEdit, Enum.ContentState.InProgress, () => IsAdminUser) // Returns to InProgress state
                .PermitIf(Enum.ContentTransition.Accept, Enum.ContentState.Published, () => IsAdminUser)
                .PermitIf(Enum.ContentTransition.Reject, Enum.ContentState.Rejected, () => IsAdminUser);

            // State: Published
            contentWorkflow.Configure(Enum.ContentState.Published)
                .OnEntry(() => Email.Send(Enum.EmailType.ContentPublished))
                .PermitIf(Enum.ContentTransition.Expire, Enum.ContentState.Expired, () => IsAdminUser);

            // State: Rejected
            contentWorkflow.Configure(Enum.ContentState.Rejected)
                .OnEntry(() => Email.Send(Enum.EmailType.ContentRejected));
        }

        #endregion
    }
}