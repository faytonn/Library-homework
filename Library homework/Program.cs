using Library_homework;
using Library_homework.Models;

Library<Book> library = new Library<Book>(100);

bool systemProcess = true;

while (systemProcess)
{
    Console.WriteLine("Welcome to the Library Management System!");
    Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");

    Console.WriteLine("Menu:");
    Console.WriteLine("[1] Add book");
    Console.WriteLine("[2] Show book info");
    Console.WriteLine("[3] Sell book");
    Console.WriteLine("[4] Remove book");
    Console.WriteLine("[5] Exit");

    string command = Console.ReadLine();

    switch (command)
    {
        case "1":
            AddingBook(library);
            break;
        case "2":
            ShowBookInfo(library);
            break;
        case "3":
            SellBook(library);
            break;
        case "4":
            RemoveBook(library); 
            break;
        case "5":
            Console.WriteLine("Terminating program........");
            systemProcess = false;
            break;
    }

}


static void AddingBook(Library<Book> library)
{
    Console.Write("Enter book name: ");
    string bookName = Console.ReadLine();

    Console.Write("Enter book price: ");
    decimal bookPrice = decimal.Parse(Console.ReadLine());

    Console.Write("Enter book count: ");
    int bookCount = int.Parse(Console.ReadLine());

    Console.Write("Enter author name: ");
    string authorName = Console.ReadLine();

    Console.Write("Page count: ");
    int pageCount = int.Parse(Console.ReadLine());

    Book book = new Book(bookName, bookPrice, bookCount, authorName, pageCount);

    try
    {
        library.AddBook(book);
        Console.WriteLine("Book added successfully!");
    }
    catch (CapacityLimitException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

static void ShowBookInfo(Library<Book> library)
{
    Console.Write("Enter book ID to show info: ");
    int bookId = int.Parse(Console.ReadLine());

    try
    {
        library.GetBookById(bookId);
    }
    catch (NotFoundException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

static void SellBook(Library<Book> library)
{
    Console.Write("Enter book ID to sell: ");
    int id = int.Parse(Console.ReadLine());

    try
    {
        foreach (var book in library.Books)
        {
            if (book.Id == id)
            {
                book.Sell();
                Console.WriteLine("Book sold successfully.");
                return;
            }
        }
        throw new NotFoundException("Book with the entered ID not found.");
    }
    catch (NotFoundException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (ProductCountIsZeroException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}


static void RemoveBook(Library<Book> library)
{
    Console.Write("Enter book ID to remove: ");
    int id = int.Parse(Console.ReadLine());

    try
    {
        library.RemoveById(id);
    }
    catch (NotFoundException ex)
    {
        Console.WriteLine(ex.Message);
    }
}

