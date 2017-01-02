using EntityWeb.DAL;
using DataTypes;
using System.Linq;

namespace EntityWeb.DBInteraction
{
    public class OSDBInteraction
    {
        private DataContext DB;

        public OSDBInteraction()
        {
            DB = new DataContext();
        }

        public OSCollection GetAllOSes()
        {
            OSCollection AllOSes = new OSCollection();
            foreach(OS os in DB.OSes)
            {
                AllOSes.AddOS(os);
            }
            return AllOSes;
        }
    }
}