using EntityWeb.DAL;
using DataTypes;

namespace EntityWeb.DBInteraction
{
    public class PoolDBInteraction
    {
        private DataContext DB;

        public PoolDBInteraction()
        {
            DB = new DataContext();
        }

        public PoolCollection GetAllPools()
        {
            PoolCollection AllPools = new PoolCollection();
            foreach(Pool pool in DB.Pools)
            {
                AllPools.AddPool(pool);
            }
            return AllPools;
        }
    }
}