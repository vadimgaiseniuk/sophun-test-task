namespace Architecture.Core
{
    public abstract class StateBase
    {
        public abstract void Enter();

        public virtual void Exit()
        {
        }
    }
}