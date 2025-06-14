using AutoTrackApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrackApp.Events
{
  /// <summary>
  /// Класс для событий управления пользователями: создание, удаление, изменение.
  /// </summary>
  public class UserEvents
  {
    /// <summary>
    /// Событие создания нового пользователя.
    /// </summary>
    public event EventHandler<UserModel>? UserCreated;

    /// <summary>
    /// Событие удаления пользователя.
    /// </summary>
    public event EventHandler<UserModel>? UserDeleted;

    /// <summary>
    /// Событие изменения данных пользователя.
    /// </summary>
    public event EventHandler<UserModel>? UserUpdated;

    public void RaiseUserCreated(UserModel user) => UserCreated?.Invoke(this, user);

    public void RaiseUserDeleted(UserModel user) => UserDeleted?.Invoke(this, user);

    public void RaiseUserUpdated(UserModel user) => UserUpdated?.Invoke(this, user);
  }
}
