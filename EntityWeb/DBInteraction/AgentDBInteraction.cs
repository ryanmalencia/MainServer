using System.Collections.Generic;
using EntityWeb.DAL;
using DataTypes;

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

        public void SetAgentRunning(Agent agent, int pk_job)
        {

        }
    }
}