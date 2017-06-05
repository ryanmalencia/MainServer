using System;

namespace DataTypes
{
    public class Log : IComparable<Log>
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

        public int CompareTo(Log other)
        {
            if (other != null)
            {
                if (Date != null && other.Date != null)
                {
                    return Date.CompareTo(other.Date);
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return 1;
            }
        }
    }
}
