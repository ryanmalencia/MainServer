using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using EntityWeb.Logic;

namespace EntityWeb.Controllers
{
    [EnableCors("*", "*", "*")]
    public class PrintController : ApiController
    {
        private PrintLogic PrintLogic = new PrintLogic();
        [Route("api/print/getallprintlocations")]
        [HttpGet]
        public IHttpActionResult GetAllPrintLocations()
        {
            return Ok(JsonConvert.SerializeObject(PrintLogic.GetAllPrintLocations()));
        }
    }
}