using EntityWeb.DBInteraction;
using DataTypes;

namespace EntityWeb.Logic
{
    public class PrintLogic
    {
        private PrintDBInteraction PrintDB = new PrintDBInteraction();

        public PrintCollection GetAllPrintLocations()
        {
            return PrintDB.GetAllPrintLocations();
        }
    }
}