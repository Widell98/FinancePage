using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniWebServer.Data.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }

}
