using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Event_Management.Models
{
    public class Category_Model
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Category { get; set; }
        public List<Venue_Model> Venues { get; set; }
    }
}
