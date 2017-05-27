using BoatsCrudy.Models;
using BoatsCrudy.Models.Entities;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BoatsCrudy.Controllers
{
  public class TripsController : Controller
  {
    private ApplicationDbContext Db { get { return HttpContext.GetOwinContext().Get<ApplicationDbContext>(); } }

    // GET: Trips
    public ActionResult Index()
    {
      var trips = Db.Trips.Include(t => t.Boat);
      return View(trips.ToList());
    }

    // GET: Trips/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Trip trip = Db.Trips.Find(id);
      if (trip == null)
      {
        return HttpNotFound();
      }
      return View(trip);
    }

    // GET: Trips/Create
    public ActionResult Create()
    {
      ViewBag.BoatId = new SelectList(Db.Boats, "Id", "Name");
      return View(new Trip());
    }

    // POST: Trips/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "Id,StartingPort,DestinationPort,StartAt,ArrivalAt,BookedPassengers,BoatId")] Trip trip)
    {
      if (ModelState.IsValid)
      {
        Db.Trips.Add(trip);
        Db.SaveChanges();
        return RedirectToAction("Index");
      }

      ViewBag.BoatId = new SelectList(Db.Boats, "Id", "Name", trip.BoatId);
      return View(trip);
    }

    // GET: Trips/Edit/5
    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Trip trip = Db.Trips.Find(id);
      if (trip == null)
      {
        return HttpNotFound();
      }
      ViewBag.BoatId = new SelectList(Db.Boats, "Id", "Name", trip.BoatId);
      return View(trip);
    }

    // POST: Trips/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "Id,StartingPort,DestinationPort,StartAt,ArrivalAt,BookedPassengers,BoatId")] Trip trip)
    {
      if (ModelState.IsValid)
      {
        Db.Entry(trip).State = EntityState.Modified;
        Db.SaveChanges();
        return RedirectToAction("Index");
      }
      ViewBag.BoatId = new SelectList(Db.Boats, "Id", "Name", trip.BoatId);
      return View(trip);
    }

    // GET: Trips/Delete/5
    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Trip trip = Db.Trips.Find(id);
      if (trip == null)
      {
        return HttpNotFound();
      }
      return View(trip);
    }

    // POST: Trips/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      Trip trip = Db.Trips.Find(id);
      Db.Trips.Remove(trip);
      Db.SaveChanges();
      return RedirectToAction("Index");
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        Db.Dispose();
      }
      base.Dispose(disposing);
    }
  }
}
