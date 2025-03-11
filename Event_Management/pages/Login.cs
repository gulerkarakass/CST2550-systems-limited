using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Event_Management.Contexts;
using Event_Management.Models;

namespace Event_Management.pages
{
    public partial class Login : Form
    {
        private readonly EventContext db = new EventContext();
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            bool contains = false;
            User User = null;
            foreach (User user in Program.usersList)
            {
                if (user.Email == email)
                {
                    contains = true;
                    User = user;
                    break;
                }
            }
            if (contains)
            {
                if (User.Email == email && User.Password == password)
                {
                    Program.loggedInUser = User;
                    txtEmail.Text = "";
                    txtPassword.Text = "";
                    this.Hide();
                    Profile profile = new Profile();
                    profile.FormClosed += (s, args) => this.Close();
                    profile.Show();
                }
            }

        }
        private void btnSignup_Click(object sender, EventArgs e)
        {
            this.Hide();
            Signup form = new Signup();
            form.FormClosed += (s, args) => this.Close();
            form.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            Program.usersList.Clear();
            foreach (User_Model user_Model in db.Users.ToList())
            {
                Role role;
                if (user_Model.RoleID == 1)
                {
                    role = Role.Admin;
                }
                else
                {
                    role = Role.User;
                }
                Gender gender;
                if (user_Model.GenderID == 1)
                {
                    gender = Gender.Female;
                }
                else if (user_Model.GenderID == 2)
                {
                    gender = Gender.Male;
                }
                else
                {
                    gender = Gender.PreferNotToSay;
                }
                User user = new User(user_Model.FullName, user_Model.Email, user_Model.Postcode, user_Model.DateOfBirth, gender, role, user_Model.Phone, user_Model.Pass);
                Program.usersManagement.Put(user_Model.ID, user);
                Program.usersList.Add(user);
            }
        }
    }
}
