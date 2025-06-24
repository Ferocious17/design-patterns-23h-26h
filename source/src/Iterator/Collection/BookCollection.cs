using DesignPatterns.Iterator.Interface;
using DesignPatterns.Iterator.Iterator;
using DesignPatterns.Iterator.Model;

namespace DesignPatterns.Iterator.Collection;

public class BookCollection : IBookCollection
{
    private List<Book> _books = [];

    public int Count => _books.Count;
    public Book this[int index] => _books[index];

    public void AddBook(Book book)
    {
        _books.Add(book);
    }

    public IIterator<Book> CreateIterator()
    {
        return new BookIterator(this);
    }
}
