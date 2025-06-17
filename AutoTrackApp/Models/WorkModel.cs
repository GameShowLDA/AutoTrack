using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrackApp.Models
{
  public class WorkModel
  {
    [Key]
    public int Id { get; set; }
    public string Date { get; set; } = string.Empty;
    public string Work { get; set; } = string.Empty;
  }
}
