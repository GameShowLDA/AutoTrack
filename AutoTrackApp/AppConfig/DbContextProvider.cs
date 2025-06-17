using AutoTrackApp.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrackApp.AppConfig
{
  internal class DbContextProvider
  {
    private static readonly AppDbContext _instance = new AppDbContext();

    public static AppDbContext Instance => _instance;
  }
}
