using System;
using System.Collections.Generic;
//
using ContentNamespace.Web.Code.Entities.Base;
using ContentNamespace.Web.Code.Util;
//
using Stateless;

//using System.ComponentModel.DataAnnotations;

namespace ContentNamespace.Web.Code.Entities
{
    [Serializable]
    public class HtmlContent : WorkflowEnabledBaseItem<Enums.ContentState, Enums.ContentTransition>
    {
        #region Properties...

        // Intrinsic
        //[Required]
        //[StringLength(3)]
        public string Name { get; set; }
        public string ContentData { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime ActiveDate { get; set; }

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
        public void Edit() { _itemStateMachine.Fire(Enums.ContentTransition.Edit); }
        public void Save() { _itemStateMachine.Fire(Enums.ContentTransition.Save); }
        public void Submit() { _itemStateMachine.Fire(Enums.ContentTransition.Submit); }
        // Admin actions
        public void RequireEdit() { _itemStateMachine.Fire(Enums.ContentTransition.RequireEdit); }
        public void Accept() { _itemStateMachine.Fire(Enums.ContentTransition.Accept); }
        public void Reject() { _itemStateMachine.Fire(Enums.ContentTransition.Reject); }
        // System or admin actions
        public void Expire() { _itemStateMachine.Fire(Enums.ContentTransition.Expire); }

        protected override sealed void ConfigureWorkflow(StateMachine<Enums.ContentState, Enums.ContentTransition> htmlContentWorkflow)
        {
            // State: Created; only allow the transition to InProgress if the user has edit rights (either the owner of the content
            // or an admin)
            htmlContentWorkflow.Configure(Enums.ContentState.Created)
                .PermitIf(Enums.ContentTransition.Edit, Enums.ContentState.InProgress, () => HasEditRights)
                .PermitIf(Enums.ContentTransition.Save, Enums.ContentState.InProgress, () => HasEditRights);

            // State: InProgress
            htmlContentWorkflow.Configure(Enums.ContentState.InProgress)
                .PermitReentryIf(Enums.ContentTransition.Edit, () => HasEditRights) // Re-entrant to InProgress state
                .PermitReentryIf(Enums.ContentTransition.Save, () => HasEditRights) // Re-entrant to InProgress state
                .PermitIf(Enums.ContentTransition.Submit, Enums.ContentState.Submitted, () => HasEditRights);

            // State: Submitted
            htmlContentWorkflow.Configure(Enums.ContentState.Submitted)
                .PermitReentryIf(Enums.ContentTransition.Save, () => HasEditRights) // Re-entrant to Submitted state
                .PermitIf(Enums.ContentTransition.RequireEdit, Enums.ContentState.InProgress, () => IsAdminUser) // Returns to InProgress state
                .PermitIf(Enums.ContentTransition.Accept, Enums.ContentState.Published, () => IsAdminUser)
                .PermitIf(Enums.ContentTransition.Reject, Enums.ContentState.Rejected, () => IsAdminUser);

            // State: Published
            htmlContentWorkflow.Configure(Enums.ContentState.Published)
                .PermitReentryIf(Enums.ContentTransition.Save, () => HasEditRights) // Re-entrant to Published state
                .OnEntry(() => Email.Send(Enums.EmailType.ContentPublished))
                .PermitIf(Enums.ContentTransition.Expire, Enums.ContentState.Expired, () => IsAdminUser);

            // State: Rejected
            htmlContentWorkflow.Configure(Enums.ContentState.Rejected)
                .PermitReentryIf(Enums.ContentTransition.Save, () => HasEditRights) // Re-entrant to Rejected state
                .OnEntry(() => Email.Send(Enums.EmailType.ContentRejected));
        }

        #endregion
    }
}