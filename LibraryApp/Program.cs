using Microsoft.Extensions.Configuration;

namespace LibraryApp;
class Program
{
    static void Main(string[] args)
    {
        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
            .Build();

        string? connectionString = config.GetConnectionString("LibraryDb");
        if (string.IsNullOrWhiteSpace(connectionString))
            throw new InvalidOperationException("Connection string 'LibraryDb' was not found.");

        IAuthorRepository authorRepo = new AuthorAdoNetRepository(connectionString);
        IBookRepository adoNet = new AdoNetBookRepository(connectionString);
        
        AuthorManager authorManager = new AuthorManager(authorRepo);
        BookManager bookManager = new BookManager(adoNet, authorManager);
        

        Author auth = new Author("Yaşar Kemal");
        Book book = new Book("ince memed", auth);
        
        if (bookManager.AddBook(book))
            Console.WriteLine("✓ Kitap başarıyla eklendi.");
        else
            Console.WriteLine("✗ Kitap zaten mevcut!");
    }
}
