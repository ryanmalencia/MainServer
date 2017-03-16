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

        [Route("api/location/getfitnesscoords")]
        [HttpGet]
        public IHttpActionResult GetFitnessCoords()
        {
            return Ok(JsonConvert.SerializeObject(LocationLogic.GetFitnessCoords()));
        }

        [Route("api/location/addfitnesslocation")]
        [HttpPut]
        public void AddFitnessLocations(FitnessLocation location)
        {
            LocationLogic.AddFitnessLocations(location);
        }

        [Route("api/location/getfitnesslocations")]
        [HttpGet]
        public IHttpActionResult GetFitnessLocations()
        {
            return Ok(JsonConvert.SerializeObject(LocationLogic.GetFitnessLocations()));
        }

        [Route("api/location/getlibrarycoords")]
        [HttpGet]
        public IHttpActionResult GetLibraryCoords()
        {
            return Ok(JsonConvert.SerializeObject(LocationLogic.GetLibraryCoords()));
        }

        [Route("api/location/addlibrarylocation")]
        [HttpPut]
        public void AddLibraryLocations(LibraryLocation location)
        {
            LocationLogic.AddLibraryLocations(location);
        }

        [Route("api/location/getlibrarylocations")]
        [HttpGet]
        public IHttpActionResult GetLibraryLocations()
        {
            return Ok(JsonConvert.SerializeObject(LocationLogic.GetLibraryLocations()));
        }

        [Route("api/location/getcomputercoords")]
        [HttpGet]
        public IHttpActionResult GetComputerCoords()
        {
            return Ok(JsonConvert.SerializeObject(LocationLogic.GetComputerCoords()));
        }

        [Route("api/location/addcomputerlocation")]
        [HttpPut]
        public void AddComputerLocations(ComputerLocation location)
        {
            LocationLogic.AddComputerLocations(location);
        }

        [Route("api/location/getcomputerlocations")]
        [HttpGet]
        public IHttpActionResult GetComputerLocations()
        {
            return Ok(JsonConvert.SerializeObject(LocationLogic.GetComputerLocations()));
        }
    }
}