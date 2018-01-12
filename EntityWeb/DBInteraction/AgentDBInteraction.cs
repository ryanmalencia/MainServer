using EntityWeb.DAL;
using DataTypes;
using System.Linq;

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
            Agents.Agents.Sort();
            return Agents;
        }

        public bool Add(Agent agent)
        {
            int i = 0;
            DB.Agents.Add(agent);
            i = DB.SaveChanges();
            if(i == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string SetAgentRunning(string AgentName, int JobID)
        {
            var Agent = DB.Agents.FirstOrDefault(a => a.Name.ToLower() == AgentName.ToLower());
            var Job = DB.Jobs.FirstOrDefault(a => a.JobID == JobID);
            if(Agent != null && Job != null)
            {
                Agent.Running_Job = 1;
                Agent.Sent_Job = 1;
                Agent.fk_job = JobID;
                DB.SaveChanges();
                return Job.JobName;
            }
            return "";
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

        public Agent SetAgentQueued(string AgentName)
        {
            var Agent = DB.Agents.FirstOrDefault(a => a.Name.ToLower() == AgentName.ToLower());
            if(Agent != null)
            {
                Agent.Running_Job = 0;
                Agent.Sent_Job = 1;
                DB.SaveChanges();
            }
            return Agent;
        }

        public Agent SetAgentIdle(string AgentName)
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
            return Agent;
        }

        public Agent SetAgentDead(string AgentName)
        {
            var Agent = DB.Agents.FirstOrDefault(a => a.Name.ToLower() == AgentName.ToLower());
            if(Agent != null)
            {
                Agent.Is_Dead = 1;
                Agent.Running_Job = 0;
                Agent.Sent_Job = 0;
                DB.SaveChanges();
            }
            return Agent;
        }

        public bool Delete(string AgentName)
        {
            int i = 0;
            var Agent = DB.Agents.FirstOrDefault(a => a.Name.ToLower() == AgentName.ToLower());
            if(Agent != null)
            {
                DB.Agents.Remove(Agent);
                i = DB.SaveChanges();
                if(i == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return true;
        }

        public Agent Update(Agent Agent)
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
            return NewAgent;
        }
    }
}