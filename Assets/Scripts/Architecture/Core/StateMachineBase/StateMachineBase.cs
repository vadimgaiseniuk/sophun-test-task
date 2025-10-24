using System;
using System.Collections.Generic;

namespace Architecture.Core
{
    public abstract class StateMachineBase
    {
        private StateBase m_CurrentState;
        private readonly Dictionary<Type, StateBase> m_States = new();
        
        protected void Add<TState>(TState state) where TState : StateBase
        {
            if (m_States.ContainsKey(typeof(TState)))
                return;

            m_States.Add(typeof(TState), state);
        }

        public void ChangeState<TState>() where TState : StateBase
        {
            LoadState(typeof(TState));
        }

        public void ExitStateMachine()
        {
            m_CurrentState?.Exit();
            m_CurrentState = null;
        }

        public void LoadState(Type type)
        {
            m_CurrentState?.Exit();
            
            m_CurrentState = m_States[type];
            m_CurrentState.Enter();
        }
    }
}