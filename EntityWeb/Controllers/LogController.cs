using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using DataTypes;
using EntityWeb.Logic;

namespace EntityWeb.Controllers
{
    [EnableCors("*", "*", "*")]
    public class LogController : ApiController
    {
        private LogLogic LogLogic = new LogLogic();

        [Route("api/log/add/")]
        [HttpPut]
        public void Put(Log log)
        {
            LogLogic.Add(log);
        }

        [Route("api/log/getlogsbyagent/{name}")]
        [HttpGet]
        public IHttpActionResult GetLogsByAgent(string name)
        {
            return Ok(JsonConvert.SerializeObject(LogLogic.GetByAgent(name)));
        }
    }
}