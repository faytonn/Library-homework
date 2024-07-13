namespace Library_homework;

public class Library<T>
{
    private List<Book> Books = new List<Book>();
    private static int _id;
    public int Id { get; set; }
    public int BookLimit
    {
        get
        {
            return BookLimit;
        }
        private set
        {
            if (BookLimit < 0)
            {
                throw new Exception("Book limit should be greater than 0");
            }
            BookLimit = value;
        }
    }

    public Library(int bookLimit)
    {
        BookLimit = bookLimit;
        Books = new List<Book>();
    }

    public void AddBook(Book book)
    {
        if (Books.Count > BookLimit)
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
            }
        }
        throw new NotFoundException("Book with the entered ID not found.");

    }
}
