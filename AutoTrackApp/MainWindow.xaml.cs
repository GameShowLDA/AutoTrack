using AutoTrackApp.AppConfig;
using AutoTrackApp.DataBase;
using AutoTrackApp.Models;
using AutoTrackApp.UI.Components.UserCard;
using AutoTrackApp.UI.Components.UserTabs;
using AutoTrackApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Windows;

namespace AutoTrackApp
{
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      LoggerUtility.LogInformation("MainWindow запущен");

      DbContextProvider.Instance.Database.Migrate();
      // DataSeeder.SeedTestData();

      // Загрузка пользователей из базы данных
      var users = DbContextProvider.Instance.Users
          .Include(u => u.UserCars)
              .ThenInclude(c => c.Works)
          .ToList();

      // Привязка к ViewModel, если она ожидает список пользователей
      if (UsersList.DataContext is UserTabListViewModel userTabListVM)
      {
        foreach (var user in users)
        {
          UserEventsConfig.UserEvents.RaiseUserCreated(user);
          userTabListVM.PropertyChanged += (s, e) =>
          {
            if (e.PropertyName == nameof(userTabListVM.SelectedUser))
            {
              if (UserProfilePanel is UserProfilePanel panel)
              {
                panel.CancelEditIfNeeded();
              }

              LoggerUtility.LogInformation($"Выбран пользователь: {userTabListVM.SelectedUser?.FullName}");
              UserProfilePanel.DataContext = userTabListVM.SelectedUser;
            }
          };
        }
      }
    }
  }
}
