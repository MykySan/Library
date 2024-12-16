using System;


namespace Library
{
    public class LibraryService
    {
        public readonly IBookRepository _repository;
        private readonly List<Book> _borrowedBooks = new();

        public LibraryService(IBookRepository repository)
        {
            _repository = repository;
        }
        public void DonateBook(Book book)
        {
            _repository.Add(book);
            Console.WriteLine($"Book {book.Title} donated.");
        }
        public void BorrowBook(string title)
        {
            var book = _repository.SearchBooksByTitle(title).FirstOrDefault();
            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }
            _borrowedBooks.Add(book);
            _repository.Remove(book);
            Console.WriteLine($"Book {book.Title} borrowed.");
        }
        public void ReturnBook(Book book)
        {
            if (_borrowedBooks.Contains(book))
            {
                _borrowedBooks.Remove(book);
                _repository.Add(book);
                Console.WriteLine($"Book {book.Title} returned.");
            }
            else
            {
                Console.WriteLine("Book not borrowed.");
            }
        }
        public void RenamePublisher(string oldPublisher, string newPublisher)
        {
            var books = _repository.SerachBookByPublisher(oldPublisher).ToList();
            foreach (var book in books)
            {
                book.RenamePublisher(newPublisher);
            }
            Console.WriteLine($"Publisher {oldPublisher} renamed to {newPublisher}");
        }
    }
}