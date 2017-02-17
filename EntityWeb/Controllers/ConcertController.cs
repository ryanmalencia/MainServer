using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using DataTypes;
using EntityWeb.Logic;

namespace ConsoleWebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class ConcertController : ApiController
    {
        private ConcertLogic ConcertLogic = new ConcertLogic();
        [Route("api/concert/add")]
        [HttpPut]
        public void Add(Concert concert)
        {
            ConcertLogic.Add(concert);
        }

        [Route("api/concert/getfutureconcerts/")]
        [HttpGet]
        public IHttpActionResult GetFutureConcerts()
        {
            return Ok(JsonConvert.SerializeObject(ConcertLogic.GetFutureConcerts()));
        }

        [Route("api/concert/getfutureconcerts/{index}")]
        [HttpGet]
        public IHttpActionResult GetFutureConcerts(int index)
        {
            return Ok(JsonConvert.SerializeObject(ConcertLogic.GetFutureConcerts(index)));
        }

        [Route("api/concert/addonegoing/{id}/{user}")]
        [HttpPut]
        public void AddOneGoing(int id, int user)
        {
            ConcertLogic.AddOneGoing(id, user);
        }

        [Route("api/concert/minusonegoing/{id}/{user}")]
        [HttpPut]
        public void MinusOneGoing(int id, int user)
        {
            ConcertLogic.MinusOneGoing(id, user);
        }

        [Route("api/concert/getattendstatus/{id}/{user}")]
        [HttpGet]
        public IHttpActionResult GetAttendStatus(int id, int user)
        {
            return Ok(JsonConvert.SerializeObject(ConcertLogic.GetAttendStatus(id, user)));
        }
    }
}