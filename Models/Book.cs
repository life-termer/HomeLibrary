using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeLibrary.Models
{
    public enum Type
    {
        Hardcover, Paperback
    }
    public class Book
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        public string Genre { get; set; }
        
        public Type Type { get; set; }
        public string Language { get; set; }
        [Display(Name = "Publication date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PublicDate { get; set; }
        [Range(1, 9999)]
        public int Length { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}