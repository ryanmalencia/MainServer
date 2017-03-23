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

        [Route("api/campusevent/getfutureevents/{type}/{index}")]
        [HttpGet]
        public IHttpActionResult GetFutureEvents(string type,int index)
        {
            return Ok(JsonConvert.SerializeObject(CampusEventLogic.GetFutureEvents(type,index)));
        }

        [Route("api/campusevent/getallevents")]
        [HttpGet]
        public IHttpActionResult GetAllEvents()
        {
            return Ok(JsonConvert.SerializeObject(CampusEventLogic.GetAllEvents()));
        }

        [Route("api/campusevent/updateeventdate")]
        [HttpPut]
        public void UpdateEventDate(CampusEvent Event)
        {
            CampusEventLogic.UpdateEventDate(Event);
        }

        [Route("api/campusevent/getnexthourevents/{type}")]
        [HttpGet]
        public IHttpActionResult GetNextHourEvents(string type)
        {
            return Ok(JsonConvert.SerializeObject(CampusEventLogic.GetNextHourEvents(type)));
        }

        [Route("api/campusevent/getcampuseventtypes")]
        [HttpGet]
        public IHttpActionResult GetCampusEventTypes()
        {
            return Ok(JsonConvert.SerializeObject(CampusEventLogic.GetCampusEventTypes()));
        }
    }
}