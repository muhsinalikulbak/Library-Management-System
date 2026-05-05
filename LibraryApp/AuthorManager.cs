namespace LibraryApp;
using System.Data;
using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;

public class AuthorManager (IAuthorRepository repository)
{
    private readonly IAuthorRepository _authorRepository = repository;
    public void AddAuthor(Author author)
    {
        if (string.IsNullOrWhiteSpace(author.Name))
            return;
        _authorRepository.AddAuthor(author);
    }

    public void DeleteAuthor(int id)
    {
        if (id <= 0)
            throw new ArgumentException("ID must be greater than 0.", nameof(id));
        
        _authorRepository.DeleteAuthor(id);
    }

    public Author? GetByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Author name cannot be empty.", nameof(name));
            
        Author? author = _authorRepository.GetAuthorByName(name);
        return author;
    }
    
    public Author? GetById(int id)
    {
        if (id <= 0)
            throw new ArgumentException("ID must be greater than 0.", nameof(id));
            
        Author? author = _authorRepository.GetAuthorById(id);
        return author;
    }
    public Author? GetOrCreateAuthor(string name)
    {
        return _authorRepository.GetOrCreateAuthor(name);
    }
}

