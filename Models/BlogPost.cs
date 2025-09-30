using peace_kenya_api.BaseEntities;
using System.ComponentModel.DataAnnotations;

namespace peace_kenya_api.Models
{
    public class BlogPost : BaseEntity
    {
        [Key]
        public long BlogPostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
        public bool Published { get; set; } = false;

    }
}