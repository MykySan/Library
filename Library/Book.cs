using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    public class Book
    {

        public string Title { get; private set; }
        public string Author { get; private set; }
        public string Publisher { get; private set; }
        public Book(string title, string author, string publisher)
        {
            Title = title;
            Author = author;
            Publisher = publisher;
        }

        public void RenamePublisher(string newPublisher)
        {
            Publisher = newPublisher;
        }
    }
}