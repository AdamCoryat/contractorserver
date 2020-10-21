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
    public Skills Skills { get; set; }
    public string CreatorId { get; set; }
    public Profile Creator { get; set; }
  }
  public enum Skills
    {
      Electrical,
      HVAC,
      DryWall,
      Plumbing,
      Siding,
      Roofing
    }
}