using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Event_Management.Models
{
    public class Booking
    {
        [Key]
        public int ID { get; set; }
        public string ReservedDate { get; set; }
        public int? UserID { get; set; } // Make it nullable foreign key with ?
        [ForeignKey("UserID")]
        public User_Model User { get; set; }
        public int? VenueID { get; set; }
        [ForeignKey("VenueID")]
        public Venue_Model Venue { get; set; }
    }
}
