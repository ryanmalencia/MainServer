using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using DataTypes;
using EntityWeb.Logic;

namespace ConsoleWebAPI.Controllers
{
    [EnableCors("*","*","*")]
    public class AgentController : ApiController
    {
        private AgentLogic AgentLogic = new AgentLogic();
        [Route("api/agent/getallagents")]
        [HttpGet]
        public IHttpActionResult GetAllMachines()
        {
            return Ok(JsonConvert.SerializeObject(AgentLogic.GetAllAgents()));
        }

        [Route("api/agent/getidleagents")]
        [HttpGet]
        public IHttpActionResult GetIdleAgents()
        {
            return Ok(JsonConvert.SerializeObject(AgentLogic.GetIdleAgents()));
        }

        [Route("api/agent/getagent/{name}")]
        [HttpGet]
        public IHttpActionResult GetOneMachine(string name)
        {
            return Ok(JsonConvert.SerializeObject(AgentLogic.Get(name)));
        }

        [Route("api/agent/add/")]
        [HttpPut]
        public void Put(Agent agent)
        {
            AgentLogic.Add(agent);
        }

        [Route("api/agent/givejob/{agent}/{pk_job}")]
        [HttpPut]
        public void PutRunning(string agent, int pk_job)
        {
            AgentLogic.SetAgentRunning(agent, pk_job);
        }

        [Route("api/agent/setqueued/{agent}")]
        [HttpPut]
        public void PutQueued(string agent)
        {
            AgentLogic.SetAgentQueued(agent);
        }

        [Route("api/agent/setidle/{agent}")]
        [HttpPut]
        public void PutIdle(string agent)
        {
            AgentLogic.SetAgentIdle(agent);
        }

        [Route("api/agent/setdead/{agent}")]
        [HttpPut]
        public void PutDead(string agent)
        {
            AgentLogic.SetAgentDead(agent);
        }

        [Route("api/agent/delete/{agent}")]
        [HttpDelete]
        public void Delete(string agent)
        {
            AgentLogic.Delete(agent);
        }

        [Route("api/agent/update")]
        [HttpPut]
        public void PutUpdate(Agent agent)
        {
            AgentLogic.Update(agent);
        }

        [Route("api/agent/kill/{agent}")]
        [HttpPost]
        public void Kill(string agent)
        {
            AgentLogic.Kill(agent);
        }

        [Route("api/agent/shutdown/{agent}")]
        [HttpPost]
        public void Shutdown(string agent)
        {
            AgentLogic.Shutdown(agent);
        }

        [Route("api/agent/updatehardware/")]
        [HttpPost]
        public void UpdateHardware(Hardware info)
        {
            AgentLogic.UpdateHardware(info);
        }

        [Route("api/agent/updatejob/{info}")]
        [HttpPost]
        public void UpdateJob(string info)
        {
            AgentLogic.UpdateJob(info);
        }
    }
}
