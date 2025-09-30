using peace_kenya_api.BaseEntities;
using System.ComponentModel.DataAnnotations;

namespace peace_kenya_api.Models
{
    public class ContactUs : BaseEntity
    {
        [Key]
        public long ContactUsId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string Message { get; set; }
        //public bool SubscribeToUpdates { get; set; } = false;
    }
}