using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST2550_systems_limited
{
    public class UserManagement
    {
        private List<User> users;

        public UserManagement()
        {
            users = new List<User>();
        }
        public void AddUser(int id, string name, string email, int age, Role role, long phone, string password)
        {
            users.Add(new User(id, name, email, age, role, phone, password));
        }

        public void RemoveUser(int id)
        {
            users.RemoveAll(item => item.ID == id);
        }
        public User FindUser(int id)
        {
            User user = users.Find(item => item.ID == id);
            return user;
        }
        public List<User> GetUsersByRole(Role role)
        {
            List<User> user = users.FindAll(item => item.UserRole == role);
            return user;
        }

        public List<User> GetUsers()
        {
            return users;
        }
    }
}
