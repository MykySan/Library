using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            IBookRepository repository = new BookRepository();
            LibraryService libraryService = new LibraryService(repository);

            libraryService.DonateBook(new Book("Book 1", "Author 1", "Publisher 1"));
            libraryService.DonateBook(new Book("Book 2", "Author 2", "Publisher 2"));

            Console.WriteLine("Search by Author 1:");
            var firstauthorbooks = repository.SearchBooksByAuthor ("Author 1");
            foreach (var book in firstauthorbooks)
            {
                Console.WriteLine(book.Title);
            }

            libraryService.BorrowBook("Book 1");
            libraryService.ReturnBook(new Book("Book 1", "Author 1", "Publisher 1"));
            libraryService.RenamePublisher("Publisher 1", "New Publisher 1");
        }
    }
}
