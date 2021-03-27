using System;

using AesRijndaelLibrary;

using Prism.Events;

namespace AesRijndael.Core
{
    public class ClearTextEvent : PubSubEvent { }
    public class FormatTextEvent : PubSubEvent { }
    public class EncryptDecryptEvent : PubSubEvent { }
    public class OperationChangedEvent : PubSubEvent<Operation>    { }
    public class AlgorithmKindChangedEvent : PubSubEvent<AesKeyBase> { }
    public class KeyValueChangedEvent : PubSubEvent<string> { }

    public enum Operation
    {
        Encryption,
        Decryption,
    }
}