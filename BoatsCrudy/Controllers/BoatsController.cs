using BoatsCrudy.Models;
using BoatsCrudy.Models.Entities;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BoatsCrudy.Controllers
{
  [Authorize]
  public class BoatsController : Controller
  {
    private ApplicationDbContext Db { get { return HttpContext.GetOwinContext().Get<ApplicationDbContext>(); } }

    // GET: Boats
    public async Task<ActionResult> Index()
    {
      var boats = Db.Boats.Include(b => b.BoatOwner);
      return View(await boats.ToListAsync());
    }

    // GET: Boats/Details/5
    public async Task<ActionResult> Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }

      Boat boat = await Db.Boats.FirstOrDefaultAsync(x => x.Id == id);

      if (boat == null)
      {
        return HttpNotFound();
      }

      return View(boat);
    }

    // GET: Boats/Create
    public ActionResult Create()
    {
      ViewBag.BoatOwnerId = new SelectList(Db.BoatOwners, "Id", "Firstname");
      return View(new Boat());
    }

    // POST: Boats/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create([Bind(Include = "Id,Name,Description,PassengerCapacity,IsSkipperRequired,ProductionYear,ProfileImage,BoatOwnerId")] Boat boat)
    {
      if (ModelState.IsValid)
      {
        Db.Boats.Add(boat);
        await Db.SaveChangesAsync();
        return RedirectToAction("Index");
      }

      ViewBag.BoatOwnerId = new SelectList(Db.BoatOwners, "Id", "Firstname", boat.BoatOwnerId);
      return View(boat);
    }

    // GET: Boats/Edit/5
    public async Task<ActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }

      Boat boat = await Db.Boats.FirstOrDefaultAsync(x => x.Id == id);

      if (boat == null)
      {
        return HttpNotFound();
      }

      ViewBag.BoatOwnerId = new SelectList(Db.BoatOwners, "Id", "Firstname", boat.BoatOwnerId);
      return View(boat);
    }

    // POST: Boats/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Description,PassengerCapacity,IsSkipperRequired,ProductionYear,ProfileImage,BoatOwnerId")] Boat boat)
    {
      if (ModelState.IsValid)
      {
        Db.Entry(boat).State = EntityState.Modified;
        await Db.SaveChangesAsync();
        return RedirectToAction("Index");
      }

      ViewBag.BoatOwnerId = new SelectList(Db.BoatOwners, "Id", "Firstname", boat.BoatOwnerId);
      return View(boat);
    }

    // GET: Boats/Delete/5
    public async Task<ActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }

      Boat boat = await Db.Boats.FirstOrDefaultAsync(x => x.Id == id);

      if (boat == null)
      {
        return HttpNotFound();
      }
      return View(boat);
    }

    // POST: Boats/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> DeleteConfirmed(int id)
    {
      Boat boat = await Db.Boats.FirstOrDefaultAsync(x => x.Id == id);

      Db.Boats.Remove(boat);
      await Db.SaveChangesAsync();

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
