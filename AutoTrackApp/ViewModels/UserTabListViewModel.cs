using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoTrackApp.Models;

namespace AutoTrackApp.ViewModels
{
  public class UserTabListViewModel : INotifyPropertyChanged
  {
    public ObservableCollection<UserModel> Users { get; set; } = new();
    public ObservableCollection<UserModel> FilteredUsers { get; set; } = new();

    private string _searchText;
    public string SearchText
    {
      get => _searchText;
      set
      {
        if (_searchText != value)
        {
          _searchText = value;
          OnPropertyChanged(nameof(SearchText));
          FilterUsers();
        }
      }
    }

    private UserModel? _selectedUser;
    public UserModel? SelectedUser
    {
        get => _selectedUser;
        set
        {
            if (_selectedUser != value)
            {
                _selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }
    }
    public void AddUser(UserModel user)
    {
      Users.Add(user);
      FilterUsers();
    }

    public void RemoveUser(UserModel user)
    {
      Users.Remove(user);
      FilterUsers();
    }

    private void FilterUsers()
    {
      FilteredUsers.Clear();
      foreach (var user in Users.Where(u => string.IsNullOrWhiteSpace(SearchText) || u.FirstName.Contains(SearchText, StringComparison.OrdinalIgnoreCase) || u.LastName.Contains(SearchText, StringComparison.OrdinalIgnoreCase)))
        FilteredUsers.Add(user);
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
  }
}
