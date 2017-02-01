using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    public class SportEventCollection
    {
        public List<SportEvent> Events;

        /// <summary>
        /// Default constructor
        /// </summary>
        public SportEventCollection()
        {
            Events = new List<SportEvent>();
        }

        /// <summary>
        /// Add SportEvent to collection
        /// </summary>
        /// <param name="Event">Event object</param>
        public void AddEvent(SportEvent Event)
        {
            Events.Add(Event);
        }
    }
}
