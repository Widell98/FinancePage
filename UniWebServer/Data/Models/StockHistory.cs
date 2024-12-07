using UniWeb.Data.Models;

namespace UniWebServer.Data.Models
{
    public class StockHistory
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public string? Description { get; set; }
        public DateTime UploadDate { get; set; } = DateTime.Now;

        // Bilddata och typ, likt Stock-klassen
        public byte[]? AnalysisImageData { get; set; }
        public string? AnalysisImageType { get; set; }

        // Navigeringsproperty
        public Stock Stock { get; set; }
    }

}
