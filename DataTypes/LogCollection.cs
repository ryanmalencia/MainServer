using System.Collections.Generic;

namespace DataTypes
{
    public class LogCollection
    {
        public List<Log> Logs;

        /// <summary>
        /// Default constructor
        /// </summary>
        public LogCollection()
        {
            Logs = new List<Log>();
        }

        /// <summary>
        /// Add agent to collection
        /// </summary>
        /// <param name="agent">Agent object</param>
        public void AddLog(Log log)
        {
            Logs.Add(log);
        }
    }
}
