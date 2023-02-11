
using AesRijndael.MainModule.Views;

using AesRijndaelLibrary;

using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace AesRijndael.MainModule;

public class MainModule : IModule
{
    public void OnInitialized(IContainerProvider containerProvider)
    {
        IRegionManager regionManager = containerProvider.Resolve<IRegionManager>();
        regionManager.RegisterViewWithRegion("MainRegion", typeof(MainView));
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterSingleton<IDecreptor, Decreptor>();
        containerRegistry.RegisterSingleton<IEncryptor, Encryptor>();

        containerRegistry.RegisterDialog<AboutView>();
        containerRegistry.RegisterDialog<MainView>();
    }
}
