using DataTypes;
using Newtonsoft.Json;

namespace WebAPIClient.APICalls
{
    public class PoolAPI
    {
        /// <summary>
        /// Get All Pools
        /// </summary>
        /// <returns>Collection containing all Pools</returns>
        public static PoolCollection GetAllPools()
        {
            string http = "api/pool/getallpools";
            string method = "GET";
            string theobject = WebAPIClient.GetResponseJson(http, null, method);
            object collection = JsonConvert.DeserializeObject<PoolCollection>(theobject);
            return (PoolCollection)collection;
        }
        /// <summary>
        /// Get a Pool by it's Name
        /// </summary>
        /// <param name="PoolName">Name of Pool</param>
        /// <returns>Desired Pool or null if it does not exist</returns>
        public static Pool GetPoolByName(string PoolName)
        {
            string http = "api/pool/getpoolbyname/" + PoolName;
            string method = "GET";
            string theobject = WebAPIClient.GetResponseJson(http, null, method);
            object collection = JsonConvert.DeserializeObject<Pool>(theobject);
            return (Pool)collection;
        }
        /// <summary>
        /// Get Pool by it's ID
        /// </summary>
        /// <param name="id">ID of Pool</param>
        /// <returns>Desired Pool or null if it does not exist</returns>
        public static Pool GetPoolById(int id)
        {
            string http = "api/pool/getpoolbyid/" + id;
            string method = "GET";
            string theobject = WebAPIClient.GetResponseJson(http, null, method);
            object collection = JsonConvert.DeserializeObject<Pool>(theobject);
            return (Pool)collection;
        }
        /// <summary>
        /// Add a new Pool
        /// </summary>
        /// <param name="Pool">Pool to Add</param>
        public static void Add(Pool Pool)
        {
            string http = "api/pool/getallpools";
            string method = "PUT";
            WebAPIClient.SendResponseJson(http, Pool, method);
        }
    }
}
