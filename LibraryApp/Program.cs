using System.Data.SqlTypes;


namespace LibraryApp;
class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Server=localhost;Database=LibraryDB;User Id=sa;Password=Puravita270883.;TrustServerCertificate=True;";        AdoNetBookRepository adonet = new AdoNetBookRepository(connectionString);
        BookManager bookManager = new BookManager(adonet);
        
        bookManager.AddBook(new Book(5,"Intermezzo"));
    }
}