using System.Web.Mvc;

namespace CatLister.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "AGL Developer Test";
            return View();
        }
    }
}
