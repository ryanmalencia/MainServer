using DataTypes;
using Newtonsoft.Json;

namespace WebAPIClient.APICalls
{
    public class CampusEventAPI
    {
        public static void AddEvent(CampusEvent Event)
        {
            string http = "api/campusevent/addevent";
            string method = "PUT";
            WebAPIClient.SendResponseJson(http, Event, method);
        }

        public static CampusEventCollection GetAllEvents()
        {
            string http = "api/campusevent/getallevents";
            string method = "GET";
            string theobject = WebAPIClient.GetResponseJson(http, null, method);
            object collection = JsonConvert.DeserializeObject<CampusEventCollection>(theobject);
            return (CampusEventCollection)collection;
        }

        public static void UpdateEventDate(CampusEvent Event)
        {
            string http = "api/campusevent/updateeventdate";
            string method = "PUT";
            WebAPIClient.SendResponseJson(http, Event, method);
        }

        public static CampusEventCollection GetNextHourEvents(string type)
        {
            string http = "api/campusevent/getnexthourevents/" + type;
            string method = "GET";
            string theobject = WebAPIClient.GetResponseJson(http, null, method);
            object collection = JsonConvert.DeserializeObject<CampusEventCollection>(theobject);
            return (CampusEventCollection)collection;
        }
    }
}