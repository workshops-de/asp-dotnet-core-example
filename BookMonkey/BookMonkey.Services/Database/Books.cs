using System;
using System.Collections.Generic;

namespace BookMonkey.Services.Database
{
    public partial class Books
    {
        public long Id { get; set; }
        public string Abstract { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public long NumPages { get; set; }
        public long? PublisherId { get; set; }
        public string Subtitle { get; set; }
        public string Title { get; set; }

        public virtual Publishers Publisher { get; set; }
    }
}
