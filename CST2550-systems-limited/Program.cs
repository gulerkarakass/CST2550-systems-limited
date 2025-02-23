using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Win32;

namespace CST2550_systems_limited
{
    public class Program
    {
        static List<int> userKeys = new List<int>();
        static List<string> names = new List<string>();
        static List<string> emails = new List<string>();
        static List<Gender> genders = new List<Gender>();
        static List<Role> roles = new List<Role>();
        static List<string> phones = new List<string>();
        static List<string> passwords = new List<string>();

        static List<User> usersList = new List<User>();
        static UserManagement<int, User> usersManagement = new UserManagement<int, User>(4);
        static User loggedinUser;

        static bool tryAgain = true;

        static List<int> venueKeys = new List<int>();
        static List<string> categories = new List<string>();
        static List<string> titles = new List<string>();
        static List<string> createdOn = new List<string>();
        static List<string> createdBy = new List<string>();

        static List<Venue> venuesList = new List<Venue>();
        static VenueManagement<int, Venue> venuesManagement = new VenueManagement<int, Venue>(4);

        static Dictionary<User, List<Venue>> hiredVenue = new Dictionary<User, List<Venue>>();
        static void Main(string[] args)
        {
            names.Add("Jonathan"); names.Add("Amy"); names.Add("Martin");
            names.Add("Joshua"); names.Add("Veronica"); names.Add("Daniel");
            names.Add("Becca"); names.Add("Rinna"); names.Add("Joshua");
            names.Add("Joshua"); names.Add("Joshua");

            emails.Add("j@j.com"); emails.Add("a@a.com"); emails.Add("m@m.com");
            emails.Add("jo@jo.com"); emails.Add("v@v.com"); emails.Add("d@d.com");
            emails.Add("b@b.com"); emails.Add("r@r.com"); emails.Add("josh@jo.com");
            emails.Add("jo@josh.com"); emails.Add("jo@jo.co");

            genders.Add(Gender.Male); genders.Add(Gender.Female); genders.Add(Gender.Male);
            genders.Add(Gender.Male); genders.Add(Gender.Female); genders.Add(Gender.Male);
            genders.Add(Gender.Female); genders.Add(Gender.Female); genders.Add(Gender.Male);
            genders.Add(Gender.Male); genders.Add(Gender.Male);

            roles.Add(Role.Admin); roles.Add(Role.Admin); roles.Add(Role.Admin);
            roles.Add(Role.User); roles.Add(Role.User); roles.Add(Role.User);
            roles.Add(Role.User); roles.Add(Role.User); roles.Add(Role.User);
            roles.Add(Role.User); roles.Add(Role.User);

            phones.Add("07412345678"); phones.Add("07478123456"); phones.Add("07423456789");
            phones.Add("07434567890"); phones.Add("07445678123"); phones.Add("07456781234");
            phones.Add("07467812345"); phones.Add("07433456789"); phones.Add("07434456789");
            phones.Add("07434556789"); phones.Add("07512344321");

            passwords.Add("1a2A3!4554"); passwords.Add("1a1A2!2334");
            passwords.Add("1c1S3£57f"); passwords.Add("2f4F6*85y");
            passwords.Add("1G2^1d34d"); passwords.Add("2(31sd4F5"); passwords.Add("33E^44$79s)");
            // These won't get added because they don't follow the rules for making a password
            passwords.Add("3344225"); passwords.Add("22468"); passwords.Add("32468");
            passwords.Add("3332468");

            categories.Add("Academic & Educational Events"); categories.Add("Social Events");
            categories.Add("Cultural & Entertainment Events"); categories.Add("Business & Networking Events");

            titles.Add("Science fairs"); titles.Add("Wedding");
            titles.Add("Art exhibition"); titles.Add("Trade shows");

            createdBy.Add("j@j.com");createdBy.Add("d@d.com");
            createdBy.Add("j@j.com");createdBy.Add("a@a.com");

            createdOn.Add("17-01-2025");createdOn.Add("26-12-2024");
            createdOn.Add("11-02-2025");createdOn.Add("02-02-2025");

            // Register new users
            // Check which button's clicked(login/register)
            // And move the code block there
            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine("Enter the key you want to assign to user:>");
                int Key = Convert.ToInt32(Console.ReadLine());
                RegisterUser(Key, i);
            }

            foreach (int KEY in userKeys)
            {
                User user = usersManagement.GetValue(KEY);
                if (user != null)
                    usersList.Add(user);
            }

            // Register new venues
            for (int i = 0; i < titles.Count; i++)
            {
                foreach (User user in usersList)
                {
                    if (user.Email == createdBy[i] && user.UserRole == Role.Admin)
                    {
                        RegisterVenue(i, i);
                    }
                }
            }

            foreach (int KEY in venueKeys)
            {
                Venue venue = venuesManagement.GetValue(KEY);
                if (venue != null)
                    venuesList.Add(venue);
            }


            Console.WriteLine("Before user deletion:");
            Console.WriteLine("User's details corresponding to the key:");
            foreach (User user in usersList)
            {
                Console.WriteLine(user.ToString());
            }
            Console.WriteLine("Venue's details corresponding to the key:");
            foreach (Venue venue in venuesList)
            {
                Console.WriteLine(venue.ToString());
            }


            try
            {
                Console.WriteLine("Enter the user key to delete the user:>");
                int Key = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < titles.Count; i++)
                {
                    if (createdBy[i] == usersManagement.GetValue(Key).Email)
                    {
                        venuesManagement.RemoveVenue(i);
                        venueKeys.Remove(i);
                    }
                }
                // Update venueList
                venuesList.Clear();
                foreach (int KEY in venueKeys)
                {
                    if (venuesManagement.GetValue(KEY) != null)
                    {
                        Venue venue = venuesManagement.GetValue(KEY);
                        venuesList.Add(venue);
                    }
                }

                usersManagement.RemoveUser(Key);
                userKeys.Remove(Key);
                // Update userList
                usersList.Clear();
                foreach (int KEY in userKeys)
                {
                    if (usersManagement.GetValue(KEY) != null)
                    {
                        User user = usersManagement.GetValue(KEY);
                        usersList.Add(user);
                    }
                }
                
            }
            catch (Exception)
            {

                throw;
            }


            Console.WriteLine();
            Console.WriteLine("After user deletion:");
            Console.WriteLine("User's details corresponding to the key:");
            foreach (User user in usersList)
            {
                Console.WriteLine(user.ToString());
            }
            Console.WriteLine("Venue's details corresponding to the key:");
            foreach (Venue venue in venuesList)
            {
                Console.WriteLine(venue.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("Search users and print the user with role user:");
            List<User> UByUserRole = new List<User>();
            foreach (User user in usersList)
            {
                if (user.UserRole == Role.User)
                    UByUserRole.Add(user);
            }
            Console.WriteLine("Found {0} user/(s)", UByUserRole.Count);
            foreach (User user in UByUserRole)
            {
                Console.WriteLine(user.ToString());
            }

            // A user logs in and attemps to update their email
            Object loginAUser = LoginAUser();
            if ((bool)(loginAUser.GetType().GetProperties().First(o => o.Name == "Found").GetValue(loginAUser, null)))
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
                        HireVenue();
                    }
                    
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                        tryAgain = true;
                    }

                }
                if (hiredVenue[loggedinUser] != null)
                {
                    List<Venue> Venue = hiredVenue[loggedinUser];
                    foreach (var item in Venue)
                    {
                        Console.WriteLine(item.ToString());
                    }
                    
                }
            }
            int key = (int)(loginAUser.GetType().GetProperties().First(o => o.Name == "Key").GetValue(loginAUser, null));
            bool isLoggedout = Logout(key);
            if (isLoggedout)
            {
                Console.WriteLine("User's logged out.");
            }
            else
            {
                Console.WriteLine("Logout failed.");
            }

            // Login with an existing user
            Object loginaUser = LoginAUser();
            try
            {
                bool isFound = (bool)(loginaUser.GetType().GetProperties().First(o => o.Name == "Found").GetValue(loginaUser, null));
                if (isFound)
                {
                    HireVenue();
                }
                else
                {
                    throw new FormatException("User not found.");
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            // Print out list of venues the user has hired
            if (hiredVenue[loggedinUser] != null)
            {
                List<Venue> Venue = hiredVenue[loggedinUser];

                foreach(var item in Venue)
                {
                    Console.WriteLine(item.ToString());
                }
                
            }
            // Logout the user
            if (Logout((int)(loginaUser.GetType().GetProperties().First(o => o.Name == "Key").GetValue(loginaUser, null))))
            {
                Console.WriteLine("User's logged out.");
            }
            else
            {
                Console.WriteLine("Logout failed.");
            }
            Console.WriteLine();
            Console.WriteLine();
            foreach (var hVenue in hiredVenue)
            {
                Console.WriteLine($"User:\n{hVenue.Key.ToString()}");
                List<Venue> Venue = hVenue.Value;

                foreach (var item in Venue)
                {
                    Console.WriteLine($"Venue:\n{item.ToString()}");
                }
                Console.WriteLine();
                Console.WriteLine();
            }







            // Login with an existing user
            Object loginauser = LoginAUser();
            try
            {
                bool isFound = (bool)(loginauser.GetType().GetProperties().First(o => o.Name == "Found").GetValue(loginauser, null));
                if (isFound)
                {
                    RemoveVenue();
                }
                else
                {
                    throw new FormatException("User not found.");
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            // Print out list of venues the user has hired
            if (hiredVenue[loggedinUser] != null)
            {
                List<Venue> Venue = hiredVenue[loggedinUser];

                foreach (var item in Venue)
                {
                    Console.WriteLine(item.ToString());
                }

            }
            // Logout the user
            if (Logout((int)(loginauser.GetType().GetProperties().First(o => o.Name == "Key").GetValue(loginauser, null))))
            {
                Console.WriteLine("User's logged out.");
            }
            else
            {
                Console.WriteLine("Logout failed.");
            }
            Console.WriteLine();
            Console.WriteLine();
            foreach (var hVenue in hiredVenue)
            {
                Console.WriteLine($"User:\n{hVenue.Key.ToString()}");
                List<Venue> Venue = hVenue.Value;

                foreach (var item in Venue)
                {
                    Console.WriteLine($"Venue:\n{item.ToString()}");
                }
                Console.WriteLine();
                Console.WriteLine();
            }




        }
        static void RegisterUser(int key, int i)
        {
            // Register
            if (!userKeys.Contains(key))
            {
                userKeys.Add(key);
                // Register new User
                User User = new User(names[i], emails[i], genders[i], roles[i], phones[i], passwords[i]);
                if (User.IsValidEmail(emails[i]) && User.IsValidPassword(passwords[i]) && User.IsValidPhone(phones[i]))
                {
                    usersManagement.Put(key, User);
                }
            }
        }
        static bool Login(int key, string email, string password)
        {
            if (userKeys.Contains(key))
            {
                // Login the user
                User User = usersManagement.GetValue(key);
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
            if (userKeys.Contains(key))
            {
                // Logout the user
                User User = usersManagement.GetValue(key);

                loggedinUser = null;
                return true;
            }
            return false;
        }
        static void RegisterVenue(int key, int i)
        {
            // Register
            venueKeys.Add(key);
            // Register new User
            Venue venue = new Venue(titles[i], createdOn[i], createdBy[i]);
            venuesManagement.Put(key, venue);
        }
        static Object LoginAUser()
        {
            Console.WriteLine("Enter the user key:>");
            int key = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the user email:>");
            string email = Console.ReadLine();
            Console.WriteLine("Enter the user password:>");
            string password = Console.ReadLine();
            return new { Found = Login(key, email, password), Key = key};
        }
        static void HireVenue()
        {
            Console.WriteLine();
            Console.WriteLine("Hire a venue by entering venue key:");
            Console.WriteLine($"Venues count: {venuesList.Count}");

            foreach (int K in venueKeys)
            {
                if (venuesManagement.GetValue(K) != null)
                {
                    Venue V = venuesManagement.GetValue(K);
                    Console.WriteLine($"{K}--->{V.ToString()}");
                }
            }
            int KEY = Convert.ToInt32(Console.ReadLine());
            Venue venue = venuesManagement.GetValue(KEY);
            List<Venue> venues = new List<Venue>();
            
            if (!hiredVenue.ContainsKey(loggedinUser))
            {
                venues.Add(venue);
                hiredVenue.Add(loggedinUser, venues);
            }
            else
            {
                foreach (Venue hV in hiredVenue[loggedinUser])
                {
                    venues.Add(hV);
                    venues.Add(venue);
                    hiredVenue[loggedinUser] = venues;
                }
            }
        }

        // For users to cancel their booked venue
        static void RemoveVenue()
        {
            Console.WriteLine();
            Console.WriteLine("Cancel a booked venue by entering venue created date:");
            Console.WriteLine($"Venues count: {hiredVenue[loggedinUser].Count}");

            foreach (Venue V in hiredVenue[loggedinUser])
            {
                Console.WriteLine($"{V.CreatedOn}--->{V.ToString()}");
            }
            string date = Console.ReadLine();
            Venue venue = hiredVenue[loggedinUser][0];
            foreach (Venue V in hiredVenue[loggedinUser])
            {
                if (V.CreatedOn == date)
                {
                    venue = V;
                }
            }
            Console.WriteLine($"{venue.ToString()}");

            hiredVenue[loggedinUser].Remove(venue);



        }
    }
}
