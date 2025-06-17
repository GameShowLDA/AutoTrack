using AutoTrackApp.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace AutoTrackApp.DataBase
{
  public class AppDbContext : DbContext
  {
    public DbSet<UserModel> Users { get; set; }
    public DbSet<CarModel> Cars { get; set; }
    public DbSet<WorkModel> Works { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite("Data Source=AutoTrackApp.db");
    }
  }
}
