namespace LibraryApp;

    public interface IBookRepository
    {
        void Add(Book book);
        void Delete(int id);
        Book GetById(int id);
        
        void Update(Book book);
        List<Book> GetAll();
    }