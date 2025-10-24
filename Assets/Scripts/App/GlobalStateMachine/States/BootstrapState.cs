using System.Threading.Tasks;
using Architecture.Core;
using Core.Constants;
using SceneManagingService;
using Services.AssetManagingService;
using UnityEngine.SceneManagement;
using UserInterface;

namespace App
{
    public class BootstrapState : StateBase
    {
        private readonly GlobalStateMachine m_GlobalStateMachine;
        private readonly ISceneManagingService m_SceneManagingService;
        private readonly IAssetManagingService m_AssetManagingService;

        public BootstrapState(GlobalStateMachine globalStateMachine, ISceneManagingService sceneManagingService, IAssetManagingService assetManagingService)
        {
            m_GlobalStateMachine = globalStateMachine;
            m_SceneManagingService = sceneManagingService;
            m_AssetManagingService = assetManagingService;
        }
        
        public async override void Enter()
        {
            await m_SceneManagingService.LoadSceneAsync(ArchitecturePath.LeaderboardSceneName, mode: LoadSceneMode.Single);
            await ConstructUIRoot();
            
            m_GlobalStateMachine.ChangeState<LeaderboardState>();
        }

        public override void Exit()
        {
        }

        private async Task ConstructUIRoot()
        {
            m_GlobalStateMachine.Context.UIRootView = await m_AssetManagingService.InstantiateAssetAsync<UIRootView>(AssetPath.UIRootPath);
        }
    }
}