using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Event_Management.Models
{
    public class User_Model
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Postcode { get; set; }
        [Required]
        public string DateOfBirth { get; set; }
        public int? GenderID { get; set; }
        [ForeignKey("GenderID")]
        public Gender_Model Gender { get; set; }
        public int? RoleID { get; set; }
        [ForeignKey("RoleID")]
        public Role_Model Role { get; set; }
        [Required]
        public string Pass { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Booking> Bookings { get; set; }
        public List<Venue_Model> Venues { get; set; }
    }
}
