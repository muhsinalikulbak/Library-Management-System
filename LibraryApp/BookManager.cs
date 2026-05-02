using System.Text;

namespace LibraryApp;

public class BookManager
{
    IBookRepository _bookRepository;

    public BookManager(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public void AddBook(Book book)
    {
        if (_bookRepository.GetById(book.Id) == null)
        {
            _bookRepository.Add(book);
            Console.WriteLine("Book added");
        }
        else
        {
            Console.WriteLine("The book could not be added");
        }
    }

    public void DeleteBook(Book book)
    {
        // Var olup olmadığına nasıl bakıcam
        _bookRepository.Delete(book.Id);
    }

    public void SearchBook(Book book)
    {
        // _bookRepository.Search(book);
    }
    
    public List<Book> GetAll()
    {
        // Neden Liste kullanıyoruz zaten tüm veriler artık veri tabanında
        return _bookRepository.GetAll();
    }
}
