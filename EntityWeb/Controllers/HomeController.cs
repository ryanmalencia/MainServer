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
            ViewBag.Message = null;
            return View();
        }

        public ActionResult Jobs(string message)
        {
            if(message.Equals("Success"))
            {
                ViewBag.Message = "File uploaded";
            }
            else
            {
                ViewBag.Error = "Only zip files are allowed";
            }
            return View();
        }

        public ActionResult JobStatus()
        {
            return View();
        }
    }
}