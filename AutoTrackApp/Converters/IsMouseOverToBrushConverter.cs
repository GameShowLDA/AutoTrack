using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace AutoTrackApp.Converters
{
  public class IsMouseOverToBrushConverter : IMultiValueConverter
  {
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
      if (values.Length == 3 && values[0] is bool isOver && values[1] is Brush normal && values[2] is Brush hover)
        return isOver ? hover : normal;
      return DependencyProperty.UnsetValue;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        => throw new NotImplementedException();
  }
}