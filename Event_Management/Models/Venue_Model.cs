using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Event_Management.Models
{
    public class Venue_Model
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string CreatedOn { get; set; }
        public int? UserID { get; set; }
        [ForeignKey("UserID")]
        public User_Model User { get; set; }
        [Required]
        public int TotalCapacity { get; set; }
        [Required]
        public int Vacancy { get; set; }
        public int? CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public Category_Model Category { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}
