using Architecture.Core;
using Architecture.States;

namespace Architecture
{
    public class GlobalStateMachine : StateMachineBase
    {
        public GlobalStateMachine()
        {
            var bootstrapState = new BootstrapState();
            
            Add(bootstrapState);
            bootstrapState.Initialize(this);
        }
    }
}