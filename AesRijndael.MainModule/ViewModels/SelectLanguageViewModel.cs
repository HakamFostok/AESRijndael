using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using AesRijndael.Core;

namespace AesRijndael.MainModule.ViewModels
{
    public class SelectLanguageViewModel : BaseViewModel
    {
        private bool isArabic;
        public bool IsArabic
        {
            get => isArabic;
            set
            {
                SetProperty(ref isArabic, value);
                if (value is true)
                {
                    TranslationSource.Instance.CurrentCulture = new System.Globalization.CultureInfo("ar-SY");
                    RaisePropertyChanged("Lang");
                }
            }
        }

        private bool isEnglish = true;
        public bool IsEnglish
        {
            get => isEnglish;
            set
            {
                SetProperty(ref isEnglish, value);
                if (value is true)
                {
                    TranslationSource.Instance.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                    RaisePropertyChanged("Lang");
                }
            }
        }
    }
}
