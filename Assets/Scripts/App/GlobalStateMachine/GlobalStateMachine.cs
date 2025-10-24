using Architecture.Core;
using SceneManagingService;
using Services.AssetManagingService;
using Services.DataSerializationService;
using Services.FileHandlingService;
using Services.SimplePopupService;
using Services.WebRequestHandlingService;

namespace App.GlobalStateMachine
{
    public class GlobalStateMachine : StateMachineBase, IContextProvider<GlobalContext>
    {
        public GlobalStateMachine(ISceneManagingService sceneManagingService, IFileHandlingService fileHandlingService, IDataSerializationService dataSerializationService, IAssetManagingService assetManagingService, IWebRequestHandlingService webRequestHandlingService, IPopupManagingService popupManagingService)
        {
            Context = new GlobalContext();
            
            var bootstrapState = new BootstrapState(this, sceneManagingService, assetManagingService);
            var leaderboardState = new LeaderboardState(this, fileHandlingService, dataSerializationService, webRequestHandlingService, assetManagingService, popupManagingService);
            var quitState = new QuitState(this, assetManagingService);
            
            Add(bootstrapState);
            Add(leaderboardState);
            Add(quitState);
        }

        public GlobalContext Context { get; }
    }
}