using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CST2550_systems_limited
{
    public class User
    {
        public int ID;
        public int Age { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public User(int id, string name, string email, int age)
        {
            ID = id;
            Name = name;
            Email = email;
            Age = age;
        }
        public bool IsValidEmail(string email)
        {
            string pattern = "^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$";
            Regex rg = new Regex(pattern);
            return rg.IsMatch(email);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"User's name, email and age with id {ID} are: {Name}, {Email}, {Age}");

            return sb.ToString();
        }
    }
}
