using EntityWeb.DAL;
using DataTypes;
using System.Linq;

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

        public Pool GetPoolByName(string PoolName)
        {
            return DB.Pools.FirstOrDefault(a => a.Name == PoolName);
        }

        public Pool GetPoolById(int id)
        {
            return DB.Pools.FirstOrDefault(a => a.PoolID == id);
        }

        public void Add(Pool Pool)
        {
            DB.Pools.Add(Pool);
            DB.SaveChanges();
        }
    }
}