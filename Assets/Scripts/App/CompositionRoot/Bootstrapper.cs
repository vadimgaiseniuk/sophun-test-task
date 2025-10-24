using App.GlobalStateMachine;
using Architecture.Core;
using UnityEngine;
using Zenject;

namespace App.DependencyInjection
{
    public class Bootstrapper : MonoBehaviour
    {
        private StateMachineBase m_globalStateMachine;
        
        [Inject]
        public void Construct(GlobalStateMachine.GlobalStateMachine globalStateMachine)
        {
            m_globalStateMachine = globalStateMachine;
        }

        private void Start()
        {
            m_globalStateMachine.ChangeState<BootstrapState>();
        }
    }
}