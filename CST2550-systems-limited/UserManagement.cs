﻿using System;
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
        public void AddUser(int id, string name, string email, int age)
        {
            users.Add(new User(id, name, email, age));
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
        public List<User> GetUsersByAge(int age)
        {
            List<User> user = users.FindAll(item => item.Age == age);
            return user;
        }

        public List<User> GetUsers()
        {
            return users;
        }
    }
}
