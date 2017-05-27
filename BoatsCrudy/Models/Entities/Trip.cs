using System;
using System.ComponentModel.DataAnnotations;

namespace BoatsCrudy.Models.Entities
{
  public class Trip
  {
    public int Id { get; set; }
    [Required]
    [Display(Name = "Starting port")]
    public string StartingPort { get; set; }
    [Required]
    [Display(Name = "Destination port")]
    public string DestinationPort { get; set; }
    [Required]
    [DataType(DataType.DateTime)]
    [Display(Name = "Start time")]
    public DateTime StartAt { get; set; }
    [Required]
    [DataType(DataType.DateTime)]
    [Display(Name = "Arrival time")]
    public DateTime ArrivalAt { get; set; }
    [Required]
    [Display(Name = "Number of passengers booked")]
    [UIHint("NumberShort")]
    public short BookedPassengers { get; set; }
    [Display(Name = "Boat")]
    public int BoatId { get; set; }

    public Boat Boat { get; set; }
  }
}