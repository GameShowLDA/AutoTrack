using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AutoTrackApp.Models;
using System.Linq;

namespace AutoTrackApp.UI.Components.UserCard
{
  public partial class UserCard : UserControl
  {
    public UserCard()
    {
      InitializeComponent();
      IsEditMode = false;
      this.DataContextChanged += UserCard_DataContextChanged;
    }

    private UserModel? _originalModel;
    private UserModel? _editableCopy;

    public static readonly DependencyProperty IsEditModeProperty =
        DependencyProperty.Register(nameof(IsEditMode), typeof(bool), typeof(UserCard), new PropertyMetadata(false));

    public bool IsEditMode
    {
      get => (bool)GetValue(IsEditModeProperty);
      set => SetValue(IsEditModeProperty, value);
    }

    private void UserCard_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
      if (e.NewValue is UserModel user)
      {
        _originalModel = user;
        _editableCopy = CloneUser(user);
        UserCardRoot.DataContext = _editableCopy;
        IsEditMode = false;
        SetEditModeUI(false);
      }
    }

    private UserModel CloneUser(UserModel user)
    {
      return new UserModel
      {
        Id = user.Id,
        FirstName = user.FirstName,
        LastName = user.LastName,
        Patronymic = user.Patronymic,
        Email = user.Email,
        Phone = user.Phone,
        DateOfBirth = user.DateOfBirth,
        UserCars = user.UserCars.ToList()
      };
    }

    private void SetEditModeUI(bool isEditing)
    {
      Edit.Visibility = isEditing ? Visibility.Collapsed : Visibility.Visible;
      SaveButton.Visibility = CancelButton.Visibility = isEditing ? Visibility.Visible : Visibility.Collapsed;
    }

    private void EditIcon_MouseDown(object sender, MouseButtonEventArgs e)
    {
      IsEditMode = true;
      SetEditModeUI(true);
    }

    private void CancelButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
      CancelEdit();
    }

    private void SaveButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
      ApplyChanges();
    }

    public void CancelEdit()
    {
      if (!IsEditMode || _originalModel == null) return;

      _editableCopy = CloneUser(_originalModel);
      UserCardRoot.DataContext = _editableCopy;

      IsEditMode = false;
      SetEditModeUI(false);
    }

    public void ApplyChanges()
    {
      if (!IsEditMode || _editableCopy == null || _originalModel == null) return;

      _originalModel.FirstName = _editableCopy.FirstName;
      _originalModel.LastName = _editableCopy.LastName;
      _originalModel.Patronymic = _editableCopy.Patronymic;
      _originalModel.Email = _editableCopy.Email;
      _originalModel.Phone = _editableCopy.Phone;
      _originalModel.DateOfBirth = _editableCopy.DateOfBirth;

      IsEditMode = false;
      SetEditModeUI(false);
    }
  }
}
