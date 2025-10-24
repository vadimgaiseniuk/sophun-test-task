namespace Architecture.Core
{
    public abstract class StateBase
    {
        protected StateMachineBase StateMachine;
        
        public void Initialize(StateMachineBase stateMachine)
        {
            StateMachine = stateMachine;    
        }
        
        public abstract void Enter();
        public abstract void Exit();
    }
}