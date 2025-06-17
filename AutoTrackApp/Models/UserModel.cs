using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoTrackApp.Models
{
  public class UserModel : INotifyPropertyChanged
  {
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Patronymic { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;

    public List<CarModel> UserCars { get; set; } = new();

    [NotMapped]
    public string FullName => $"{LastName} {FirstName} {Patronymic}".Trim();

    [NotMapped]
    public string Initials
    {
      get
      {
        string initials = "";
        if (!string.IsNullOrWhiteSpace(LastName))
          initials += LastName[0];
        if (!string.IsNullOrWhiteSpace(FirstName))
          initials += FirstName[0];
        return initials.ToUpper();
      }
    }

    private CarModel? _selectedCar;

    [NotMapped]
    public CarModel? SelectedCar
    {
      get => _selectedCar;
      set
      {
        _selectedCar = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedCar)));
      }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
  }
}
