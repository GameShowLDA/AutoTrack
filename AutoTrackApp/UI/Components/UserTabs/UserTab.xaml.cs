using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutoTrackApp.UI.Components.UserTabs
{
  /// <summary>
  /// Логика взаимодействия для UserTab.xaml
  /// </summary>
  public partial class UserTab : UserControl
  {
    public UserTab()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Имя пользователя для отображения на вкладке.
    /// </summary>
    public static readonly DependencyProperty UserNameProperty =
        DependencyProperty.Register(nameof(UserName), typeof(string), typeof(UserTab), new PropertyMetadata(string.Empty));

    public string UserName
    {
      get => (string)GetValue(UserNameProperty);
      set => SetValue(UserNameProperty, value);
    }

    /// <summary>
    /// Флаг выделения вкладки.
    /// </summary>
    public static readonly DependencyProperty IsSelectedProperty =
        DependencyProperty.Register(nameof(IsSelected), typeof(bool), typeof(UserTab), new PropertyMetadata(false));

    public bool IsSelected
    {
      get => (bool)GetValue(IsSelectedProperty);
      set => SetValue(IsSelectedProperty, value);
    }
  }
}
