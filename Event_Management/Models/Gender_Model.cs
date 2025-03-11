using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management.Models
{
    public class Gender_Model
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string UGender { get; set; }
        public List<User_Model> Users { get; set; }
    }
}
