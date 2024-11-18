using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniWebServer.Data.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string StockSymbol { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public DateTime Date { get; set; }
    }
}
