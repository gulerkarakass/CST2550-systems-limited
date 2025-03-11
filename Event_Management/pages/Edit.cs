using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Event_Management.Contexts;
using Event_Management.Models;

namespace Event_Management.pages
{
    public partial class Edit : Form
    {
        private readonly EventContext db = new EventContext();
        public Edit()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Profile profile = new Profile();
            profile.FormClosed += (s, args) => this.Close();
            profile.Show();
        }

        private void Edit_Load(object sender, EventArgs e)
        {
            txtName.Text = Program.loggedInUser.Name;
            txtEmail.Text = Program.loggedInUser.Email;
            txtPostcode.Text = Program.loggedInUser.Postcode;
            txtDOB.Text = Program.loggedInUser.DateOfBirth;
            txtPhone.Text = Program.loggedInUser.Phone;
            txtPassword.Text = Program.loggedInUser.Password;

            string role;
            Role r = Program.loggedInUser.UserRole;
            if (r == Role.Admin)
            {
                role = "Admin";
            }
            else
            {
                role = "User";
            }
            comboRole.Text = role;

            string gender;
            Gender g = Program.loggedInUser.UserGender;
            if (g == Gender.Female)
            {
                gender = "Female";
            }
            else if (g == Gender.Male)
            {
                gender = "Male";
            }
            else
            {
                gender = "Prefer Not to Say";
            }
            comboGender.Text = gender;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string fullName = txtName.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            string postcode = txtPostcode.Text;
            string dob = txtDOB.Text;
            string r = comboRole.Text;
            int roleId;
            Role role;
            if (r == "Admin")
            {
                role = Role.Admin;
                roleId = 1;
            }
            else
            {
                role = Role.User;
                roleId = 2;
            }
            string g = comboGender.Text;
            int genderId;
            Gender gender;
            if (g == "Female")
            {
                gender = Gender.Female;
                genderId = 1;
            }
            else if (g == "Male")
            {
                gender = Gender.Male;
                genderId = 2;
            }
            else
            {
                gender = Gender.PreferNotToSay;
                genderId = 3;
            }
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (password == confirmPassword && Program.IsValidEmail(email) && Program.IsValidPhone(phone) && Program.IsValidPassword(password))
            {
                User currentUser = null;
                User newUser = null;


                foreach (User user in Program.usersList)
                {
                    if (user.Email == Program.loggedInUser.Email && user.Password == Program.loggedInUser.Password)
                    {
                        currentUser = user;
                        newUser = new User(fullName, email, postcode, dob, gender, role, phone, password);
                    }
                }
                int userKey = db.Users.FirstOrDefault(u => u.Email == Program.loggedInUser.Email).ID;
                Program.usersManagement.RemoveUser(userKey);
                Program.usersManagement.Put(userKey, newUser);

                Program.usersList.Remove(currentUser);
                Program.usersList.Add(newUser);

                // Updat the row in db
                var USER = db.Users.FirstOrDefault(u => u.Email == Program.loggedInUser.Email);
                if (USER != null)
                {
                    USER.FullName = fullName;
                    USER.Email = email;
                    USER.Postcode = postcode;
                    USER.DateOfBirth = dob;
                    USER.GenderID = genderId;
                    USER.RoleID = roleId;
                    USER.Phone = phone;
                    USER.Pass = password;

                    db.SaveChanges();
                    User user = new User(USER.FullName, USER.Email, USER.Postcode, USER.DateOfBirth, gender, role, USER.Phone, USER.Pass);
                    Program.loggedInUser = user;
                }

                this.Hide();
                Profile profile = new Profile();
                profile.FormClosed += (s, args) => this.Close();
                profile.Show();
            }
        }
    }
}
