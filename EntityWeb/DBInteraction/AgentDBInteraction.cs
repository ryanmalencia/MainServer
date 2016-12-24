using EntityWeb.DAL;
using DataTypes;
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

        public void SetAgentQueued(string Agent)
        {
            AgentInteraction.SetAgentQueued(Agent);
        }
    }
}