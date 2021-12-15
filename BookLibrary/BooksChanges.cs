using System;

namespace BookLibrary
{
    public class BooksChanges
    {
            public int id { get; set; }
            public string field { get; set; }
            public string newVal { get; set; }
            public string _event { get; set; }
            public object oldVal { get; set; }
            public DateTime timestamp { get; set; }
    }
}
