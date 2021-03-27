using System;

using AesRijndael.Core;

using AesRijndaelLibrary;

namespace AesRijndael.MainModule.ViewModels
{
    public class SelectKeyViewModel : BaseViewModel
    {
        private string keyValue;
        private AesKeyBase algoType;

        private bool isAes128 = true;
        public bool IsAes128
        {
            get => isAes128;
            set
            {
                SetProperty(ref isAes128, value);
                if (value is true && !string.IsNullOrEmpty(keyValue))
                {
                    try
                    {
                        algoType = new AesKey128(keyValue);
                        _aggregator.GetEvent<AlgorithmKindChangedEvent>().Publish(algoType);
                    }
                    catch (Exception ex)
                    {
                        HandleException(ex);
                    }
                }
            }
        }

        private bool isAes192;
        public bool IsAes192
        {
            get => isAes192;
            set
            {
                SetProperty(ref isAes192, value);
                if (value is true && !string.IsNullOrEmpty(keyValue))
                {
                    try
                    {
                        algoType = new AesKey192(keyValue);
                        _aggregator.GetEvent<AlgorithmKindChangedEvent>().Publish(algoType);
                    }
                    catch (Exception ex)
                    {
                        HandleException(ex);
                    }
                }
            }
        }

        private bool isAes256;
        public bool IsAes256
        {
            get => isAes256;
            set
            {
                SetProperty(ref isAes256, value);
                if (value is true && !string.IsNullOrEmpty(keyValue))
                {
                    try
                    {
                        algoType = new AesKey256(keyValue);
                        _aggregator.GetEvent<AlgorithmKindChangedEvent>().Publish(algoType);
                    }
                    catch (Exception ex)
                    {
                        HandleException(ex);
                    }
                }
            }
        }

        public SelectKeyViewModel()
        {
            _aggregator.GetEvent<KeyValueChangedEvent>().Subscribe(KeyValueChangedEventHandler);
        }

        private void KeyValueChangedEventHandler(string key)
        {
            keyValue = key;
        }
    }
}
