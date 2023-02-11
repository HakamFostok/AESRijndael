using System.ComponentModel;
using System.Globalization;
using System.Resources;
using System.Windows.Data;

using AesRijndael.MainModule.i18n;

namespace AesRijndael.MainModule;

public class LocalizationExtension : Binding
{
    public LocalizationExtension(string name)
        : base("[" + name + "]")
    {
        Mode = BindingMode.OneWay;
        Source = TranslationSource.Instance;
    }
}

public class TranslationSource : INotifyPropertyChanged
{
    private static readonly TranslationSource instance = new();

    public static TranslationSource Instance => instance;

    private readonly ResourceManager resManager = Lang.ResourceManager;
    private CultureInfo currentCulture = null;

    public string this[string key] =>
        resManager.GetString(key, currentCulture);

    public CultureInfo CurrentCulture
    {
        get => currentCulture;
        set
        {
            if (currentCulture != value)
            {
                currentCulture = value;
                PropertyChangedEventHandler @event = this.PropertyChanged;
                if (@event != null)
                {
                    @event.Invoke(this, new PropertyChangedEventArgs(string.Empty));
                }
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
}
