using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace CST2550_systems_limited
{
    public class Program
    {
        static bool tryAgain = true;
        static void Main(string[] args)
        {
            UserManagement<int, User> users = new UserManagement<int, User>(4);

            List<int> ids = new List<int>();
            ids.Add(1);ids.Add(2);ids.Add(3);ids.Add(4);
            ids.Add(5);ids.Add(6);ids.Add(7);

            string email1 = "j@j.com";
            string password1 = "12345";
            long phone1 = 07412345678;
            
            users.Put(ids[0], new User(ids[0], "Jonathan", email1, 34, Role.Admin, phone1, password1));
            
            string email2 = "a@a.com";
            string password2 = "112233";
            long phone2 = 07478123456;
            
            users.Put(ids[1], new User(ids[1], "Ammy", email2, 27, Role.User, phone2, password2));

            string email3 = "m@m.com";
            string password3 = "11357";
            long phone3 = 07423456789;
            
            users.Put(ids[2], new User(ids[2], "Martin", email3, 18, Role.User, phone3, password3));

            string email4 = "jo@jo.com";
            string password4 = "2468";
            long phone4 = 07434567890;

            string email4_1 = "josh@jo.com";
            string password4_1 = "22468";
            long phone4_1 = 07433456789;

            string email4_2 = "jo@josh.com";
            string password4_2 = "32468";
            long phone4_2 = 07434456789;

            string email4_3 = "jo@jo.co";
            string password4_3 = "3332468";
            long phone4_3 = 07434556789;
            
            users.Put(ids[3], new User(ids[3], "Joshua", email4, 24, Role.User, phone4, password4));
            users.Put(ids[3], new User(ids[3], "Joshua", email4_1, 26, Role.User, phone4_1, password4_1));
            users.Put(ids[3], new User(ids[3], "Joshua", email4_2, 28, Role.User, phone4_2, password4_2));
            users.Put(ids[3], new User(ids[3], "Joshua", email4_3, 34, Role.User, phone4_3, password4_3));

            string email5 = "ad@ad.com";
            string password5 = "12134";
            long phone5 = 07445678123;
            
            users.Put(ids[4], new User(ids[4], "Adam", email5, 28, Role.User, phone5, password5));

            string email6 = "d@d.com";
            string password6 = "23145";
            long phone6 = 07456781234;
            
            users.Put(ids[5], new User(ids[5], "Daniel", email6, 43, Role.User, phone6, password6));

            string email7 = "r@r.com";
            string password7 = "3344225";
            long phone7 = 07467812345;
            
            users.Put(ids[6], new User(ids[6], "Rinna", email7, 24, Role.User, phone7, password7));


            List<User> usersList = new List<User>();
            // Check if user exists
            // If not throw an error, if user exists print their details 
            


            try
            {
                foreach (int id in ids)
                {
                    User user = users.GetValue(id);
                    usersList.Add(user);
                }
                Console.WriteLine("Search users and print the user with id 2:");
                User UByID = users.GetValue(2);
                if (UByID != null)
                {
                    Console.WriteLine(UByID.ToString());
                    Console.WriteLine();
                }
                else
                {
                    throw new FormatException("User doesn't exist");
                }

            }
            catch (FormatException e)
            {
                Console.WriteLine($"{e.Message}");
            }



            Console.WriteLine("Before deletion:");
            Console.WriteLine("User's name, email and age corresponding to the id:");
            foreach (User user in usersList)
            {
                Console.WriteLine(user.ToString());
            }

            try
            {
                users.RemoveUser(ids[3]);
                ids.Remove(ids[3]);
                usersList.Clear();
                foreach (int id in ids)
                {
                    if (users.GetValue(id) != null)
                    {
                        User user = users.GetValue(id);
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
            Console.WriteLine("User's name, email and age corresponding to the id:");
            foreach (User user in usersList)
            {
                Console.WriteLine(user.ToString());
            }

            Console.WriteLine();
//            Console.WriteLine("Search users and print the user with role user:");
  //          List<User> UByRole = users.GetUsersByRole(Role.User);
    //        Console.WriteLine("Found {0} user/(s)", UByRole.Count);
      //      foreach (User user in UByRole)
        //    {
          //      Console.WriteLine(user.ToString());
            //}

            // A user attemps to update their email
            while (tryAgain)
            {
                try
                {
                    tryAgain = false;
                    Console.WriteLine();
                    Console.WriteLine("Enter new email");
                    string newEmail = Console.ReadLine();
                    usersList[0].Email = newEmail;
                    if (usersList[0].IsValidEmail(usersList[0].Email))
                    {
                        Console.WriteLine("User 1 details:");
                        Console.WriteLine(usersList[0].ToString());
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
    }
}
