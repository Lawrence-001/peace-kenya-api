using peace_kenya_api.BaseEntities;
using System.ComponentModel.DataAnnotations;

namespace peace_kenya_api.Models
{
    public class NewsLetter : BaseEntity
    {
        [Key]
        public long NewsLetterId { get; set; }
        public string Email { get; set; }


    }
}
