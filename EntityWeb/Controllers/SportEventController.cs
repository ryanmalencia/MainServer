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

        [Route("api/sportevent/getfutureevents/")]
        [HttpGet]
        public IHttpActionResult GetClosestEvents()
        {
            return Ok(JsonConvert.SerializeObject(SportEventLogic.GetFutureEvents()));
        }

        [Route("api/sportevent/getfutureevents/{index}")]
        [HttpGet]
        public IHttpActionResult GetClosestEvents(int index)
        {
            return Ok(JsonConvert.SerializeObject(SportEventLogic.GetFutureEvents(index)));
        }

        [Route("api/sportevent/getfutureuserevents/{UserID}/{index}")]
        [HttpGet]
        public IHttpActionResult GetFutureUserEvents(int UserID, int index)
        {
            return Ok(JsonConvert.SerializeObject(SportEventLogic.GetFutureUserEvents(UserID,index)));
        }

        [Route("api/sportevent/addonegoing/{id}/{user}")]
        [HttpPut]
        public void AddOneGoing(int id, int user)
        {
            SportEventLogic.AddOneGoing(id, user);
        }

        [Route("api/sportevent/minusonegoing/{id}/{user}")]
        [HttpPut]
        public void MinusOneGoing(int id, int user)
        {
            SportEventLogic.MinusOneGoing(id, user);
        }

        [Route("api/sportevent/getattendstatus/{id}/{user}")]
        [HttpGet]
        public IHttpActionResult GetAttendStatus(int id, int user)
        {
            return Ok(JsonConvert.SerializeObject(SportEventLogic.GetAttendStatus(id, user)));
        }

        [Route("api/sportevent/getnexthourevents/{type}")]
        [HttpGet]
        public IHttpActionResult GetNextHourEvents(string type)
        {
            return Ok(JsonConvert.SerializeObject(SportEventLogic.GetNextHourEvents(type)));
        }

        [Route("api/sportevent/getsporttypes")]
        [HttpGet]
        public IHttpActionResult GetSportTypes()
        {
            return Ok(JsonConvert.SerializeObject(SportEventLogic.GetSportTypes()));
        }
    }
}