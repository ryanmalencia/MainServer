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

        [Route("api/location/addprintlocation")]
        [HttpPut]
        public void AddPrintLocations(PrintLocation location)
        {
            LocationLogic.AddPrintLocation(location);
        }

        [Route("api/location/getdininglocations")]
        [HttpGet]
        public IHttpActionResult GetDiningLocations()
        {
            return Ok(JsonConvert.SerializeObject(LocationLogic.GetDiningLocations()));
        }

        [Route("api/location/getdiningcoords")]
        [HttpGet]
        public IHttpActionResult GetDiningCoords()
        {
            return Ok(JsonConvert.SerializeObject(LocationLogic.GetDiningCoords()));
        }

        [Route("api/location/adddininglocation")]
        [HttpPut]
        public void AddDiningLocations(DiningLocation location)
        {
            LocationLogic.AddDiningLocations(location);
        }
    }
}