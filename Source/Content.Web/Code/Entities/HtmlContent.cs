using System;
//
using ContentNamespace.Web.Code.Entities.Base;
using ContentNamespace.Web.Code.Util;
//
using Stateless;

namespace ContentNamespace.Web.Code.Entities
{
    public class HtmlContent : WorkflowEnabledBaseItem
    {
        #region Properties...

        // Intrinsic
        public string Name { get; set; }
        public string ContentData { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime ActiveDate { get; set; }
        
        // State machine related
        public Enum.ContentState ItemState
        {
            get { return _itemState; }
            set { _itemState = value; }
        }
        public Enum.ContentState HtmlContentState
        {
            get { return _itemStateMachine.State; } 
        }
        
        // Security related
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

            // See: \Documents\Workflow State Machine.txt for additional information
            ConfigureWorkflow(_itemStateMachine);
        }

        #endregion

        #region Methods...

        // User actions
        public void Edit() { _itemStateMachine.Fire(Enum.ContentTransition.Edit); }
        public void Save() { _itemStateMachine.Fire(Enum.ContentTransition.Save); }
        public void Submit() { _itemStateMachine.Fire(Enum.ContentTransition.Submit); }
        // Admin actions
        public void RequireEdit() { _itemStateMachine.Fire(Enum.ContentTransition.RequireEdit); }
        public void Accept() { _itemStateMachine.Fire(Enum.ContentTransition.Accept); }
        public void Reject() { _itemStateMachine.Fire(Enum.ContentTransition.Reject); }
        // System or admin actions
        public void Expire() { _itemStateMachine.Fire(Enum.ContentTransition.Expire); }

        protected override sealed void ConfigureWorkflow(StateMachine<Enum.ContentState, Enum.ContentTransition> htmlContentWorkflow)
        {
            // State: Created; only allow the transition to InProgress if the user has edit rights (either the owner of the content
            // or an admin)
            htmlContentWorkflow.Configure(Enum.ContentState.Created)
                .PermitIf(Enum.ContentTransition.Edit, Enum.ContentState.InProgress, () => HasEditRights)
                .PermitIf(Enum.ContentTransition.Save, Enum.ContentState.InProgress, () => HasEditRights);

            // State: InProgress
            htmlContentWorkflow.Configure(Enum.ContentState.InProgress)
                .PermitReentryIf(Enum.ContentTransition.Edit, () => HasEditRights) // Re-entrant to InProgress state
                .PermitReentryIf(Enum.ContentTransition.Save, () => HasEditRights) // Re-entrant to InProgress state
                .PermitIf(Enum.ContentTransition.Submit, Enum.ContentState.Submitted, () => HasEditRights);

            // State: Submitted
            htmlContentWorkflow.Configure(Enum.ContentState.Submitted)
                .PermitIf(Enum.ContentTransition.RequireEdit, Enum.ContentState.InProgress, () => IsAdminUser) // Returns to InProgress state
                .PermitIf(Enum.ContentTransition.Accept, Enum.ContentState.Published, () => IsAdminUser)
                .PermitIf(Enum.ContentTransition.Reject, Enum.ContentState.Rejected, () => IsAdminUser);

            // State: Published
            htmlContentWorkflow.Configure(Enum.ContentState.Published)
                .OnEntry(() => Email.Send(Enum.EmailType.ContentPublished))
                .PermitIf(Enum.ContentTransition.Expire, Enum.ContentState.Expired, () => IsAdminUser);

            // State: Rejected
            htmlContentWorkflow.Configure(Enum.ContentState.Rejected)
                .OnEntry(() => Email.Send(Enum.EmailType.ContentRejected));
        }

        #endregion
    }
}