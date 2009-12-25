using Stateless;

namespace ContentNamespace.Web.Code.Entities.Base
{
    public abstract class WorkflowParticipantBaseItem : ContentManagerBaseItem
    {
        #region Fields...

        protected StateMachine<Enum.ContentState, Enum.ContentTransition> _itemStateMachine;
        protected Enum.ContentState _itemState = Enum.ContentState.Created;

        #endregion

        #region Constructors...

        protected WorkflowParticipantBaseItem()
        {
            _itemStateMachine = new StateMachine<Enum.ContentState, Enum.ContentTransition>(() => _itemState,
                r => _itemState = r);
        }

        #endregion

        #region Methods...

        protected abstract void ConfigureWorkflow(StateMachine<Enum.ContentState, Enum.ContentTransition> itemWorkflow);

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

        #endregion
    }
}
