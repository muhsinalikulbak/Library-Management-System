namespace LibraryApp;

    public interface IBookRepository
    {
        void Add(Book book);
        void Delete(int id);
        Book? GetById(int id);
        List<Book>? GetAll();
        bool BookExists(string name, int authorId);
    }
    