using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using EntityWeb.Logic;
using DataTypes;

namespace ConsoleWebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class PoolController : ApiController
    {
        private PoolLogic PoolLogic = new PoolLogic();
        [Route("api/pool/getallpools")]
        [HttpGet]
        public IHttpActionResult GetAllPools()
        {
            return Ok(JsonConvert.SerializeObject(PoolLogic.GetAllPools()));
        }

        [Route("api/pool/getpoolbyname/{PoolName}")]
        [HttpGet]
        public IHttpActionResult GetPoolByName(string PoolName)
        {
            return Ok(JsonConvert.SerializeObject(PoolLogic.GetPoolByName(PoolName)));
        }

        [Route("api/pool/getpoolbyid/{id}")]
        [HttpGet]
        public IHttpActionResult GetPoolById(int id)
        {
            return Ok(JsonConvert.SerializeObject(PoolLogic.GetPoolById(id)));
        }

        [Route("api/pool/add/{Pool}")]
        [HttpPut]
        public void Add(Pool Pool)
        {
            PoolLogic.Add(Pool);
        }
    }
}
