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

            _itemStateMachine = new StateMachine<Enum.ContentState, Enum.ContentTransition>(Enum.ContentState.Created);
        }

        #endregion

        #region Methods...

        protected abstract void ConfigureWorkflow(StateMachine<Enum.ContentState, Enum.ContentTransition> itemWorkflow);

        #endregion
    }
}
