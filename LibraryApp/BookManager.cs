using System.Text;

namespace LibraryApp;

public class BookManager(IBookRepository bookRepository, AuthorManager authorManager)
{
    private readonly IBookRepository _bookRepository = bookRepository;
    private readonly AuthorManager _authorManager = authorManager;

    public bool AddBook(Book book)
    { 
        if (book == null)
            throw new ArgumentNullException(nameof(book));
        if (string.IsNullOrWhiteSpace(book.Title))
            throw new ArgumentException("Book title cannot be empty.", nameof(book.Title));
        if (book.Author == null)
            throw new ArgumentNullException(nameof(book.Author));
        if (string.IsNullOrWhiteSpace(book.Author.Name))
            throw new ArgumentException("Author name cannot be empty.", nameof(book.Author.Name));

        Author? author = _authorManager.GetOrCreateAuthor(book.Author.Name);
        book.AuthorId = author.Id;
        
        if (!_bookRepository.BookExists(book.Title, book.AuthorId))
        {
            _bookRepository.Add(book);
            return true;
        }
        return false;
    }

    public bool DeleteBook(int id)
    {
        _bookRepository.Delete(id);
        return true;
    }
    
    public List<Book>? GetAll()
    {
        return _bookRepository.GetAll();
    }
}
