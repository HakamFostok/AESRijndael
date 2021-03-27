using System;

using AesRijndael.Core;

using Prism.Services.Dialogs;

namespace AesRijndael.MainModule.ViewModels
{
    public class AboutViewModel : BaseViewModel, IDialogAware
    {
        public string Title => "About Program";

        public event Action<IDialogResult> RequestClose;

        public virtual void RaiseRequestClose(IDialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
        }

        public virtual bool CanCloseDialog()
        {
            return true;
        }

        public virtual void OnDialogClosed()
        {

        }

        public virtual void OnDialogOpened(IDialogParameters parameters)
        {

        }
    }
}
