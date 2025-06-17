using AutoTrackApp.Models;
using AutoTrackApp.AppConfig;
using System;

namespace AutoTrackApp.DataBase
{
  public static class DataSeeder
  {
    public static void SeedTestData()
    {
      var db = DbContextProvider.Instance;
      var random = new Random();

      string[] firstNames = { "Иван", "Алексей", "Мария", "Дмитрий", "Ольга" };
      string[] lastNames = { "Смирнов", "Иванов", "Кузнецова", "Петров", "Сидорова" };
      string[] carMakes = { "Toyota", "Honda", "Ford", "BMW", "Kia" };
      string[] carModels = { "Corolla", "Civic", "Focus", "X5", "Rio" };

      for (int i = 0; i < 10; i++)
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

        for (int j = 0; j < 10; j++)
        {
          var car = new CarModel
          {
            Make = carMakes[random.Next(carMakes.Length)],
            Model = carModels[random.Next(carModels.Length)],
            LicensePlate = $"A{random.Next(1000, 9999)}BC",
            Vin = GenerateVin(random)
          };

          for (int k = 0; k < 10; k++)
          {
            car.Works.Add(new WorkModel
            {
              Date = DateTime.Now.AddDays(-k * 10).ToShortDateString(),
              Work = $"Работа #{k + 1}: Замена детали {k + 1}"
            });
          }

          user.UserCars.Add(car);
        }

        db.Users.Add(user);
      }

      db.SaveChanges();
    }

    private static string GenerateVin(Random rand)
    {
      const string vinChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
      char[] vin = new char[17];
      for (int i = 0; i < 17; i++)
        vin[i] = vinChars[rand.Next(vinChars.Length)];
      return new string(vin);
    }
  }
}