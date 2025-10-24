using System.Threading.Tasks;
using App.UserInterface;
using Architecture.Core;
using SceneManagingService;
using Services.AssetManagingService;
using UnityEngine.SceneManagement;

namespace App.GlobalStateMachine
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

        private async Task ConstructUIRoot()
        {
            m_GlobalStateMachine.Context.UIRootView = await m_AssetManagingService.InstantiateAssetAsync<UIRootView>(AssetPath.UIRootPath);
        }
    }
}