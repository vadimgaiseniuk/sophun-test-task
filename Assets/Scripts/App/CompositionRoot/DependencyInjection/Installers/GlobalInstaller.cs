using SceneManagingService;
using Services.AssetManagingService;
using Services.DataSerializationService;
using Services.FileHandlingService;
using Services.SimplePopupService;
using Services.WebRequestHandlingService;
using Zenject;

namespace App.DependencyInjection
{
    public class GlobalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallArchitectureBindings();
            InstallServicesBindings();
        }

        private void InstallArchitectureBindings()
        {
            Container.Bind<GlobalStateMachine.GlobalStateMachine>().AsSingle();
        }

        private void InstallServicesBindings()
        {
            Container.Bind<IAssetManagingService>().To<AssetManagingService>().AsSingle();
            Container.Bind<IWebRequestHandlingService>().To<WebRequestHandlingService>().AsSingle();
            Container.Bind<ISceneManagingService>().To<SceneManagingService.SceneManagingService>().AsSingle();
            Container.Bind<IFileHandlingService>().To<FileHandlingService>().AsSingle();
            Container.Bind<IDataSerializationService>().To<JsonDataSerializationService>().AsSingle();
            Container.Bind<IPopupManagingService>().To<PopupManagingService>().AsSingle();
        }
    }
}