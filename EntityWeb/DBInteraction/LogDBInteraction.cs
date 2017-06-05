using EntityWeb.DAL;
using DataTypes;
using System.Linq;

namespace EntityWeb.DBInteraction
{
    public class LogDBInteraction
    {
        private DataContext DB;

        public LogDBInteraction()
        {
            DB = new DataContext();
        }

        public void Add(Log log)
        {
            DB.Logs.Add(log);
            DB.SaveChanges();
        }

        public LogCollection GetByAgent(string Name)
        {
            LogCollection AgentLogs = new LogCollection();
            var Logs = DB.Logs.Where(a => a.Name == Name && a.LogLevel < 4);
            foreach(Log log in Logs)
            {
                AgentLogs.AddLog(log);
            }
            AgentLogs.Logs = AgentLogs.Logs.OrderByDescending(i => i).ToList();
            return AgentLogs;
        }
    }
}