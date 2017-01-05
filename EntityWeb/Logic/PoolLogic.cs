using EntityWeb.DBInteraction;
using DataTypes;

namespace EntityWeb.Logic
{
    public class PoolLogic
    {
        private PoolDBInteraction PoolDB = new PoolDBInteraction();
        /// <summary>
        /// Get All Pools in DB
        /// </summary>
        /// <returns>PoolCollection containing all pools</returns>
        public PoolCollection GetAllPools()
        {
            return PoolDB.GetAllPools();
        }
        /// <summary>
        /// Get a Pool by it's Name
        /// </summary>
        /// <param name="PoolName">Name of Pool</param>
        /// <returns>Desired Pool or null if it does not exist</returns>
        public Pool GetPoolByName(string PoolName)
        {
            return PoolDB.GetPoolByName(PoolName);
        }
        /// <summary>
        /// Get a Pool by it's ID
        /// </summary>
        /// <param name="id">ID of Pool</param>
        /// <returns>Desired Pool or null if it does not exist</returns>
        public Pool GetPoolById(int id)
        {
            return PoolDB.GetPoolById(id);
        }
        /// <summary>
        /// Add a Pool
        /// </summary>
        /// <param name="Pool">Pool to Add</param>
        public void Add(Pool Pool)
        {
            PoolDB.Add(Pool);
        }
    }
}