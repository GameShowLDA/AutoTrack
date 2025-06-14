using AutoTrackApp.AppConfig;
using AutoTrackApp.Models;
using AutoTrackApp.UI.Components.UserTabs;
using AutoTrackApp.ViewModels;
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

      var random = new Random();

      string[] firstNames = { "Иван", "Алексей", "Мария", "Дмитрий", "Ольга" };
      string[] lastNames = { "Смирнов", "Иванов", "Кузнецова", "Петров", "Сидорова" };
      string[] carMakes = { "Toyota", "Honda", "Ford", "BMW", "Kia" };
      string[] carModels = { "Corolla", "Civic", "Focus", "X5", "Rio" };

      for (int i = 0; i < 5; i++)
      {
        var user = new UserModel
        {
          FirstName = firstNames[i % firstNames.Length],
          LastName = lastNames[i % lastNames.Length],
          Patronymic = "Александрович",
          DateOfBirth = new DateTime(1990 + i, 1, 15),
          Email = $"user{i + 1}@example.com",
          Phone = $"+7 (900) 000-0{i}0"
        };

        for (int j = 0; j < 5; j++)
        {
          var car = new CarModel
          {
            Make = carMakes[random.Next(carMakes.Length)],
            Model = carModels[random.Next(carModels.Length)],
            LicensePlate = GeneratePlate(random),
            Vin = GenerateVin(random)
          };

          // Добавим 4 случайные работы
          for (int k = 0; k < 4; k++)
          {
            car.Works.Add(new WorkModel
            {
              Date = DateTime.Now.AddDays(-k * 15).ToShortDateString(), // только дата
              Work = $"Работа #{k + 1}: Замена детали {k + 1}"          // только описание
            });
          }

          user.UserCars.Add(car);
        }

        UserEventsConfig.UserEvents.RaiseUserCreated(user);
      }

      if (UsersList.DataContext is UserTabListViewModel userTabListVM)
      {
        userTabListVM.PropertyChanged += (s, e) =>
        {
          if (e.PropertyName == nameof(userTabListVM.SelectedUser))
          {
            LoggerUtility.LogInformation($"Выбран пользователь: {userTabListVM.SelectedUser?.FullName}");
            UserProfilePanel.DataContext = userTabListVM.SelectedUser;
          }
        };
      }
    }

    private string GeneratePlate(Random rand)
    {
      string chars = "АВЕКМНОРСТУХ";
      return $"{chars[rand.Next(chars.Length)]}{chars[rand.Next(chars.Length)]}{chars[rand.Next(chars.Length)]}{rand.Next(100, 999)}";
    }

    private string GenerateVin(Random rand)
    {
      const string vinChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
      char[] vin = new char[17];
      for (int i = 0; i < 17; i++)
        vin[i] = vinChars[rand.Next(vinChars.Length)];
      return new string(vin);
    }
  }
}
