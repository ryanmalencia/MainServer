using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public List<Agent> GetAllAgents()
        {
            List<Agent> Agents = new List<Agent>();

            foreach(Agent agent in db.Agents)
            {
                Agents.Add(agent);
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