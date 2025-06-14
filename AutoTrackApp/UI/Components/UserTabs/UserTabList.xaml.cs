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
using AutoTrackApp.AppConfig;
using AutoTrackApp.Models;
using AutoTrackApp.ViewModels;

namespace AutoTrackApp.UI.Components.UserTabs
{
  /// <summary>
  /// Логика взаимодействия для UserTabList.xaml
  /// </summary>
  public partial class UserTabList : UserControl
  {
    private UserTabListViewModel _vm;

    public UserTabList()
    {
      InitializeComponent();
      _vm = new UserTabListViewModel();
      DataContext = _vm;

      UserEventsConfig.UserEvents.UserCreated += OnUserCreated;
      UserEventsConfig.UserEvents.UserDeleted += OnUserDeleted;
    }

    private void OnUserCreated(object? sender, UserModel user)
    {
      _vm.AddUser(user);
    }

    private void OnUserDeleted(object? sender, UserModel user)
    {
      _vm.RemoveUser(user);
    }
  }
}
