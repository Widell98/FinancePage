using System.ComponentModel.DataAnnotations;

namespace UniWeb.Data.Models
{
    public class Stock
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }      

        public int Price { get; set; }

        public DateTime DateTime { get; set; }

        public byte[]? ImageData { get; set; }

        public string? ImageType { get; set; }

    }
}
