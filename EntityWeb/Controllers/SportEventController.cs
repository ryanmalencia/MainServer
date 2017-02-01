using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using DataTypes;
using EntityWeb.Logic;


namespace EntityWeb.Controllers
{
    [EnableCors("*", "*", "*")]
    public class SportEventController : ApiController
    {
        private SportEventLogic SportEventLogic = new SportEventLogic();
        [Route("api/sportevent/add/")]
        [HttpPut]
        public void AddNewDevice(SportEvent Event)
        {
            SportEventLogic.Add(Event);
        }

        [Route("api/sportevent/getclosestevents/")]
        [HttpGet]
        public IHttpActionResult GetClosestEvents()
        {
            return Ok(JsonConvert.SerializeObject(SportEventLogic.GetClosestEvents()));
        }
    }
}