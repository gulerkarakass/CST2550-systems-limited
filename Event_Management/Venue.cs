using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management
{
    public class Venue
    {
        public Category Category { get; set; }
        public string Title { get; set; }
        public int TotalCapacity { get; set; }
        public int Vacancy { get; set; }
        public string CreatedOn { get; set; }
        public int? UserID { get; set; }
        public Venue(Category category, string title, int totalCapacity, int vacancy, string createdOn, int? userId)
        {
            Category = category;
            Title = title;
            TotalCapacity = totalCapacity;
            Vacancy = vacancy;
            CreatedOn = createdOn;
            UserID = userId;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"Venues's category, title, total slots, available slots, created date, and created by: {Category}, {Title}, {TotalCapacity}, {Vacancy}, {CreatedOn}, {UserID}");

            return sb.ToString();
        }
    }
}
