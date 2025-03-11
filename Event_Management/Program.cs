using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Event_Management.pages;

namespace Event_Management
{
    public static class Program
    {
        public static List<User> usersList = new List<User>();
        public static UserManagement<int, User> usersManagement = new UserManagement<int, User>(4);

        public static User loggedInUser;

        public static List<Venue> venuesList = new List<Venue>();
        public static VenueManagement<int, Venue> venuesManagement = new VenueManagement<int, Venue>(4);

        public static Dictionary<User, List<Venue>> hiredVenue = new Dictionary<User, List<Venue>>();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Signup());
        }

        public static bool IsValidEmail(string email)
        {
            string pattern = "^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$";
            Regex rg = new Regex(pattern);
            return rg.IsMatch(email);
        }

        public static bool IsValidPassword(string password)
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

        public static bool IsValidPhone(string phone)
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
            return rg.IsMatch(phone);
        }
    }
}
