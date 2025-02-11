using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CST2550_systems_limited
{
    public enum Role { Admin, User, Guest }
    public class User
    {
        public int ID;
        public int Age { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public string Postcode { get; set; }
        public string Password { get; set; }
        public Role UserRole { get; set; }
        public User(int id, string name, string email, int age, Role role, long phone, string password)
        {
            ID = id;
            Name = name;
            Email = email;
            Age = age;
            UserRole = role;
            Phone = phone;
            Password = password;
        }
        public bool IsValidEmail(string email)
        {
            string pattern = "^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$";
            Regex rg = new Regex(pattern);
            return rg.IsMatch(email);
        }

        public bool IsValidPassword(string password)
        {
            /*
             . means a single character except newline and terminator.
             (?=.*[0-9]) means the password must contain any single digit in a range from 1 to 9
             (?=.*[a-z]) means the password must contain at least 1 lowercase letter
             (?=.*[A-Z]) means the password must contain at least 1 uppercase letter
             (?=.*\W) means the password must contain at least 1 special character
             (?!.* )  means the password must not contain space character
             {8,16} specifies the password length as 8-16 characters long
            */
            string pattern = "^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*\\W)(?!.* ).{8,16}$";
            Regex rg = new Regex(pattern);
            return rg.IsMatch(password);
        }

        public bool IsValidPhone(long phone)
        {
            /*
             0[0-9]{10} matches a string with a leading 0 followed by exactly 10 digits
             the difference between (?=0[0-9]{10}) and 0[0-9]{10} is as follows:
             (?=[0-9]{10}) only checks if a string begin with 0 followed by exactly 10 digits but does not consume it
             but 0[0-9]{10} matches a string with a leading 0 followed by exacty 10 digits
             note the number being tested must be in string format
            */
            string pattern = "^0[0-9]{10}$";
            Regex rg = new Regex(pattern);
            return rg.IsMatch($"{phone}");
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"User's name, email, age, phone, password, role with id {ID} are: {Name}, {Email}, {Age}, {Phone}, {Password}, {UserRole}");

            return sb.ToString();
        }
    }
}
