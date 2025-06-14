using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoTrackApp.Models
{
  /// <summary>
  /// Модель автомобиля, принадлежащего пользователю.
  /// </summary>
  public class CarModel
  {
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Марка автомобиля (например, Toyota).
    /// </summary>
    public string Make { get; set; } = string.Empty;

    /// <summary>
    /// Модель автомобиля (например, Corolla).
    /// </summary>
    public string Model { get; set; } = string.Empty;

    /// <summary>
    /// Государственный регистрационный номер.
    /// </summary>
    public string LicensePlate { get; set; } = string.Empty;

    /// <summary>
    /// VIN номер автомобиля.
    /// </summary>
    public string Vin { get; set; } = string.Empty;

    /// <summary>
    /// Внешний ключ — идентификатор владельца.
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Навигационное свойство — владелец.
    /// </summary>
    [ForeignKey("UserId")]
    public UserModel? Owner { get; set; }

    [NotMapped]
    public bool IsHighlighted { get; set; } = false;

    public List<WorkModel> Works { get; set; } = new();
  }
}
