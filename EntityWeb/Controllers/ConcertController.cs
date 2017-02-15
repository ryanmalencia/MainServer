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
    }
}