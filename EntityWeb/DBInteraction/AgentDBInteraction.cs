using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityWeb.DAL;
using EntityWeb.Models;

namespace EntityWeb.DBInteraction
{
    public class AgentDBInteraction
    {
        public static List<Agent> GetAllAgents()
        {
            DataContext db = new DataContext();
            List<Agent> Agents = new List<Agent>();

            foreach(Agent agent in db.Agents)
            {
                Agents.Add(agent);
            }

            return Agents;
        }
    }
}