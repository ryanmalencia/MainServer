using EntityWeb.DBInteraction;
using DataTypes;

namespace EntityWeb.Logic
{
    public class UserLogic
    {
        private UserDBInteraction UserDB = new UserDBInteraction();

        public void Add(User user)
        {
            UserDB.Add(user);
        }

        public User Get(string user)
        {
            return UserDB.Get(user);
        }
    }
}