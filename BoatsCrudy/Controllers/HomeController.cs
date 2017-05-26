using System.Web.Mvc;

namespace BoatsCrudy.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }

    public ActionResult About()
    {
      ViewBag.Message = "Boats manager.";

      return View();
    }
  }
}