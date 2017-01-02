using EntityWeb.DBInteraction;
using DataTypes;

namespace EntityWeb.Logic
{
    public class OSLogic
    {
        private OSDBInteraction OSDB = new OSDBInteraction();

        public OSCollection GetAllOSes()
        {
            return OSDB.GetAllOSes();
        }
    }
}