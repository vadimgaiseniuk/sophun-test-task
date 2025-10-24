using Architecture.Core;
using Services.AssetManagingService;

namespace App.GlobalStateMachine
{
    public class QuitState : StateBase
    {
        private readonly GlobalStateMachine m_GlobalStateMachine;
        private readonly IAssetManagingService m_AssetManagingService;

        public QuitState(GlobalStateMachine globalStateMachine, IAssetManagingService assetManagingService)
        {
            m_GlobalStateMachine = globalStateMachine;
            m_AssetManagingService = assetManagingService;
        }
        
        public override void Enter()
        {
            m_AssetManagingService.ReleaseAssetInstance(m_GlobalStateMachine.Context.UIRootView.gameObject);
        }
    }
}