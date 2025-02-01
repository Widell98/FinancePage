
using System.ComponentModel.DataAnnotations;

namespace UniWebServer.Data.Models
{
    public class BlogPost
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
    }

}
