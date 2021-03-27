using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AesRijndael.Core;
using Prism.Commands;

using Prism.Services.Dialogs;

namespace AesRijndael.MainModule.ViewModels
{
    public class EnterKeyViewModel : BaseViewModel
    {
        public EnterKeyViewModel()
        {   
            AboutCommand = new DelegateCommand(AboutCommandExecuted);
        }

        public ICommand AboutCommand { get; private set; }

        public void AboutCommandExecuted()
        {
            _dialogService.ShowDialog(nameof(Views.AboutView), new DialogParameters(), (IDialogResult dialogResult) => { });
        }
    }
}
