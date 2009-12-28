using Stateless;

namespace ContentNamespace.Web.Code.Entities.Base
{
    public abstract class WorkflowEnabledBaseItem : ContentManagerBaseItem
    {
        #region Fields...

        protected StateMachine<Enums.ContentState, Enums.ContentTransition> _itemStateMachine;
        protected Enums.ContentState _itemState = Enums.ContentState.Created;

        #endregion

        #region Constructors...

        protected WorkflowEnabledBaseItem()
        {
            _itemStateMachine = new StateMachine<Enums.ContentState, Enums.ContentTransition>(() => _itemState,
                r => _itemState = r);
        }

        #endregion

        #region Methods...

        protected abstract void ConfigureWorkflow(StateMachine<Enums.ContentState, Enums.ContentTransition> itemWorkflow);

        #endregion
    }
}
