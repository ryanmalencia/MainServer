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

        public static void AddDiningLocation(DiningLocation location)
        {
            string http = "api/location/adddininglocation";
            string method = "PUT";
            WebAPIClient.SendResponseJson(http, location, method);
        }

        public static void AddFitnessLocation(FitnessLocation location)
        {
            string http = "api/location/addfitnesslocation";
            string method = "PUT";
            WebAPIClient.SendResponseJson(http, location, method);
        }
        public static void AddLibraryLocation(LibraryLocation location)
        {
            string http = "api/location/addlibrarylocation";
            string method = "PUT";
            WebAPIClient.SendResponseJson(http, location, method);
        }

        public static void AddComputerLocation(ComputerLocation location)
        {
            string http = "api/location/addcomputerlocation";
            string method = "PUT";
            WebAPIClient.SendResponseJson(http, location, method);
        }
    }
}
