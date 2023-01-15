using System.Web.Mvc;

namespace GlobeFA.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult Module()
        {
            return View("Index");
        }

        public ActionResult Ecorp()
        {
            return View();
        }

        public ActionResult Esecure()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Easset()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View("Index");
        }
    }
}