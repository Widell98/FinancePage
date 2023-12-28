using System.ComponentModel.DataAnnotations;

namespace UniWeb.Data.Models
{
    public class Stock
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }      
        public int Price { get; set; }

    }
}
