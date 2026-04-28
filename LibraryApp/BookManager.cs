using System.Text;

namespace LibraryApp;

public class BookManager
{
    private  Dictionary<string, Book> _books = new Dictionary<string, Book>();
    private int _count = 0;
    public void PrintBook(Book book)
    {
        Console.WriteLine("Id : " + book.Id);
        Console.WriteLine("Name : " + book.Name);
        Console.WriteLine("Author : " + book.Author);
    }

    public void AddBook(Book book)
    {
        if (string.IsNullOrWhiteSpace(book.Name) || string.IsNullOrWhiteSpace(book.Author))
        {
            Console.WriteLine("Book information is empty");
            return;
        }
        
        if (_books.ContainsKey(book.Name))
        {
            Console.WriteLine("Book already exists");
            return;
        }
        
        book.Id = _count++;
        _books[book.Name] = book;
        Console.WriteLine("Book added");
    }

    public void BookIterator()
    {
        if (_count > 0)
        {
            foreach (var book in _books.Values)
            {
                PrintBook(book);
                Console.WriteLine("--------");
            }
        }
        else
            Console.WriteLine("No books found");
    }

    public void DeleteBook(string book)
    {
        string editedName = string.Join(" ", book.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries));
        
        if (_books.ContainsKey(editedName))
        {
            _books.Remove(editedName);
            _count--;
            Console.WriteLine("Book deleted");
        }
        else
        {
            Console.WriteLine("Book not found");
        }
    }

    public void SearchBook(string book)
    {   
        string editedName = string.Join(" ", book.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries));
        
        if (_books.ContainsKey(editedName))
            PrintBook(_books[editedName]);
        else
        {
            Console.WriteLine("Book not found");
        }
    }
}
