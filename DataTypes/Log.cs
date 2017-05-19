using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    public class Log
    {
        public int LogID { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public int LogLevel { get; set; }
        public DateTime Date { get; set; }
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Log()
        {

        }

        public Log(DateTime date, string name = "", string message = "", int level = 1)
        {
            Name = name;
            Message = message;
            LogLevel = level;
            if (date == null)
            {
                Date = DateTime.Now;
            }
            else
            {
                Date = date;
            }
        }
    }
}
