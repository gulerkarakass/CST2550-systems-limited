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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Event_Management.pages
{
    public partial class Profile : Form
    {
        private readonly EventContext db = new EventContext();
        public Profile()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Program.loggedInUser = null;
            this.Hide();
            Login login = new Login();
            login.FormClosed += (s, args) => this.Close();
            login.Show();
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            if (Program.loggedInUser.UserRole == Role.Admin)
            {
                postVenue.Visible = true;
            }
            else
            {
                postVenue.Visible = false;
            }

            Program.venuesList.Clear();

            foreach (var VENUE in db.Venues.Join(
                db.Users,
                venue => venue.UserID,
                user => user.ID,
                (venue, user) => new { venue, user })
                .ToList())
            {
                Category category;
                if (VENUE.venue.CategoryID == 1)
                {
                    category = Category.AcademicAndEducationalEvents;
                }
                else if (VENUE.venue.CategoryID == 2)
                {
                    category = Category.SocialEvents;
                }
                else if (VENUE.venue.CategoryID == 3)
                {
                    category = Category.CulturalAndEntertainmentEvents;
                }
                else
                {
                    category = Category.BusinessAndNetworkingEvents;
                }
                int? userID = VENUE.venue.UserID;
                Venue venue = new Venue(category, VENUE.venue.Title, VENUE.venue.TotalCapacity, VENUE.venue.Vacancy, VENUE.venue.CreatedOn, userID);
                Program.venuesManagement.Put(VENUE.venue.ID, venue);
                Program.venuesList.Add(venue);
            }


        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            string c = comboCategory.Text;
            Category category;
            int categoryID;
            if (c == "Academic & Educational Events")
            {
                category = Category.AcademicAndEducationalEvents;
                categoryID = 1;
            }
            else if (c == "Social Events")
            {
                category = Category.SocialEvents;
                categoryID = 2;
            }
            else if (c == "Cultural & Entertainment Events")
            {
                category = Category.CulturalAndEntertainmentEvents;
                categoryID = 3;
            }
            else
            {
                category = Category.BusinessAndNetworkingEvents;
                categoryID = 4;
            }
            string title = txtTitle.Text;
            int totalCapacity = Convert.ToInt16(txtCapacity.Text);
            string createdBy = Program.loggedInUser.Email;
            // Post a new Venue

            var userDB = db.Users.FirstOrDefault(u => u.Email == createdBy);
            
            if (userDB != null)
            {
                Venue venue = new Venue(category, title, totalCapacity, totalCapacity, DateTime.UtcNow.Date.ToString("dd-MM-yyyy"), userDB.ID);
                Program.venuesList.Add(venue);

                var venueDB = new Venue_Model
                {
                    Title = txtTitle.Text,
                    CreatedOn = DateTime.UtcNow.Date.ToString("dd-MM-yyyy"),
                    UserID = userDB.ID,
                    TotalCapacity = totalCapacity,
                    Vacancy = totalCapacity,
                    CategoryID = categoryID,
                };
                db.Venues.Add(venueDB);
                db.SaveChanges();
                txtTitle.Text = "";
                txtCapacity.Text = "";
            }
        }

        private void btnVenue_Click(object sender, EventArgs e)
        {
            this.Hide();
            VenueForm venue = new VenueForm();
            venue.FormClosed += (s, args) => this.Close();
            venue.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.Hide();
            Edit edit = new Edit();
            edit.FormClosed += (s, args) => this.Close();
            edit.Show();
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            // Get the logged in user
            var userDB = db.Users.FirstOrDefault(u => u.Email == Program.loggedInUser.Email);

            if (userDB != null)
            {
                // Get bookings related to the logged in user
                var bookings = db.Bookings.Join(
                    db.Venues,
                    booking => booking.VenueID,
                    venue => venue.ID,
                    (booking, venue) => new { booking, venue }
                )
                .Join(
                    db.Users,
                    bookingVenue => bookingVenue.booking.UserID,
                    user => user.ID,
                    (bookingVenue, user) => new { bookingVenue, user }
                )
                .Where(joined => joined.user.Email == Program.loggedInUser.Email)
                .ToList();

                // Remove related venues and bookings from memory and database
                List<Venue_Model> venueModelToBeDeleted = new List<Venue_Model>();
                List<Booking> bookingModelToBeDeleted = new List<Booking>();
                List<Review> reviewModelToBeDeleted = new List<Review>();

                var reviewsDB = db.Reviews.Join(
                    db.Venues,
                    review => review.VenueID,
                    venue => venue.ID,
                    (review, venue) => new { review, venue }
                )
                .Join(
                    db.Users,
                    reviewVenue => reviewVenue.review.UserID,
                    user => user.ID,
                    (reviewVenue, user) => new { reviewVenue, user }
                )
                .Where(joined => joined.user.Email == Program.loggedInUser.Email)
                .ToList();

                foreach (var reviewDB in reviewsDB)
                {
                    reviewModelToBeDeleted.Add(reviewDB.reviewVenue.review);
                }

                foreach (var booking in bookings)
                {
                    venueModelToBeDeleted.Add(booking.bookingVenue.venue);
                    bookingModelToBeDeleted.Add(booking.bookingVenue.booking);
                }

                foreach (var review in reviewModelToBeDeleted)
                {
                    // Remove booking from database
                    db.Reviews.Remove(review);
                }

                db.SaveChanges();

                foreach (var booking in bookingModelToBeDeleted)
                {
                    // Remove booking from database
                    db.Bookings.Remove(booking);
                }

                db.SaveChanges();

                foreach(var venue  in venueModelToBeDeleted)
                {
                    // Remove the  related venue from database
                    db.Venues.Remove(venue);

                    // Remove from memory
                    Program.venuesList.RemoveAll(v => v.UserID == venue.UserID);
                    Program.venuesManagement.RemoveVenue(venue.ID);
                }
                // Remove the user from memory and database
                Program.usersList.Remove(Program.usersManagement.GetValue(userDB.ID));
                Program.usersManagement.RemoveUser(userDB.ID);

                // Now remove the user from the database
                db.Users.Remove(userDB);

                // Clear null values from venueDB
                var venuesDB = db.Venues.ToList();
                foreach(var venueDB in venuesDB)
                {
                    if (venueDB.UserID == null)
                        db.Venues.Remove(venueDB);
                }
                // Commit changes to the database
                db.SaveChanges();

                // Log out the user and navigate to the login screen
                Program.loggedInUser = null;
                this.Hide();
                Login login = new Login();
                login.FormClosed += (s, args) => this.Close();
                login.Show();
            }
            else
            {
                MessageBox.Show("User not found.");
            }
        }


        private void btnDisplay_Click(object sender, EventArgs e)
        {
            if (Program.loggedInUser != null)
                MessageBox.Show(Program.loggedInUser.ToString());
        }
    }
}
