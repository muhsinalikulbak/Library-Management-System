using System.Data;
using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;

namespace LibraryApp;

public class AdoNetBookRepository : IBookRepository
{
    readonly string _connectionString;
    readonly List<Book> _books = new List<Book>();

    public AdoNetBookRepository(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    public void Add(Book book)
    {
        SqlConnection con = new SqlConnection(_connectionString);
        try
        {
            SqlCommand cmd = new SqlCommand("insert into Books (Title) values (@title)", con);
            // cmd.Parameters.AddWithValue("@id", book.Id);
            cmd.Parameters.AddWithValue("@title", book.Name);
            con.Open();
            cmd.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
        }
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
        using (SqlConnection con = new SqlConnection(_connectionString))
        {
            SqlCommand cmd = new SqlCommand("select * from Books where Id = @id", con);
            // Burası SQL Injection'dan korunmak için, eğer strint + id dersek burada sıkıntı olurdu
            cmd.Parameters.AddWithValue("@id", id);
            
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                foundBook = new Book((int)reader["Id"], reader["Title"].ToString());
            }            
        }
        return foundBook;
    }
    
    public List<Book> GetAll()
    {
        return _books;
    }
}
