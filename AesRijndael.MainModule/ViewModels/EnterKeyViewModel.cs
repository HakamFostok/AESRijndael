using System;
using System.Windows.Input;

using AesRijndael.Core;

using AesRijndaelLibrary;

using Prism.Commands;

namespace AesRijndael.MainModule.ViewModels
{
    public class EnterKeyViewModel : BaseViewModel
    {
        public string _keyValue;
        public string KeyValue
        {
            get => _keyValue;
            set
            {
                _keyValue = value;
                _aggregator.GetEvent<KeyValueChangedEvent>().Publish(_keyValue);
            }
        }

        public EnterKeyViewModel()
        {
            AboutCommand = new DelegateCommand(AboutCommandExecuted);
            FormatCommand = new DelegateCommand(FormatCommandExecuted);
            ClearCommand = new DelegateCommand(ClearCommandExecuted);
            EncryptDecryptCommand = new DelegateCommand(EncryptDecryptCommandExecuted);
        }

        public ICommand AboutCommand { get; private set; }
        public ICommand FormatCommand { get; private set; }
        public ICommand ClearCommand { get; private set; }
        public ICommand EncryptDecryptCommand { get; private set; }

        public void AboutCommandExecuted()
        {
            try
            {
                ShowWindow(nameof(Views.AboutView));
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public void FormatCommandExecuted()
        {
            try
            {
                _aggregator.GetEvent<FormatTextEvent>().Publish();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public void ClearCommandExecuted()
        {
            try
            {
                _aggregator.GetEvent<ClearTextEvent>().Publish();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public void EncryptDecryptCommandExecuted()
        {
            try
            {
                _aggregator.GetEvent<EncryptDecryptEvent>().Publish();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

    }
}
