using System.Text;

namespace LibraryApp;

public class BookManager(IBookRepository bookRepository)
{
    private readonly IBookRepository _bookRepository = bookRepository;

    public void AddBook(Book book)
    {
        
        // Önce yazarı var mı diye kontrol et
        // Yazarı yoksa önce yazarı sonra kitabı ekle
        // yazarı varsa, yazarı çek
        // Kitabı eklerken yazarının id'sini eklemeyi unutma
    }

    public void DeleteBook(Book book)
    {
        // Kitap ismine ve yazarına göre and olarak arat
        // Varsa sil 
    }

    public void SearchBook(Book book)
    {
    }
    
    public List<Book> GetAll()
    {
        return _bookRepository.GetAll();
    }
}
