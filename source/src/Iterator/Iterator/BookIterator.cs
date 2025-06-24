using DesignPatterns.Iterator.Collection;
using DesignPatterns.Iterator.Interface;
using DesignPatterns.Iterator.Model;

namespace DesignPatterns.Iterator.Iterator;

public class BookIterator(BookCollection bookCollection) : IIterator<Book>
{
    private BookCollection _bookCollection = bookCollection;
    private int _currentIndex = 0;

    public Book CurrentItem => IsDone ? null : _bookCollection[_currentIndex];
    public bool IsDone => _currentIndex >= _bookCollection.Count;

    public Book First()
    {
        _currentIndex = 0;
        return _bookCollection.Count > 0 ? _bookCollection[_currentIndex] : throw new InvalidOperationException("Collection is empty");
    }

    public Book Next()
    {
        _currentIndex++;
        if (!IsDone)
            return _bookCollection[_currentIndex];

        return null;
    }
}
