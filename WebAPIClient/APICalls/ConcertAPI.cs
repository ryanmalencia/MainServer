using DataTypes;
using Newtonsoft.Json;


namespace WebAPIClient.APICalls
{
    public class ConcertAPI
    {
        public static void Add(Concert concert)
        {
            string http = "api/concert/add";
            string method = "PUT";
            WebAPIClient.SendResponseJson(http, concert, method);
        }
    }
}
