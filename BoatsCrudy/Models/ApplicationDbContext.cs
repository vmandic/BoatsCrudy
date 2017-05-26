using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using BoatsCrudy.Models.Entities;

namespace BoatsCrudy.Models
{
  public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
  {
    public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false) { }

    public static ApplicationDbContext Create()
    {
      return new ApplicationDbContext();
    }

    public IDbSet<Boat> Boats { get; set; }
    public IDbSet<Trip> Trips { get; set; }
    public IDbSet<BoatOwner> BoatOwners { get; set; }

    protected override void OnModelCreating(DbModelBuilder mb)
    {
      mb.Conventions.Remove<OneToManyCascadeDeleteConvention>();
      mb.Conventions.Remove<PluralizingTableNameConvention>();

      base.OnModelCreating(mb);
    }
  }
}