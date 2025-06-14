using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace AutoTrackApp.Converters
{
  public class SelectedTabBackgroundConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      bool isSelected = value is bool b && b;
      return isSelected
          ? new SolidColorBrush(Color.FromArgb(60, 0, 80, 255)) // светло-синий с прозрачностью
          : Brushes.Transparent;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
