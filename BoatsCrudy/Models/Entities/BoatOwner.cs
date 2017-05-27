using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BoatsCrudy.Models.Entities
{
  public class BoatOwner
  {
    public BoatOwner()
    {
      this.OwnedBoats = new List<Boat>();
    }

    public int Id { get; set; }
    [Required]
    [Display(Name = "First name")]
    public string Firstname { get; set; }
    [Required]
    [Display(Name = "Last name")]
    public string Lastname { get; set; }
    [Required]
    [EmailAddress]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    
    public ICollection<Boat> OwnedBoats { get; set; }

    public string GetFullname()
    {
      return this.Firstname + " " + this.Lastname;
    }
  }
}