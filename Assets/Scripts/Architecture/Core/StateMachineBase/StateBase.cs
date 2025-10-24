namespace Architecture.Core
{
    public abstract class StateBase
    {
        protected StateMachineBase StateMachineBase;
        
        public void Initialize(StateMachineBase stateMachine)
        {
            StateMachineBase = stateMachine;    
        }
        
        public abstract void Enter();
        public abstract void Exit();
    }
}