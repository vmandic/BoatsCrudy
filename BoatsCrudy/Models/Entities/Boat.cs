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

    [Required] // interpreted bothways, i.e. this will count as Entity Framework mapping rule and as MVC model binding rule
    public string Name { get; set; }
    public string Description { get; set; }

    [Required]
    [Display(Name = "Number of passengers")]
    [UIHint("NumberShort")]
    public short PassengerCapacity { get; set; }

    [Display(Name = "Needs a skipper?")]
    public bool IsSkipperRequired { get; set; }

    [Required]
    [Display(Name = "Year of production")]
    [UIHint("NumberShort")]
    public short ProductionYear { get; set; }

    [UIHint("File")]
    [Display(Name = "Image")]
    public byte[] ProfileImage { get; set; }

    [Display(Name = "Boat owner")]
    public int BoatOwnerId { get; set; }

    public BoatOwner BoatOwner { get; set; }

    public ICollection<Trip> BookedTrips { get; set; }
  }
}