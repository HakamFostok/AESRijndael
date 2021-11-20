using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AesRijndael.Core;

public static class Extensions
{
    public static ObservableCollection<T> ToObs<T>(this List<T> list) => new ObservableCollection<T>(list);
}
