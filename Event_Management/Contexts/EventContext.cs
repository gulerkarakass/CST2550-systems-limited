using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Event_Management.Models;
using System.Reflection.Emit;

namespace Event_Management.Contexts
{
    public class EventContext : DbContext
    {
        public EventContext() : base("event") { }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Category_Model> Categories { get; set; }
        public DbSet<Gender_Model> Genders { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Role_Model> Roles { get; set; }
        public DbSet<User_Model> Users { get; set; }
        public DbSet<Venue_Model> Venues { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User -> Venue relationship: UserID in Venue_Model
            modelBuilder.Entity<Venue_Model>()
                .HasOptional(v => v.User)  // A User can be null
                .WithMany(u => u.Venues)  // A User can have many Venues
                .HasForeignKey(v => v.UserID)
                .WillCascadeOnDelete(false);  // Prevent cascading delete

            // Venue -> Booking relationship
            modelBuilder.Entity<Booking>()
                .HasOptional(b => b.Venue)
                .WithMany(v => v.Bookings)
                .HasForeignKey(b => b.VenueID)
                .WillCascadeOnDelete(false);  // Prevent cascading delete

            // User -> Booking relationship
            modelBuilder.Entity<Booking>()
                .HasOptional(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserID)
                .WillCascadeOnDelete(false);  // Prevent cascading delete

            // Review -> Venue and User relationships
            modelBuilder.Entity<Review>()
                .HasOptional(r => r.Venue)
                .WithMany(v => v.Reviews)
                .HasForeignKey(r => r.VenueID)
                .WillCascadeOnDelete(false);  // Prevent cascading delete

            modelBuilder.Entity<Review>()
                .HasOptional(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserID)
                .WillCascadeOnDelete(false);  // Prevent cascading delete
        }



    }
}
