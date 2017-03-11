using DataTypes;

namespace WebAPIClient.APICalls
{
    public class LocationAPI
    {
        public static void AddPrintLocation(Location location)
        {
            string http = "api/location/addprintlocation";
            string method = "PUT";
            WebAPIClient.SendResponseJson(http,location, method);
        }
    }
}
