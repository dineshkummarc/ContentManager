using Stateless;

namespace ContentNamespace.Web.Code.Entities.Base
{
    public abstract class WorkflowParticipantBaseItem : ContentManagerBaseItem
    {
        protected abstract void ConfigureWorkflow(StateMachine<Enum.ContentState, Enum.ContentTransition> baseItemWorkflow);
    }
}
