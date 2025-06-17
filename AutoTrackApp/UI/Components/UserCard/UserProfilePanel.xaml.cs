using AutoTrackApp.Models;
using AutoTrackApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace AutoTrackApp.UI.Components.UserCard
{
  /// <summary>
  /// Логика взаимодействия для UserProfilePanel.xaml
  /// </summary>
  public partial class UserProfilePanel : UserControl
  {
    public UserProfilePanel()
    {
      InitializeComponent();

      DataContextChanged += (_, _) =>
      {
        if (DataContext is UserModel user)
        {
          user.PropertyChanged += (_, e) =>
          {
            if (e.PropertyName == nameof(user.SelectedCar))
            {
              LoggerUtility.LogInformation($"Выбран автомобиль: {user.SelectedCar?.Make} {user.SelectedCar?.Model}");
              UserWorksPanel.DataContext = user.SelectedCar;
            }
          };
        }
      };
    }

    public void CancelEditIfNeeded()
    {
      if (UserCardPanel.IsEditMode)
      {
        UserCardPanel.CancelEdit();
      }
    }
  }
}
