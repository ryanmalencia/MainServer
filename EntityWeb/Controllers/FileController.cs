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
                string dir = file.FileName.Substring(0, file.FileName.LastIndexOf("."));
                string[] temp = file.FileName.Split('.');
                string ext = temp[(temp.Length - 1)];

                if(ext != "zip")
                {
                   
                    return RedirectToAction("Jobs", "Home","Error");
                }

                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data"),dir);
                if(!Directory.Exists(path.ToString()))
                {
                    Directory.CreateDirectory(path.ToString());
                }
                path = Path.Combine(path.ToString(), fileName);
                file.SaveAs(path);
            }
            return RedirectToAction("Jobs", "Home", "Success");
       }
    }
}