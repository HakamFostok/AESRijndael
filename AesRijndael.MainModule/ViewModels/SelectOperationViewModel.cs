using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AesRijndael.Core;

namespace AesRijndael.MainModule.ViewModels
{
    public class SelectOperationViewModel : BaseViewModel
    {
        private bool isEncryptOperation = true;
        public bool IsEncryptOperation
        {
            get => isEncryptOperation;
            set
            {
                SetProperty(ref isEncryptOperation, value);
                if (value is true)
                {
                    _aggregator.GetEvent<OperationChangedEvent>().Publish(Operation.Encryption);
                }
            }
        }

        private bool isDecryptOperation;
        public bool IsDecryptOperation
        {
            get => isDecryptOperation;
            set
            {
                SetProperty(ref isDecryptOperation, value);
                if (value is true)
                {
                    _aggregator.GetEvent<OperationChangedEvent>().Publish(Operation.Decryption);
                }
            }
        }

    }
}
