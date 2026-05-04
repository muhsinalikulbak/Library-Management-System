using System.Data;
using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;

namespace LibraryApp;

public class AdoNetBookRepository(string connectionString) : IBookRepository
{
    private readonly string _connectionString = connectionString;
    private readonly AuthorManager _authorManager = new AuthorManager(connectionString);
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
        Book? foundBook = null;
        Author? author = null;
        
        using (SqlConnection con = new SqlConnection(_connectionString))
        {
            SqlCommand cmd = new SqlCommand("select * from Books where Id = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                author = _authorManager.GetById((int)reader["AuthorId"]);
                foundBook = new Book(reader["Title"].ToString(), author);
                foundBook.Id = id;
            }
        }
        return foundBook;
    }
    
    public List<Book> GetAll()
    {
        List<Book> bookList = new List<Book>();
        Author? author = null;
        Book? book = null;
        
        using (SqlConnection con = new SqlConnection(_connectionString))
        {
            SqlCommand cmd = new SqlCommand("select * from Books", con);
            con.Open();
            
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                author = _authorManager.GetById((int)reader["AuthorId"]);
                book = new Book(reader["Title"].ToString(), author);
                book.Id = (int)reader["Id"];
                bookList.Add(book);
            }
        }
        return bookList;
    }
}
