using DataTypes;
using Newtonsoft.Json;
using System.Collections.Generic;


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

        public static SportEventCollection GetNextHourEvents(string type)
        {
            string http = "api/sportevent/getnexthourevents/" + type;
            string method = "GET";
            string theobject = WebAPIClient.GetResponseJson(http, null, method);
            object collection = JsonConvert.DeserializeObject<SportEventCollection>(theobject);
            return (SportEventCollection)collection;
        }

        public static List<string> GetSportTypes()
        {
            string http = "api/sportevent/getsporttypes";
            string method = "GET";
            string theobject = WebAPIClient.GetResponseJson(http, null, method);
            object collection = JsonConvert.DeserializeObject<List<string>>(theobject);
            return (List<string>)collection;
        }
    }
}
