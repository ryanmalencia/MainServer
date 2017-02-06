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

        [Route("api/sportevent/addonegoing/{id}")]
        [HttpPut]
        public void AddOneGoing(int id)
        {
            SportEventLogic.AddOneGoing(id);
        }

        [Route("api/sportevent/minusonegoing/{id}")]
        [HttpPut]
        public void MinusOneGoing(int id)
        {
            SportEventLogic.MinusOneGoing(id);
        }
    }
}