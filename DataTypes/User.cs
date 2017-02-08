using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    public class User
    {
        public int UserID { get; set; }
        public string GoogID { get; set; }

        public User()
        {

        }

        public User(string GoogID)
        {
            this.GoogID = GoogID;
        }
    }
}
