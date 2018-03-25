using CatLister.Services;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CatLister.Controllers
{
    public class HomeController : Controller
    {
        private IPersonService _personService;

        //Would ordinarily set up IoC for this
        public HomeController()
        {
            var _client = new TestableHttpClient(ConfigurationManager.AppSettings["DataSourceBaseUri"]);
            _personService = new PersonService(_client);
        }
        public HomeController(IPersonService service)
        {
            _personService = service;
        }

        public async Task<ActionResult> Index()
        {
            ViewBag.Title = "AGL Developer Test";

            var model = await _personService.GetCatsByOwnerGenderAsync();
            return View(model);
        }
    }
}
