using System.ComponentModel.DataAnnotations;

namespace UniWeb.Data.Models
{

    public enum Sector
    {
        [Display(Name = "Tech")]
        Tech,
        [Display(Name = "Investment")]
        Investment,
        [Display(Name = "Bank")]
        Bank,
        [Display(Name = "Healthcare")]
        Healthcare,
        [Display(Name = "Energy")]
        Energy,
        [Display(Name = "Consumer Goods")]
        ConsumerGoods,
        [Display(Name = "Index")]
        Index
    }
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

        [EnumDataType(typeof(Sector))]
        public Sector sector { get; set; }

    }
}
