    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Event_Management.Models
{
    public class Review
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int Rating { get; set; }
        public string ReviewText { get; set; }
        [Required]
        public string ReviewDate { get; set; }
        public int? UserID { get; set; }
        [ForeignKey("UserID")]
        public User_Model User { get; set; }
        public int? VenueID { get; set; }
        [ForeignKey("VenueID")]
        public Venue_Model Venue { get; set; }
    }
}
