using DataTypes;
using Newtonsoft.Json;

namespace WebAPIClient.APICalls
{
    public class LogAPI
    {
        /// <summary>
        /// Add a new log
        /// </summary>
        /// <param name="log">Log to add</param>
        public static void AddLog(Log log)
        {
            string http = "api/log/add/";
            string method = "PUT";
            WebAPIClient.SendResponseJson(http, log, method);
        }
        /// <summary>
        /// Get logs for specified agent
        /// </summary>
        /// <param name="name">Name of agent</param>
        /// <returns>LogCollection with all logs</returns>
        public static LogCollection GetLogsForAgent(string name)
        {
            string http = "api/log/getlogsbyagent/" + name;
            string method = "GET";
            string theobject = WebAPIClient.GetResponseJson(http, null, method);
            object collection = JsonConvert.DeserializeObject<LogCollection>(theobject);
            return (LogCollection)collection;
        }
    }
}
