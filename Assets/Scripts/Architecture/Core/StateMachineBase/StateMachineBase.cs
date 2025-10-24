using System;
using System.Collections.Generic;

namespace Architecture.Core
{
    public abstract class StateMachineBase
    {
        private StateBase m_currentState;
        private readonly Dictionary<Type, StateBase> m_states = new();
        
        protected void Add<TState>(TState state) where TState : StateBase
        {
            if (m_states.ContainsKey(typeof(TState)))
                return;

            m_states.Add(typeof(TState), state);
        }

        public void ChangeState<TState>() where TState : StateBase
        {
            LoadState(typeof(TState));
        }

        public void ExitStateMachine()
        {
            m_currentState?.Exit();
            m_currentState = null;
        }

        public void LoadState(Type type)
        {
            m_currentState?.Exit();
            
            m_currentState = m_states[type];
            m_currentState.Enter();
        }
    }
}