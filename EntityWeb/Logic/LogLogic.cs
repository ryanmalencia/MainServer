using EntityWeb.DBInteraction;
using DataTypes;
using EntityWeb.SignalR;

namespace EntityWeb.Logic
{
    public class LogLogic
    {
        private LogDBInteraction LogDB = new LogDBInteraction();
        private LogTicker LogTicker = LogTicker.Instance;

        public void Add(Log log)
        {
            LogDB.Add(log);
            LogTicker.NewLogMessage(log);
        }

        public LogCollection GetByAgent(string Name)
        {
            return LogDB.GetByAgent(Name);
        }
    }
}