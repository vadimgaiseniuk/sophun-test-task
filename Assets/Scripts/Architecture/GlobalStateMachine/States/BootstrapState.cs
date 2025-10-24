using Architecture.Core;
using Core.Constants;
using SceneManagingService;
using UnityEngine.SceneManagement;

namespace Architecture.States
{
    public class BootstrapState : StateBase
    {
        private readonly ISceneManagingService m_sceneManagingService;

        public BootstrapState(ISceneManagingService sceneManagingService)
        {
            m_sceneManagingService = sceneManagingService;
        }
        
        public async override void Enter()
        {
            await m_sceneManagingService.LoadSceneAsync(ArchitecturePath.LeaderboardSceneName, mode: LoadSceneMode.Single);
            
            StateMachine.ChangeState<LeaderboardState>();
        }

        public override void Exit()
        {
        }
    }
}