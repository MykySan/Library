using System;
using Library;

public interface IBookRepository
{
    void Add(Book book);
    void Remove(Book book);
    IEnumerable<Book> SearchBooksByTitle(string title);
    IEnumerable<Book> SearchBooksByAuthor(string author);
    IEnumerable<Book> SerachBookByPublisher(string publisher);

}