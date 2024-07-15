using Library_homework.Models;

namespace Library_homework;

public class Library<T>
{
    public List<Book> Books;
    private static int _id;
    public int Id { get; set; }
    private static int _bookLimit;
    public int BookLimit
    {
        get
        {
            return _bookLimit;
        }
        private set
        {
            if (_bookLimit < 0)
            {
                throw new Exception("Book limit should be greater than 0");
            }
            _bookLimit = value;
        }
    }

    public Library(int bookLimit)
    {
        Id = ++_id;
        BookLimit = bookLimit;
        Books = new List<Book>(bookLimit);
    }

    public void AddBook(Book book)
    {
        if (Books.Count >= BookLimit)
        {
            throw new CapacityLimitException("Book count exceeded limit.");
        }
        Books.Add(book);
    }

    public void GetBookById(int id)
    {
        foreach (var book in Books)
        {
            if (book.Id == id)
            {
                Console.WriteLine(book);
                return;
            }
        }
        throw new NotFoundException("Book with the entered ID not found.");
    }
    public void RemoveById(int id)
    {
        for (int i = 0; i < Books.Count; i++)
        {
            if (Books[i].Id == id)
            {
                Books.Remove(Books[i]);
                Console.WriteLine("Book successfully removed.");
                return;
            }
        }
        throw new NotFoundException("Book with the entered ID not found.");
    }
    public void ShowAllBooks()
    {
        foreach(var book in Books)
        {
            book.ShowInfo();
        }
    }


}
