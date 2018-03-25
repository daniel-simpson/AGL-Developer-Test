using CatLister.ViewModels;
using System.Web.Mvc;

namespace CatLister.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        public ActionResult Index()
        {
            ViewBag.Title = "AGL Developer Test";

            var model = new HomeViewModel();
            return View(model);
        }
    }
}
