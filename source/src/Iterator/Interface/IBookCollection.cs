using DesignPatterns.Iterator.Model;

namespace DesignPatterns.Iterator.Interface;

public interface IBookCollection
{
    IIterator<Book> CreateIterator();
}
