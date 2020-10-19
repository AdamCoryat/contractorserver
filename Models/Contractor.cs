using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace contractorserver.Models
{
  public class Contractor
  {
    [Required]
    public string Name { get; set; }
    public string Address { get; set; }
    public int ContactPhone { get; set; }
    public int Id { get; set; }
    // public List<Skills> Skills { get => skills; set => skills = value; }
  }
}