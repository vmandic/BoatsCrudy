using System.Collections.Generic;

namespace BoatsCrudy.Models.Entities
{
  public class BoatOwner
  {
    public BoatOwner()
    {
      this.OwnedBoats = new List<Boat>();
    }

    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    
    public ICollection<Boat> OwnedBoats { get; set; }

    public string GetFullname()
    {
      return this.Firstname + " " + this.Lastname;
    }
  }
}