using System;

namespace BoatsCrudy.Models.Entities
{
  public class Trip
  {
    public int Id { get; set; }
    public string StartingPort { get; set; }
    public string DestinationPort { get; set; }
    public DateTime StartAt { get; set; }
    public DateTime ArrivalAt { get; set; }
    public short BookedPassengers { get; set; }

    public int BoatId { get; set; }

    public Boat Boat { get; set; }
  }
}