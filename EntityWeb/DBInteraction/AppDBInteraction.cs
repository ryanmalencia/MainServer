using EntityWeb.DAL;
using DataTypes;
using System.Linq;

namespace EntityWeb.DBInteraction
{
    public class AppDBInteraction
    {
        private DataContext DB;

        public AppDBInteraction()
        {
            DB = new DataContext();
        }

        public void AddNewDevice(AppDevice device)
        {
            bool exists = false;
            foreach(AppDevice Device in DB.Devices)
            {
                if(Device.RegID == device.RegID)
                {
                    exists = true;
                }
            }

            if (!exists)
            {
                DB.Devices.Add(device);
                DB.SaveChanges();
            }
        }
    }
}