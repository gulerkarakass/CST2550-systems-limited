using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace CST2550_systems_limited
{
    public class Program
    {
        static List<int> keys = new List<int>();
        
        static List<string> names = new List<string>();
        
        static List<string> emails = new List<string>();
        
        static List<Gender> genders = new List<Gender>();
        
        static List<Role> roles = new List<Role>();
        
        static List<string> phones = new List<string>();
        
        static List<string> passwords = new List<string>();
        
        static List<User> usersList = new List<User>();
        
        static UserManagement<int, User> users = new UserManagement<int, User>(4);
        
        static User loggedinUser;
        
        static bool tryAgain = true;
        static void Main(string[] args)
        {
            names.Add("Jonathan"); names.Add("Ammy"); names.Add("Martin");
            names.Add("Joshua"); names.Add("Veronica"); names.Add("Daniel");
            names.Add("Rinna"); names.Add("Joshua"); names.Add("Joshua");
            names.Add("Joshua");

            emails.Add("j@j.com"); emails.Add("a@a.com"); emails.Add("m@m.com");
            emails.Add("jo@jo.com"); emails.Add("ad@ad.com"); emails.Add("d@d.com");
            emails.Add("r@r.com"); emails.Add("josh@jo.com"); emails.Add("jo@josh.com");
            emails.Add("jo@jo.co");

            genders.Add(Gender.Male); genders.Add(Gender.Female); genders.Add(Gender.Male);
            genders.Add(Gender.Male); genders.Add(Gender.Female); genders.Add(Gender.Male);
            genders.Add(Gender.Female); genders.Add(Gender.Male); genders.Add(Gender.Male);
            genders.Add(Gender.Male);

            roles.Add(Role.Admin); roles.Add(Role.User); roles.Add(Role.User);
            roles.Add(Role.User); roles.Add(Role.User); roles.Add(Role.User);
            roles.Add(Role.User); roles.Add(Role.User); roles.Add(Role.User);
            roles.Add(Role.User);

            phones.Add("07412345678"); phones.Add("07478123456"); phones.Add("07423456789");
            phones.Add("07434567890"); phones.Add("07445678123"); phones.Add("07456781234");
            phones.Add("07467812345"); phones.Add("07433456789"); phones.Add("07434456789");
            phones.Add("07434556789");

            passwords.Add("1a2A3!4554"); passwords.Add("1a1A2!2334");
            passwords.Add("1c1S3£57f"); passwords.Add("2f4F6*85y");
            passwords.Add("1G2^1d34d"); passwords.Add("2(31sd4F5");
            // These won't get added because they don't follow the rules for making a password
            passwords.Add("3344225"); passwords.Add("22468"); passwords.Add("32468");
            passwords.Add("3332468");

            // Check which button's clicked(login/register)
            // And move the code block there
            for (int i=0; i<names.Count; i++)
            {
                Console.WriteLine("Enter the key you want to assign to user:>");
                int Key = Convert.ToInt32(Console.ReadLine());
                Register(Key, i);
            }

            foreach (int KEY in keys)
            {
                User user = users.GetValue(KEY);
                if (user != null)
                    usersList.Add(user);
            }


            Console.WriteLine("Before deletion:");
            Console.WriteLine("User's name, email and age corresponding to the key:");
            foreach (User user in usersList)
            {
                Console.WriteLine(user.ToString());
            }
            try
            {
                Console.WriteLine("Enter the user key to delete the user:>");
                int Key = Convert.ToInt32(Console.ReadLine());
                users.RemoveUser(Key);
                keys.Remove(Key);
                // Update userList
                usersList.Clear();
                foreach (int KEY in keys)
                {
                    if (users.GetValue(KEY) != null)
                    {
                        User user = users.GetValue(KEY);
                        usersList.Add(user);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            

            Console.WriteLine();
            Console.WriteLine("After deletion:");
            Console.WriteLine("User's name, email and age corresponding to the key:");
            foreach (User user in usersList)
            {
                Console.WriteLine(user.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("Search users and print the user with role user:");
            List<User> UByUserRole = new List<User>();
            foreach (User user in usersList)
            {
                if(user.UserRole == Role.User)
                    UByUserRole.Add(user);
            }
            Console.WriteLine("Found {0} user/(s)", UByUserRole.Count);
            foreach (User user in UByUserRole)
            {
                Console.WriteLine(user.ToString());
            }

            // A user attemps to update their email
            Console.WriteLine("Enter the user key:>");
            int key = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the user email:>");
            string email = Console.ReadLine();
            Console.WriteLine("Enter the user password:>");
            string password = Console.ReadLine();
            bool found = Login(key, email, password);
            if (found)
            {
                while (tryAgain)
                {
                    try
                    {
                        tryAgain = false;
                        Console.WriteLine();
                        Console.WriteLine("Enter new email");
                        string newEmail = Console.ReadLine();
                        loggedinUser.Email = newEmail;
                        if (loggedinUser.IsValidEmail(loggedinUser.Email))
                        {
                            Console.WriteLine("User details:");
                            Console.WriteLine(loggedinUser.ToString());
                        }
                        else
                        {
                            throw new FormatException("Incorrect email. Try again.");
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                        tryAgain = true;
                    }

                }
            }
            bool isLoggedout = Logout(key);
            if (isLoggedout)
            {
                Console.WriteLine("User's logged out.");
            }
            else
            {
                Console.WriteLine("Logout failed.");
            }
        }
        static void Register(int key, int i)
        {
            // Register
            if (!keys.Contains(key))
            {
                keys.Add(key);
                // Register new User
                User User = new User(names[i], emails[i], genders[i], roles[i], phones[i], passwords[i]);
                if (User.IsValidEmail(emails[i]) && User.IsValidPassword(passwords[i]) && User.IsValidPhone(phones[i]))
                {
                    users.Put(key, User);
                }
            }
        }
        static bool Login(int key, string email, string password)
        {
            if (keys.Contains(key))
            {
                // Login the user
                User User = users.GetValue(key);
                if (User.Email == email && User.Password == password)
                {
                    loggedinUser = User;
                    return true;
                }
            }
            return false;
        }
        static bool Logout(int key)
        {
            if (keys.Contains(key))
            {
                // Logout the user
                User User = users.GetValue(key);
                
                loggedinUser = null;
                return true;
            }
            return false;
        }
    }
}
