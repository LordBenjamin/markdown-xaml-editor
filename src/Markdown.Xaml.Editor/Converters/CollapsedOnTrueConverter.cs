using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Markdown.Xaml.Editor.Converters {
    public class CollapsedOnTrueConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return object.Equals(value, true) ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
