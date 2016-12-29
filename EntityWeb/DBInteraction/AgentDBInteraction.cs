using EntityWeb.DAL;
using DataTypes;
using System.Linq;
using DBInteraction;

namespace EntityWeb.DBInteraction
{
    public class AgentDBInteraction
    {
        private DataContext db;

        public AgentDBInteraction()
        {
            db = new DataContext();
        }

        public AgentCollection GetAllAgents()
        {
            AgentCollection Agents = new AgentCollection();

            foreach (Agent agent in db.Agents)
            {
                Agents.AddMachine(agent);
            }
            return Agents;
        }

        public void Add(Agent agent)
        {
            db.Agents.Add(agent);
            db.SaveChanges();
        }

        public void SetAgentRunning(string Agent, int pk_job)
        {
            AgentInteraction.SetAgentRunning(Agent, pk_job);
        }

        public AgentCollection GetIdleMachines()
        {
            return AgentInteraction.GetIdleAgents();
        }

        public Agent Get(string AgentName)
        {
            return AgentInteraction.Get(AgentName);
        }

        public void SetAgentQueued(string AgentName)
        {
            AgentInteraction.SetAgentQueued(AgentName);
        }

        public void SetAgentIdle(string AgentName)
        {
            AgentInteraction.SetAgentIdle(AgentName);
        }

        public void SetAgentDead(string AgentName)
        {
            AgentInteraction.SetAgentDead(AgentName);
        }

        public void Delete(string AgentName)
        {
            AgentInteraction.Delete(AgentName);
        }

        public void Update(Agent Agent)
        {
            var NewAgent = db.Agents.FirstOrDefault(a => a.Name.ToLower() == Agent.Name.ToLower());
            if(NewAgent != null)
            {
                if (NewAgent.IP != Agent.IP)
                {
                    NewAgent.IP = Agent.IP;
                    db.SaveChanges();
                }
            }
        }
    }
}