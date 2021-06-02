using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeLibrary.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Type { get; set; }
        public string Language { get; set; }
        public DateTime PublicDate { get; set; }
        public int Length { get; set; }
        public string Description { get; set; }
    }
}