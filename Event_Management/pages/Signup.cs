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
    public partial class Signup : Form
    {
        private readonly EventContext db = new EventContext();
        public Signup()
        {
            InitializeComponent();
        }

        private void BtnSignup_Click(object sender, EventArgs e)
        {
            string fullName = txtName.Text;
            string email = txtEmail.Text;
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
            string phone = txtPhone.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            User User = new User(fullName, email, postcode, dob, gender, role, phone, password);
            bool contains = false;
            foreach(User user in Program.usersList)
            {
                if (user.Email == email)
                {
                    contains = true;
                    break;
                }
            }
            // Register
            if (password == confirmPassword && !contains)
            {
                // Register new User
                if (User.IsValidEmail(email) && User.IsValidPassword(password) && User.IsValidPhone(phone))
                {
                    var user = new User_Model {
                        FullName = fullName,
                        Email = email,
                        Postcode = postcode,
                        DateOfBirth = dob,
                        GenderID = genderId,
                        RoleID = roleId,
                        Phone = phone,
                        Pass = password
                    };
                    db.Users.Add(user);
                    db.SaveChanges();
                    Program.usersList.Add(User);
                    txtName.Text = "";
                    txtEmail.Text = "";
                    txtPostcode.Text = "";
                    txtDOB.Text = "";
                    txtPhone.Text = "";
                    txtPassword.Text = "";
                    txtConfirmPassword.Text = "";

                    comboRole.Text = "User";
                    comboGender.Text = "N/A";
                }
            }

        }

        private void BtnDisplay_Click(object sender, EventArgs e)
        {
            foreach (User user in Program.usersList)
            {
                MessageBox.Show(user.ToString());
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login f = new Login();
            f.FormClosed += (s, args) => this.Close();
            f.Show();
        }

        private void Signup_Load(object sender, EventArgs e)
        {
            if (db.Roles.FirstOrDefault(r => r.URole == "Admin") == null)
            {
                db.Roles.Add(new Role_Model { URole = "Admin" });
                db.Roles.Add(new Role_Model { URole = "User" });

                db.Genders.Add(new Gender_Model { UGender = "Female" });
                db.Genders.Add(new Gender_Model { UGender = "Male" });
                db.Genders.Add(new Gender_Model { UGender = "N/A" });

                db.Categories.Add(new Category_Model { Category = "Academic & Educational Events" });
                db.Categories.Add(new Category_Model { Category = "Social Events" });
                db.Categories.Add(new Category_Model { Category = "Cultural & Entertainment Events" });
                db.Categories.Add(new Category_Model { Category = "Business & Networking Events" });
                db.SaveChanges();
            }
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
