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
    }
}