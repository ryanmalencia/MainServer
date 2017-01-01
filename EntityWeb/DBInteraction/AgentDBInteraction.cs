using EntityWeb.DAL;
using DataTypes;
using System.Linq;
using DBInteraction;

namespace EntityWeb.DBInteraction
{
    public class AgentDBInteraction
    {
        private DataContext DB;

        public AgentDBInteraction()
        {
            DB = new DataContext();
        }

        public AgentCollection GetAllAgents()
        {
            AgentCollection Agents = new AgentCollection();
            foreach (Agent agent in DB.Agents)
            {
                Agents.AddAgent(agent);
            }
            return Agents;
        }

        public void Add(Agent agent)
        {
            DB.Agents.Add(agent);
            DB.SaveChanges();
        }

        public void SetAgentRunning(string AgentName, int JobID)
        {
            var Agent = DB.Agents.FirstOrDefault(a => a.Name.ToLower() == AgentName.ToLower());
            var Job = DB.Jobs.FirstOrDefault(a => a.JobID == JobID);
            if(Agent != null && Job != null)
            {
                Agent.Running_Job = 1;
                Agent.Sent_Job = 1;
                Agent.fk_job = JobID;
                DB.SaveChanges();
            }
        }

        public AgentCollection GetIdleAgents()
        {
            var Agents = DB.Agents.Where(a => a.Running_Job == 0 && a.Sent_Job == 0 && a.Is_Dead == 0);
            AgentCollection IdleAgents = new AgentCollection();
            foreach (Agent agent in Agents)
            {
                IdleAgents.AddAgent(agent);
            }
            return IdleAgents;
        }

        public Agent Get(string AgentName)
        {
            return DB.Agents.FirstOrDefault(a => a.Name.ToLower() == AgentName.ToLower());
        }

        public void SetAgentQueued(string AgentName)
        {
            var Agent = DB.Agents.FirstOrDefault(a => a.Name.ToLower() == AgentName.ToLower());
            if(Agent != null)
            {
                Agent.Running_Job = 0;
                Agent.Sent_Job = 1;
                DB.SaveChanges();
            }
        }

        public void SetAgentIdle(string AgentName)
        {
            var Agent = DB.Agents.FirstOrDefault(a => a.Name.ToLower() == AgentName.ToLower());
            if(Agent != null)
            {
                Agent.Running_Job = 0;
                Agent.Sent_Job = 0;
                Agent.Is_Dead = 0;
                Agent.fk_job = 0;
                DB.SaveChanges();
            }
        }

        public void SetAgentDead(string AgentName)
        {
            var Agent = DB.Agents.FirstOrDefault(a => a.Name.ToLower() == AgentName.ToLower());
            if(Agent != null)
            {
                Agent.Is_Dead = 1;
                Agent.Running_Job = 0;
                Agent.Sent_Job = 0;
                DB.SaveChanges();
            }
        }

        public void Delete(string AgentName)
        {
            var Agent = DB.Agents.FirstOrDefault(a => a.Name.ToLower() == AgentName.ToLower());
            if(Agent != null)
            {
                DB.Agents.Remove(Agent);
                DB.SaveChanges();
            }
        }

        public void Update(Agent Agent)
        {
            var NewAgent = DB.Agents.FirstOrDefault(a => a.Name.ToLower() == Agent.Name.ToLower());
            if(NewAgent != null)
            {
                if (NewAgent.IP != Agent.IP)
                {
                    NewAgent.IP = Agent.IP;
                    DB.SaveChanges();
                }
            }
        }
    }
}