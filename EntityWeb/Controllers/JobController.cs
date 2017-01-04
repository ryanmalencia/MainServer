using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using EntityWeb.Logic;
using DataTypes;

namespace ConsoleWebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class JobController : ApiController
    {
        private JobLogic JobLogic = new JobLogic();
        [Route("api/job/getalljobs")]
        [HttpGet]
        public IHttpActionResult GetAllJobs()
        {
            return Ok(JsonConvert.SerializeObject(JobLogic.GetAllJobs()));
        }

        [Route("api/job/getbyid/{id}")]
        [HttpGet]
        public IHttpActionResult GetJobById(int id)
        {
            return Ok(JsonConvert.SerializeObject(JobLogic.GetJobById(id)));
        }

        [Route("api/job/setdist")]
        [HttpPut]
        public void PutDist(Job job)
        {
            JobLogic.PutDist(job);
        }

        [Route("api/job/setstarted")]
        [HttpPut]
        public void PutStarted(Job job)
        {
            JobLogic.PutStarted(job);
        }

        [Route("api/job/setfinished")]
        [HttpPut]
        public void PutFinished(Job job)
        {
            JobLogic.PutFinished(job);
        }

        [Route("api/job/reset")]
        [HttpPut]
        public void PutReset(Job job)
        {
            JobLogic.PutReset(job);
        }
    }
}
