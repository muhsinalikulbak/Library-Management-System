namespace LibraryApp;

public interface IAuthorRepository
{
    public Author? GetAuthorById(int id);
    public Author? GetAuthorByName(string name);
    public Author? GetOrCreateAuthor(string name);
    public void DeleteAuthor(int id);
    public void AddAuthor(Author author);
}