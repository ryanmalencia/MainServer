using DataTypes;

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
    }
}
