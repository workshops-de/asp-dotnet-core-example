using System.ComponentModel.DataAnnotations;

namespace BookMonkey.Services.Models
{
    public class Book
    {
        public string Isbn { get; set; }

        [Required]
        [MinLength(5)]
        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string Abstract { get; set; }

        [Range(0, int.MaxValue)]
        public int NumPages { get; set; }

        [Required]
        public string Author { get; set; }

        public string Publisher { get; set; }
    }
}
