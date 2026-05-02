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
        return default;
    }
    
    public List<Book> GetAll()
    {
        return default;
    }
}