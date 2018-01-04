using System.Web.Http.Cors;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace EntityWeb.Controllers
{
    [EnableCors("*", "*", "*")]
    public class FileController : Controller
    {
       [HttpPost]
       public ActionResult Upload(HttpPostedFileBase file)
       {
            if(file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data"),fileName);
                file.SaveAs(path);
            }
            return RedirectToAction("Jobs", "Home");
       }
    }
}