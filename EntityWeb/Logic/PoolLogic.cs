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
    }
}