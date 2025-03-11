using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Event_Management.Models
{
    public class Role_Model
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string URole { get; set; }
        public List<User_Model> Users { get; set; }
    }
}
