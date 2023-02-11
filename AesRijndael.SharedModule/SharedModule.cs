
using AesRijndael.Core;

using NLog;

using Prism.Ioc;
using Prism.Modularity;

namespace AesRijndael.SharedModule;

public class SharedModule : IModule
{
    public void OnInitialized(IContainerProvider containerProvider) => LogManager.LoadConfiguration("nlog.config");

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterSingleton<IMessageBoxService, MessageBoxService>();
        containerRegistry.RegisterSingleton<IFileDialogService, FileDialogService>();
        containerRegistry.RegisterSingleton<ILogService, LogService>();
    }
}
