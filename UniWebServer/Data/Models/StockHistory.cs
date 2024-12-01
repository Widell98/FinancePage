using UniWeb.Data.Models;

namespace UniWebServer.Data.Models
{
    public class StockHistory
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public string? AnalysisImagePath { get; set; }
        public string? Description { get; set; }
        public DateTime UploadDate { get; set; } = DateTime.Now;
        public Stock Stock { get; set; }
    }

}
