using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AesRijndael.Core;

namespace AesRijndael.MainModule.ViewModels
{
    public class TextViewModel : BaseViewModel
    {
        public bool IsEncryptionReadOnly { get; set; }
        public bool IsDecryptionReadOnly { get; set; }

    }
}
