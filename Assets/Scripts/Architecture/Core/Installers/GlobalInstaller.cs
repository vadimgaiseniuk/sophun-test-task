using SceneManagingService;
using Services.DataSerializationService;
using Services.FileHandlingService;
using SimplePopupService;
using Zenject;

namespace Architecture.Core.Installers
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
            Container.Bind<GlobalStateMachine>().AsSingle();
        }

        private void InstallServicesBindings()
        {
            Container.Bind<ISceneManagingService>().To<SceneManagingService.SceneManagingService>().AsSingle();
            Container.Bind<IFileHandlingService>().To<FileHandlingService>().AsSingle();
            Container.Bind<IDataSerializationService>().To<JsonDataSerializationService>().AsSingle();
            Container.Bind<IPopupManagingService>().To<PopupManagingService>().AsSingle();
        }
    }
}