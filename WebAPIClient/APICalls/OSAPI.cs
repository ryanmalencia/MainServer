using DataTypes;
using Newtonsoft.Json;

namespace WebAPIClient.APICalls
{
    public class OSAPI
    {
        /// <summary>
        /// Get All OSes
        /// </summary>
        /// <returns>Collection containing all OSes</returns>
        public static OSCollection GetAllOSes()
        {
            string http = "api/os/getallos";
            string method = "GET";
            string theobject = WebAPIClient.GetResponseJson(http, null, method);
            object collection = JsonConvert.DeserializeObject<OSCollection>(theobject);
            return (OSCollection)collection;
        }
    }
}
