using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Modularity;
using Prism.Ioc;
using Prism.Regions;
using AesRijndael.MainModule.Views;
using AesRijndaelLibrary;

namespace AesRijndael.MainModule
{
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
}
