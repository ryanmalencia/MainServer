using DataTypes;
using Newtonsoft.Json;


namespace WebAPIClient.APICalls
{
    public class SportEventAPI
    {
        /// <summary>
        /// Get All Agents
        /// </summary>
        /// <returns>AgentCollection containing all Agents</returns>
        public static void AddSportEvent(SportEvent Event)
        {
            string http = "api/sportevent/add";
            string method = "PUT";
            WebAPIClient.SendResponseJson(http, Event, method);
        }
    }
}
