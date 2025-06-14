using AutoTrackApp.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrackApp.AppConfig
{
  /// <summary>
  /// Глобальный доступ к событиям пользователей.
  /// </summary>
  public static class UserEventsConfig
  {
    /// <summary>
    /// Глобальный экземпляр событий пользователей.
    /// </summary>
    public static UserEvents UserEvents { get; } = new UserEvents();
  }
}
