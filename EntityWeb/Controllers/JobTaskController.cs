using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using EntityWeb.Logic;

namespace ConsoleWebAPI.Controllers
{
    [EnableCors("*","*","*")]
    public class JobTaskController : ApiController
    {
        private JobTaskLogic JobTaskLogic = new JobTaskLogic();
        [Route("api/jobtask/getbygroup/{group}")]
        [HttpGet]
        public IHttpActionResult GetByGroup(int group)
        {
            return Ok(JsonConvert.SerializeObject(JobTaskLogic.GetByGroup(group)));
        }
    }
}
