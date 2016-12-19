using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using DBInteraction;
using DataTypes;
using EntityWeb.DBInteraction;

namespace ConsoleWebAPI.Controllers
{
    [EnableCors("*","*","*")]
    public class AgentController : ApiController
    {
        private AgentDBInteraction dbinteration = new AgentDBInteraction();

        [Route("api/agent/getallagents")]
        [HttpGet]
        public IHttpActionResult GetAllMachines()
        {
            return Ok(JsonConvert.SerializeObject(dbinteration.GetAllAgents()));
        }

        [Route("api/agent/getidleagents")]
        [HttpGet]
        public IHttpActionResult GetIdleMachines()
        {
            return Ok(JsonConvert.SerializeObject(AgentInteraction.GetIdleAgents()));
        }

        [Route("api/agent/getagent/{name}")]
        [HttpGet]
        public IHttpActionResult GetOneMachine(string name)
        {
            return Ok(JsonConvert.SerializeObject(AgentInteraction.Get(name)));
        }

        [Route("api/agent/add/")]
        [HttpPut]
        public void Put(Agent agent)
        {
            dbinteration.Add(agent);
        }

        [Route("api/agent/givejob/{agent}/{pk_job}")]
        [HttpPut]
        public void PutRunning(string agent, int pk_job)
        {
            AgentInteraction.SetAgentRunning(agent, pk_job);
        }

        [Route("api/agent/setqueued/{agent}")]
        [HttpPut]
        public void PutQueued(string agent)
        {
            AgentInteraction.SetAgentQueued(agent);
        }

        [Route("api/agent/setidle/{agent}")]
        [HttpPut]
        public void PutIdle(string agent)
        {
            AgentInteraction.SetAgentIdle(agent);
        }

        [Route("api/agent/setdead/{agent}")]
        [HttpPut]
        public void PutDead(string agent)
        {
            AgentInteraction.SetAgentDead(agent);
        }

        [Route("api/agent/delete/{name}")]
        [HttpDelete]
        public void Delete(string name)
        {
            AgentInteraction.Delete(name);
        }

        [Route("api/agent/updateip/")]
        [HttpPut]
        public void PutIP(Agent agent)
        {
            //AgentInteraction.UpdateIP(agent);
        }
    }
}
