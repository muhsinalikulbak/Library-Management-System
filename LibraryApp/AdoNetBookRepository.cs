using System.Data;
using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;

namespace LibraryApp;

public class AdoNetBookRepository(string connectionString) : IBookRepository
{
    private readonly string _connectionString = connectionString;

    private Author? GetAuthorById(int id)
    {
        using (SqlConnection con = new(_connectionString))
        {
            SqlCommand cmd = new SqlCommand("Select Id, AuthorName from Authors where Id = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();

            using SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
                return null;

            Author author = new(reader["AuthorName"].ToString());
            author.Id = (int)reader["Id"];
            return author;
        }
    }

    public void Add(Book book)
    {
        if (book == null)
            throw new ArgumentNullException(nameof(book));
        if (string.IsNullOrWhiteSpace(book.Title))
            throw new ArgumentException("Book title cannot be empty.", nameof(book.Title));
        if (book.AuthorId <= 0)
            throw new ArgumentException("AuthorId must be greater than 0.", nameof(book.AuthorId));

        using (SqlConnection con = new (_connectionString))
        {
            SqlCommand cmd = new SqlCommand("Insert into Books (Title, AuthorId) values (@title, @authorId)", con);
            cmd.Parameters.AddWithValue("@title", book.Title);
            cmd.Parameters.AddWithValue("@authorId", book.AuthorId);
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
    
    public void Delete(int id)
    {
        if (id <= 0)
            throw new ArgumentException("ID must be greater than 0.", nameof(id));

        using (SqlConnection con = new (_connectionString))
        {
            SqlCommand cmd = new SqlCommand("Delete from Books where Id = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
    
    public Book? GetById(int id)
    {
        Book? foundBook = null;
        
        using (SqlConnection con = new (_connectionString))
        {
            SqlCommand cmd = new SqlCommand("select * from Books where Id = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Author? author = GetAuthorById((int)reader["AuthorId"]);
                if (author is null)
                    throw new InvalidOperationException($"Author with id {(int)reader["AuthorId"]} was not found.");

                foundBook = new Book(reader["Title"].ToString(), author);
                foundBook.Id = id;
            }
        }
        return foundBook;
    }
    
    public List<Book> GetAll()
    {
        List<Book> bookList = new List<Book>();
        
        using (SqlConnection con = new (_connectionString))
        {
            SqlCommand cmd = new SqlCommand(
                "SELECT b.Id, b.Title, b.AuthorId, a.Id AS AuthorId2, a.AuthorName " +
                "FROM Books b " +
                "INNER JOIN Authors a ON b.AuthorId = a.Id", con);
            con.Open();
            
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Author author = new(reader["AuthorName"].ToString())
                {
                    Id = (int)reader["AuthorId2"]
                };

                Book book = new Book(reader["Title"].ToString(), author)
                {
                    Id = (int)reader["Id"]
                };
                bookList.Add(book);
            }
        }
        return bookList;
    }

    public bool BookExists(string name, int authorId)
    {
        using (SqlConnection con = new(_connectionString))
        {
            SqlCommand cmd = new SqlCommand(
                "Select Count(Title) from Books where AuthorId = @id and Title = @name COLLATE SQL_Latin1_General_CP1_CI_AS", con);
            cmd.Parameters.AddWithValue("@id", authorId);
            cmd.Parameters.AddWithValue("@name", name);
            con.Open();
            
            object? scalar = cmd.ExecuteScalar();
            return scalar is not null && Convert.ToInt32(scalar) > 0;
        }
    }
    
}
