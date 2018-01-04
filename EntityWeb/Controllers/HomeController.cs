using System.Web.Mvc;

namespace EntityWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

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

        public ActionResult ServerStatus()
        {
            return View();
        }

        public ActionResult AgentStatus()
        {
            return View();
        }

        public ActionResult Jobs()
        {
            return View();
        }

        public ActionResult JobStatus()
        {
            return View();
        }
    }
}