using System;
using System.Globalization;
using System.Windows.Data;

namespace AutoTrackApp.Converters
{
  /// <summary>
  /// Конвертер, инвертирующий значение типа bool.
  /// </summary>
  public class InverseBooleanConverter : IValueConverter
  {
    /// <summary>
    /// Преобразует bool в противоположное значение.
    /// </summary>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (value is bool b)
        return !b;
      return true;
    }

    /// <summary>
    /// Обратное преобразование (также инвертирует).
    /// </summary>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (value is bool b)
        return !b;
      return false;
    }
  }
}
