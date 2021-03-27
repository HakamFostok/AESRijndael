using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AesRijndael.Core;

using AesRijndaelLibrary;

using Prism.Events;

namespace AesRijndael.MainModule.ViewModels
{
    public class TextViewModel : BaseViewModel
    {
        private readonly IEncryptor _encryptor;
        private readonly IDecreptor _decreptor;

        public bool IsEncryptionReadOnly => _operation == Operation.Decryption;
        public bool IsDecryptionReadOnly => _operation == Operation.Encryption;

        public string TextToEncrypt { get; set; }
        public string TextToDecrypt { get; set; }

        private void UpdateReadOnlyProperties()
        {
            RaisePropertyChanged(nameof(IsEncryptionReadOnly));
            RaisePropertyChanged(nameof(IsDecryptionReadOnly));
        }

        private Operation _operation;
        private AesKeyBase _algorithmType;

        public TextViewModel(IEncryptor encryptor, IDecreptor decreptor)
        {
            _aggregator.GetEvent<ClearTextEvent>().Subscribe(ClearTextEventHandler);
            _aggregator.GetEvent<FormatTextEvent>().Subscribe(FormatTextEventHandler);
            _aggregator.GetEvent<EncryptDecryptEvent>().Subscribe(EncryptDecryptEventHandler);
            _aggregator.GetEvent<OperationChangedEvent>().Subscribe(OperationChangedEventHandler);
            _aggregator.GetEvent<AlgorithmKindChangedEvent>().Subscribe(AlgorithmKindChangedEventHandler);

            _encryptor = encryptor;
            _decreptor = decreptor;
        }

        private void FormatTextEventHandler()
        {
            throw new NotImplementedException();
        }

        private void AlgorithmKindChangedEventHandler(AesKeyBase algorithmType)
        {
            _algorithmType = algorithmType;
        }

        private void OperationChangedEventHandler(Operation operation)
        {
            _operation = operation;
            UpdateReadOnlyProperties();
        }

        private void EncryptDecryptEventHandler()
        {
            try
            {
                if (_operation == Operation.Encryption)
                    _encryptor.Encrypt(TextToEncrypt, _algorithmType);

                if (_operation == Operation.Decryption)
                    _decreptor.Decrept(TextToDecrypt, _algorithmType);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void ClearTextEventHandler()
        {
            if (_operation == Operation.Encryption)
                TextToEncrypt = "";

            if (_operation == Operation.Decryption)
                TextToDecrypt = "";
        }
    }
}
