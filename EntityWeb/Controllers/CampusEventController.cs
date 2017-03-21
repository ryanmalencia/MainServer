using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using DataTypes;
using EntityWeb.Logic;

namespace ConsoleWebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class CampusEventController : ApiController
    {
        private CampusEventLogic CampusEventLogic = new CampusEventLogic();
        [Route("api/campusevent/geteventsbytype/{type}")]
        [HttpGet]
        public IHttpActionResult GetEventsByType(string type)
        {
            return Ok(JsonConvert.SerializeObject(CampusEventLogic.GetEventsByType(type)));
        }

        [Route("api/campusevent/addevent")]
        [HttpPut]
        public void AddEvent(CampusEvent Event)
        {
            CampusEventLogic.AddEvent(Event);
        }
    }
}