using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Event_Management.Contexts;
using Event_Management.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Event_Management.pages
{
    public partial class ReviewForm : Form
    {
        private readonly EventContext db = new EventContext();
        public ReviewForm()
        {
            InitializeComponent();
        }

        private void ReviewForm_Load(object sender, EventArgs e)
        {
            List<Venue> hiredVenueList = new List<Venue>();

            Program.venuesList.Clear();
            Program.hiredVenue.Clear();
            
            dataGridViewHiredVenues.ColumnCount = 7;
            dataGridViewHiredVenues.Columns[0].Name = "User Name";
            dataGridViewHiredVenues.Columns[1].Name = "User Email";
            dataGridViewHiredVenues.Columns[2].Name = "Venue Category";
            dataGridViewHiredVenues.Columns[3].Name = "Venue Title";
            dataGridViewHiredVenues.Columns[4].Name = "Venue Created By";
            dataGridViewHiredVenues.Columns[5].Name = "Venue Total capacity";
            dataGridViewHiredVenues.Columns[6].Name = "Venue Vacancy";

            
            dataGridVewReviews.ColumnCount = 7;
            dataGridVewReviews.Columns[0].Name = "User Name";
            dataGridVewReviews.Columns[1].Name = "User Email";
            dataGridVewReviews.Columns[2].Name = "Venue Title";
            dataGridVewReviews.Columns[3].Name = "Venue Created By";
            dataGridVewReviews.Columns[4].Name = "Rating";
            dataGridVewReviews.Columns[5].Name = "Review";
            dataGridVewReviews.Columns[6].Name = "Review Date";

            var bookingDB = db.Bookings.Join(
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
                ).ToList();

            foreach (var booking in bookingDB)
            {
                var userDB = db.Users.FirstOrDefault(u => u.ID == booking.user.ID);
                
                if (userDB != null)
                {
                    var venueDB = db.Venues.FirstOrDefault(v => v.ID == booking.bookingVenue.booking.VenueID);

                    if (venueDB != null)
                    {
                        Category category;
                        if (venueDB.CategoryID == 1)
                        {
                            category = Category.AcademicAndEducationalEvents;
                        }
                        else if (venueDB.CategoryID == 2)
                        {
                            category = Category.SocialEvents;
                        }
                        else if (venueDB.CategoryID == 3)
                        {
                            category = Category.CulturalAndEntertainmentEvents;
                        }
                        else
                        {
                            category = Category.BusinessAndNetworkingEvents;
                        }

                        Venue Venue = new Venue(category, venueDB.Title, venueDB.TotalCapacity, venueDB.Vacancy, venueDB.CreatedOn, venueDB.UserID);
                        Program.venuesManagement.Put(booking.bookingVenue.venue.ID, Venue);
                        Program.venuesList.Add(Venue);

                        if (userDB.Email == Program.loggedInUser.Email)
                        {
                            if (!Program.hiredVenue.ContainsKey(Program.loggedInUser))
                            {
                                hiredVenueList.Add(Venue);
                                Program.hiredVenue.Add(Program.loggedInUser, hiredVenueList);
                            }
                            else
                            {
                                if (!Program.hiredVenue[Program.loggedInUser].Contains(Venue))
                                {
                                    hiredVenueList.Add(Venue);
                                }
                                Program.hiredVenue[Program.loggedInUser] = hiredVenueList;
                            }
                        }
                    }

                }
            }
            
            PrintDataGridVews();

        }

        private void btnReview_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            string createdBy = txtCreatedBy.Text;

            var userDB = db.Users.FirstOrDefault(u => u.Email == createdBy);

            var bookingDB = db.Bookings.Join(
                db.Venues,
                booking => booking.VenueID,
                venue => venue.ID,
                (booking, venue) => new { booking, venue }
                ).Join(
                db.Users,
                bookingVenue => bookingVenue.booking.UserID,
                user => user.ID,
                (bookingVenue, user) => new { bookingVenue, user }
                )
                .FirstOrDefault(joined => 
                joined.bookingVenue.venue.UserID == userDB.ID &&
                joined.bookingVenue.venue.Title == title &&
                joined.bookingVenue.booking.UserID == db.Users.FirstOrDefault(u => u.Email == Program.loggedInUser.Email).ID
                );

            if (bookingDB != null)
            {
                string reviewText = txtNote.Text;
                var Review = new Review
                {
                    UserID = bookingDB.bookingVenue.booking.UserID,
                    VenueID = bookingDB.bookingVenue.booking.VenueID,
                    Rating = Convert.ToInt16(comboRating.Text),
                    ReviewText = reviewText,
                    ReviewDate = DateTime.UtcNow.Date.ToString("dd-MM-yyyy")
                };
                db.Reviews.Add(Review);
                db.SaveChanges();

                txtTitle.Text = "";
                txtCreatedBy.Text = "";
                txtNote.Text = "";
                comboRating.Text = "5";

                PrintDataGridVews();
            }

        }

        private void PrintDataGridVews()
        {
            var reviews = db.Reviews.Join(
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

            List<Venue> list = new List<Venue>();
            
            foreach (var hv in Program.hiredVenue)
            {
                if (hv.Key == Program.loggedInUser)
                {
                    foreach (Venue venue in hv.Value)
                    {
                        list.Add(venue);
                    }
                }

            }

            dataGridVewReviews.Rows.Clear();
            dataGridViewHiredVenues.Rows.Clear();

            foreach (var item in list)
            {
                string category;
                if (item.Category == Category.AcademicAndEducationalEvents)
                {
                    category = "Academic & Educational Events";
                }
                else if (item.Category == Category.SocialEvents)
                {
                    category = "Social Events";
                }
                else if (item.Category == Category.CulturalAndEntertainmentEvents)
                {
                    category = "Cultural & Entertainment Events";
                }
                else
                {
                    category = "Business & Networking Events";
                }
                dataGridViewHiredVenues.Rows.Add(
                    Program.loggedInUser.Name,
                    Program.loggedInUser.Email,
                    category,
                    item.Title,
                    db.Users.FirstOrDefault(u => u.ID == item.UserID).Email,
                    item.TotalCapacity,
                    item.Vacancy
                );

                foreach (var review in reviews)
                {
                    dataGridVewReviews.Rows.Add(
                        Program.loggedInUser.Name,
                        Program.loggedInUser.Email,
                        item.Title,
                        db.Users.FirstOrDefault(u => u.ID == item.UserID).Email,
                        review.reviewVenue.review.Rating,
                        review.reviewVenue.review.ReviewText,
                        review.reviewVenue.review.ReviewDate
                    );
                }

            }


        }
    }
}
