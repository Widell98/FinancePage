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

        public string Name { get; set; }

        public string? Description { get; set; }     
      
        public DateTime DateTime { get; set; }

        [EnumDataType(typeof(Sector))]

        public Sector sector { get; set; }

        public byte[]? LogoImageData { get; set; }

        public string? LogoImageType { get; set; }

        public byte[]? AnalysisImageData { get; set; } 

        public string? AnalysisImageType { get; set; }

    }
}
