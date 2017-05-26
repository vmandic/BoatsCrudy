using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BoatsCrudy.Models.Entities
{
  public class Boat
  {
    public Boat()
    {
      this.BookedTrips = new List<Trip>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    [Display(Name = "Number of passengers")]
    public short PassengerCapacity { get; set; }
    [Display(Name = "Needs a skipper?")]
    public bool IsSkipperRequired { get; set; }

    [Display(Name = "Year of production")]
    public bool ProductionYear { get; set; }
    public byte[] ProfileImage { get; set; }

    public int BoatOwnerId { get; set; }

    public BoatOwner BoatOwner { get; set; }

    public ICollection<Trip> BookedTrips { get; set; }
  }
}