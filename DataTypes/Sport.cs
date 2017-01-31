using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    public class Sport
    {
        public int SportID { get; set; }
        public string Name { get; set; }

        public Sport()
        {

        }

        public Sport(string name)
        {
            Name = name;
        }
    }
}
