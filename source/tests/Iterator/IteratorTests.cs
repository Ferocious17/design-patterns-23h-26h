using DesignPatterns.Iterator.Collection;
using DesignPatterns.Iterator.Model;
using Xunit;

namespace DesignPatterns.Tests.Iterator;

public class IteratorTests
{
    [Fact]
    public void AddBook_ShouldIncreaseCount()
    {
        // Arrange
        var collection = new BookCollection();

        // Act
        collection.AddBook(new Book("Test Book", "Author name"));

        // Assert
        Assert.Equal(1, collection.Count);
    }

    [Fact]
    public void CreateIterator_ShouldReturnBooksInCorrectOrder()
    {
        // Arrange
        var collection = new BookCollection();
        collection.AddBook(new Book("Book A", "Author name"));
        collection.AddBook(new Book("Book B", "Author name"));
        collection.AddBook(new Book("Book C", "Author name"));

        var iterator = collection.CreateIterator();

        // Act
        var titles = new List<string>();
        for (Book book = iterator.First(); !iterator.IsDone; book = iterator.Next())
        {
            titles.Add(book.Title);
        }

        // Assert
        Assert.Equal(new List<string> { "Book A", "Book B", "Book C" }, titles);
    }

    [Fact]
    public void Iterator_ShouldHandleEmptyCollection()
    {
        // Arrange
        var collection = new BookCollection();
        var iterator = collection.CreateIterator();

        // Act
        Assert.Throws<InvalidOperationException>(iterator.First);
    }

    [Fact]
    public void CurrentItem_ShouldReturnCorrectBook()
    {
        // Arrange
        var collection = new BookCollection();
        collection.AddBook(new Book("Book X", "Author name"));
        collection.AddBook(new Book("Book Y", "Author name"));
        var iterator = collection.CreateIterator();

        // Act
        iterator.First();
        var first = iterator.CurrentItem;

        iterator.Next();
        var second = iterator.CurrentItem;

        // Assert
        Assert.Equal("Book X", first.Title);
        Assert.Equal("Book Y", second.Title);
    }
}
