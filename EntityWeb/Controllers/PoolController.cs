using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using DBInteraction;
using EntityWeb.Logic;

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
            //string temp = JsonConvert.SerializeObject(AgentInteraction.Get());
            return Ok(JsonConvert.SerializeObject(PoolLogic.GetAllPools()));
        }
    }
}
