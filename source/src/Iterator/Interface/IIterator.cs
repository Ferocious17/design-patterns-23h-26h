namespace DesignPatterns.Iterator.Interface;

public interface IIterator<T>
{
    bool IsDone { get; }
    T CurrentItem { get; }
    T First();
    T Next();
}
