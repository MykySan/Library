using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    public class BookRepository : IBookRepository
    {
        private List<Book> _books = new();

        public void Add(Book book)
        {
            _books.Add(book);
        }
        public void Remove(Book book)
        {
            _books.Remove(book);
        }
        public IEnumerable<Book> SearchBooksByTitle(string title)
        {
            return _books.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
        }
        public IEnumerable<Book> SearchBooksByAuthor(string author)
        {
            return _books.Where(b => b.Author.Contains(author, StringComparison.OrdinalIgnoreCase));
        }
        public IEnumerable<Book> SerachBookByPublisher(string publisher)
        {
            return _books.Where(b => b.Publisher.Contains(publisher, StringComparison.OrdinalIgnoreCase));
        }
    }
}