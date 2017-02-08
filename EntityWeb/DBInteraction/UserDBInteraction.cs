using EntityWeb.DAL;
using DataTypes;
using System.Linq;

namespace EntityWeb.DBInteraction
{
    public class UserDBInteraction
    {
        private DataContext DB;

        public UserDBInteraction()
        {
            DB = new DataContext();
        }

        public void Add(User user)
        {
            var User = DB.Users.FirstOrDefault(a => a.GoogID == user.GoogID);

            if(User == null)
            {
                DB.Users.Add(user);
                DB.SaveChanges();
            }
        }

        public User Get(string user)
        {
            var User = DB.Users.FirstOrDefault(a => a.GoogID == user);

            if (User != null)
            {
                return User;
            }
            else
            {
                return new User();
            }
        }
    }
}