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

namespace Event_Management.pages
{
    public partial class VenueForm : Form
    {
        private readonly EventContext db = new EventContext();
        public VenueForm()
        {
            InitializeComponent();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            this.Hide();
            Profile profile = new Profile();
            profile.FormClosed += (s, args) => this.Close();
            profile.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Program.loggedInUser = null;
            this.Hide();
            Login login = new Login();
            login.FormClosed += (s, args) => this.Close();
            login.Show();
        }

        private void VenueForm_Load(object sender, EventArgs e)
        {
            var venuesDB = db.Venues.Join(
                db.Users,
                venue => venue.UserID,
                user => user.ID,
                (venue, user) => new { venue, user }
                )
                .Join(
                db.Categories,
                venueVenue => venueVenue.venue.CategoryID,
                category => category.ID,
                (venueVenue, category) => new { venueVenue, category }
                )
                .ToList();

            dataGridViewAllVenues.ColumnCount = 6;
            dataGridViewAllVenues.Columns[0].Name = "User Name";
            dataGridViewAllVenues.Columns[1].Name = "Venue Category";
            dataGridViewAllVenues.Columns[2].Name = "Venue Title";
            dataGridViewAllVenues.Columns[3].Name = "Venue Created By";
            dataGridViewAllVenues.Columns[4].Name = "Venue Total capacity";
            dataGridViewAllVenues.Columns[5].Name = "Venue Vacancy";


            dataGridViewHiredVenues.ColumnCount = 5;
            dataGridViewHiredVenues.Columns[0].Name = "User Email";
            dataGridViewHiredVenues.Columns[1].Name = "Venue Category";
            dataGridViewHiredVenues.Columns[2].Name = "Venue Title";
            dataGridViewHiredVenues.Columns[3].Name = "Venue Created By";
            dataGridViewHiredVenues.Columns[4].Name = "Venue Reserved Date";

            
            Program.venuesList.Clear();
            foreach (var VENUE in venuesDB)
            {
                int? categoryID = VENUE.venueVenue.venue.CategoryID;

                Category category = Category.BusinessAndNetworkingEvents;
                if(categoryID == 1)
                {
                    category = Category.AcademicAndEducationalEvents;
                }
                else if(categoryID == 2)
                {
                    category = Category.SocialEvents;
                }
                else if (categoryID == 3)
                {
                    category = Category.CulturalAndEntertainmentEvents;
                }
                else
                {
                    category = Category.BusinessAndNetworkingEvents;
                }
                Venue venue = new Venue(category, VENUE.venueVenue.venue.Title, VENUE.venueVenue.venue.TotalCapacity, VENUE.venueVenue.venue.Vacancy, VENUE.venueVenue.venue.CreatedOn, VENUE.venueVenue.venue.UserID);
                Program.venuesManagement.Put(VENUE.venueVenue.venue.ID, venue);
                Program.venuesList.Add(venue);
            }

            PrintVenues();
        }

        private void btnHire_Click(object sender, EventArgs e)
        {
            string email = txtCreatedBy.Text;
            string title = txtTitle.Text;

            var venueDB = db.Venues.Join(
                db.Users,
                v => v.UserID,
                u => u.ID,
                (venue, user) => new { venue, user }
                ).FirstOrDefault(joined => joined.user.Email == email && joined.venue.Title == title);

            if (venueDB != null)
            {
                // Insert booking
                var userDB = db.Users.First(u => u.Email == Program.loggedInUser.Email);

                if (userDB != null && venueDB.venue.Vacancy >= 1)
                {
                    var booking = new Booking
                    {
                        UserID = userDB.ID,
                        VenueID = venueDB.venue.ID,
                        ReservedDate = DateTime.UtcNow.Date.ToString("dd-MM-yyyy")
                    };

                    if (db.Bookings.FirstOrDefault(b => b.VenueID == venueDB.venue.ID && b.UserID == userDB.ID) == null)
                    {
                        db.Bookings.Add(booking);

                        // Update venue vacancy
                        venueDB.venue.Vacancy -= 1;

                        db.SaveChanges();
                    }
                }

                PrintVenues();
            }
        }

        private void btnCancelBooking_Click(object sender, EventArgs e)
        {
            string email = txtCreatedBy.Text;
            string title = txtTitle.Text;

            // Find list of vinues with a specific title
            // being posted by ENTERED EMAIL
            var venuesDB = db.Venues.Join(
                db.Users,
                v => v.UserID,
                u => u.ID,
                (Venue, user) => new { Venue, user }
                ).Where(joined => joined.user.Email == email && joined.Venue.Title == title)
                .ToList();


            // Find list of hired venues
            // HIRED by LOGGED IN USER
            // POSTED by ENTERED EMAIL
            foreach (var venueDB in venuesDB)
            {
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
                    .Where(joined => joined.user.Email == Program.loggedInUser.Email &&
                    joined.bookingVenue.venue.Title == title &&
                    joined.bookingVenue.venue.ID == venueDB.Venue.ID
                    )
                    .ToList();

                // Remove these found hired venues
                // And display them
                foreach (var booking in bookings)
                {
                    db.Bookings.Remove(booking.bookingVenue.booking);

                    // Update venue vacancy
                    booking.bookingVenue.venue.Vacancy += 1;

                    db.SaveChanges();
                }
                PrintVenues();
            }
        }

        private void PrintVenues()
        {
            var venuesDB = db.Venues.Join(
                db.Users,
                venue => venue.UserID,
                user => user.ID,
                (venue, user) => new { venue, user }
                )
                .Join(
                db.Categories,
                venueVenue => venueVenue.venue.CategoryID,
                category => category.ID,
                (venueVenue, category) => new { venueVenue, category }
                )
                .ToList();

            dataGridViewAllVenues.Rows.Clear();
            dataGridViewHiredVenues.Rows.Clear();

            // Print all the venues in the left textbox
            foreach (var venueDB in venuesDB)
            {
                dataGridViewAllVenues.Rows.Add(
                    Program.loggedInUser.Name,
                    venueDB.category.Category,
                    venueDB.venueVenue.venue.Title,
                    venueDB.venueVenue.user.Email,
                    venueDB.venueVenue.venue.TotalCapacity,
                    venueDB.venueVenue.venue.Vacancy
                );
            }

            var hiredVenuesDB = db.Bookings.Join(
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
                
            List<Booking> bookingsDB = new List<Booking>();
            if (hiredVenuesDB != null)
            {
                foreach (var hv in hiredVenuesDB)
                {
                    if (db.Bookings.FirstOrDefault(b => b.VenueID == hv.bookingVenue.booking.VenueID && b.UserID == hv.user.ID) != null)
                        bookingsDB.Add(db.Bookings.First(b => b.VenueID == hv.bookingVenue.booking.VenueID && b.UserID == hv.user.ID));
                }
                
                // Print loggedin user and their corresponding hired venues in the right textbox
                foreach (var hv in bookingsDB)
                {
                    var venue = db.Venues.Join(
                    db.Users,
                    Venue => Venue.UserID,
                    user => user.ID,
                    (Venue, user) => new { Venue, user }
                    )
                    .FirstOrDefault(joined => joined.Venue.ID == hv.VenueID);
                    if (venue != null)
                    {
                        string category;
                        if (venue.Venue.CategoryID == 1)
                        { category = "Academic & Educational Events"; }
                        else if (venue.Venue.CategoryID == 2)
                        { category = "Social Events"; }
                        else if (venue.Venue.CategoryID == 3)
                        { category = "Cultural & Entertainment Events"; }
                        else
                        { category = "Business & Networking Events"; }
                        dataGridViewHiredVenues.Rows.Add(
                            Program.loggedInUser.Email,
                            category,
                            venue.Venue.Title,
                            venue.user.Email,
                            hv.ReservedDate
                        );
                    }
                }
            }
        }

        private void btnReview_Click(object sender, EventArgs e)
        {
            ReviewForm review = new ReviewForm();
            review.Show();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearch.Text.Trim();
            int categoryID = 0;
            if ("Academic & Educational Events".Contains(search))
            { categoryID = 1; }
            else if ("Social Events".Contains(search))
            { categoryID = 2; }
            else if ("Cultural & Entertainment Events".Contains(search))
            { categoryID = 3; }
            else if ("Business & Networking Events".Contains(search))
            { categoryID = 4; }
            var venue = db.Venues.Join(
                db.Users,
                v => v.UserID,
                u => u.ID,
                (Venue, user) => new { Venue, user }
                )
                .Join(
                db.Categories,
                venueVenue => venueVenue.Venue.CategoryID,
                category => category.ID,
                (venueVenue, category) => new { venueVenue, category }
                ).Where(joined => joined.venueVenue.Venue.Title.Contains(search) ||
                joined.venueVenue.user.Email.Contains(search) ||
                joined.category.ID == categoryID
            ).ToList();
            dataGridViewAllVenues.DataSource = venue;
        }
    }
}
