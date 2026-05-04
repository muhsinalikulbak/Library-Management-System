namespace LibraryApp;

public class HashMapBookRepository : IBookRepository
{
    readonly private Dictionary<int, Book> _books = new Dictionary<int, Book>();
    
    public void Add(Book book)
    {
    
    }     
    
    public void Delete(int id)
    {

    }

    public void Update(Book book)
    {
        
    }
    
    public Book GetById(int id)
    {
        if (_books.TryGetValue(id, out Book book))
            return book;
        return null;
    }
    
    public List<Book> GetAll()
    {
        return default;
    }
}