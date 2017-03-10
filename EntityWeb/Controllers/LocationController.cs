using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using DataTypes;
using EntityWeb.Logic;

namespace ConsoleWebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class LocationController : ApiController
    {
        private LocationLogic LocationLogic = new LocationLogic();
        [Route("api/location/getprintlocations")]
        [HttpGet]
        public IHttpActionResult GetPrintLocations()
        {
            return Ok(JsonConvert.SerializeObject(LocationLogic.GetPrintLocations()));
        }
    }
}