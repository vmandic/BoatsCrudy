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
  public class BoatOwnersController : Controller
  {
    private ApplicationDbContext Db { get { return HttpContext.GetOwinContext().Get<ApplicationDbContext>(); } }

    // GET: BoatOwners
    public ActionResult Index()
    {
      return View(Db.BoatOwners.ToList());
    }

    // GET: BoatOwners/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      BoatOwner boatOwner = Db.BoatOwners.Find(id);
      if (boatOwner == null)
      {
        return HttpNotFound();
      }
      return View(boatOwner);
    }

    // GET: BoatOwners/Create
    public ActionResult Create()
    {
      return View(new BoatOwner());
    }

    // POST: BoatOwners/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "Id,Firstname,Lastname,Email")] BoatOwner boatOwner)
    {
      if (ModelState.IsValid)
      {
        Db.BoatOwners.Add(boatOwner);
        Db.SaveChanges();
        return RedirectToAction("Index");
      }

      return View(boatOwner);
    }

    // GET: BoatOwners/Edit/5
    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      BoatOwner boatOwner = Db.BoatOwners.Find(id);
      if (boatOwner == null)
      {
        return HttpNotFound();
      }
      return View(boatOwner);
    }

    // POST: BoatOwners/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "Id,Firstname,Lastname,Email")] BoatOwner boatOwner)
    {
      if (ModelState.IsValid)
      {
        Db.Entry(boatOwner).State = EntityState.Modified;
        Db.SaveChanges();
        return RedirectToAction("Index");
      }
      return View(boatOwner);
    }

    // GET: BoatOwners/Delete/5
    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      BoatOwner boatOwner = Db.BoatOwners.Find(id);
      if (boatOwner == null)
      {
        return HttpNotFound();
      }
      return View(boatOwner);
    }

    // POST: BoatOwners/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      BoatOwner boatOwner = Db.BoatOwners.Find(id);
      Db.BoatOwners.Remove(boatOwner);
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
