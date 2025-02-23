using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CST2550_systems_limited
{
    public class Venue
    {
        public string Title { get; set; }
        public string CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Venue(string title, string createdOn, string createdBy)
        {
            Title = title;
            CreatedOn = createdOn;
            CreatedBy = createdBy;
        }
        

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"Venues's title, created date and time, and created by: {Title}, {CreatedOn}, {CreatedBy}");

            return sb.ToString();
        }
    }
}
