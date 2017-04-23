namespace BookMonkey.Models
{
    public class Book
    {
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Abstract { get; set; }
        public int NumPages { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
    }
}
