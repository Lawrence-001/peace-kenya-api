using peace_kenya_api.BaseEntities;
using System.ComponentModel.DataAnnotations;

namespace peace_kenya_api.Models
{
    public class Volunteer : BaseEntity
    {
        [Key]
        public long VolunteerId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Skills { get; set; }
        public string Experience { get; set; }
        public string Motivation { get; set; }
        public string Availability { get; set; }

    }
}