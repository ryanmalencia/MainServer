using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using EntityWeb.Logic;

namespace ConsoleWebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class OSController : ApiController
    {
        private OSLogic OSLogic = new OSLogic();
        [Route("api/os/getallos")]
        [HttpGet]
        public IHttpActionResult GetAllOSes()
        {
            return Ok(JsonConvert.SerializeObject(OSLogic.GetAllOSes()));
        }
    }
}
