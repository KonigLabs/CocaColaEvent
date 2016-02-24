using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace KonigLabs.CocaColaEvent.View.Convertrs
{
    public class ComputedHorizontalVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            var visibility = Visibility.Collapsed;
            if (value == null || value == DependencyProperty.UnsetValue || !(value is double))
                return visibility;
            //todo Application.Current.MainWindow.ActualWidth*2 костыль, вычеслить реальную ширину
            return (double)value < Application.Current.MainWindow.ActualWidth*2 ? visibility : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
