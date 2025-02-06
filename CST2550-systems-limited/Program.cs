using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST2550_systems_limited
{
    public class Program
    {
        static bool tryAgain = true;
        static void Main(string[] args)
        {
            UserManagement users = new UserManagement();

            users.AddUser(1, "Jonathan", "j@j.com", 34, Role.Admin, 07412345678, "12345");
            users.AddUser(2, "Ammy", "a@a.com", 27, Role.User, 07478123456, "112233");
            users.AddUser(3, "Martin", "m@m.com", 18, Role.User, 07423456789, "11357");
            users.AddUser(4, "Joshua", "jo@jo.com", 24, Role.User, 07434567890, "2468");
            users.AddUser(5, "Adam", "ad@ad.com", 28, Role.User, 07445678123, "12134");
            users.AddUser(6, "Daniel", "d@d.com", 43, Role.User, 07456781234, "23145");
            users.AddUser(7, "Rinna", "r@r.com", 24, Role.User, 07467812345, "3344225");


            List<User> usersList = users.GetUsers();
            // Check if user exists
            // If not throw an error, if user exists print their details 

            try
            {
                Console.WriteLine("Search users and print the user with id 2:");
                User UByID = users.FindUser(2);
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


            users.RemoveUser(3);



            Console.WriteLine();
            Console.WriteLine("After deletion:");
            Console.WriteLine("User's name, email and age corresponding to the id:");
            foreach (User user in users.GetUsers())
            {
                Console.WriteLine(user.ToString());
            }


            Console.WriteLine();
            Console.WriteLine("Search users and print the user with age 24:");
            List<User> UByAge = users.GetUsersByAge(24);
            Console.WriteLine("Found {0} user/(s)", UByAge.Count);
            foreach (User user in UByAge)
            {
                Console.WriteLine(user.ToString());
            }

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
                        throw new FormatException("Incorrect email.");
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
