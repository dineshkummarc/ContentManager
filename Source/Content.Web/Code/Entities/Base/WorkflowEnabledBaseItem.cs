using System.Collections.Generic;
using Stateless;
using System;

namespace ContentNamespace.Web.Code.Entities.Base
{
    [Serializable]
    public abstract class WorkflowEnabledBaseItem<TState, TTransition> : ContentManagerBaseItem
    {
        #region Fields...

        protected StateMachine<TState, TTransition> _itemStateMachine;
        protected TState _itemState;

        #endregion

        #region Properties...

        // State machine related
        public TState ItemState
        {
            get { return _itemState; }
            set { _itemState = value; }
        }
        public TState ItemStateMachineState
        {
            get { return _itemStateMachine.State; }
        }
        public IEnumerable<TTransition> AvailableTransitions
        {
            get { return _itemStateMachine.PermittedTriggers; }
        }

        #endregion

        #region Constructors...

        protected WorkflowEnabledBaseItem()
        {
            _itemStateMachine = new StateMachine<TState, TTransition>(() => _itemState,
                r => _itemState = r);
        }

        #endregion

        #region Methods...

        protected abstract void ConfigureWorkflow(StateMachine<TState, TTransition> itemWorkflow);

        #endregion
    }
}
