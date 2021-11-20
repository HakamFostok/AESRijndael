
using AesRijndael.Core;

namespace AesRijndael.MainModule.ViewModels;

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
