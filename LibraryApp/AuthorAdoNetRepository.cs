using Microsoft.Data.SqlClient;

namespace LibraryApp;
public class AuthorAdoNetRepository (string connectionString): IAuthorRepository
{
    private readonly string _connectionString = connectionString;
    
    public void AddAuthor(Author author)
    {
        if (author == null)
            throw new ArgumentNullException(nameof(author));
        if (string.IsNullOrWhiteSpace(author.Name))
            throw new ArgumentException("Author name cannot be empty.", nameof(author.Name));

        using (SqlConnection con = new SqlConnection(_connectionString))
        {
            SqlCommand cmd = new SqlCommand($"Insert into Authors (AuthorName) values (@name)", con);
            cmd.Parameters.AddWithValue("@name", author.Name);
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
    public void DeleteAuthor(int id)
    {
        if (id <= 0)
            throw new ArgumentException("ID must be greater than 0.", nameof(id));

        using (SqlConnection con = new SqlConnection(_connectionString))
        {
            SqlCommand cmd = new SqlCommand("Delete From Authors WHERE Id = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
    public Author? GetAuthorByName(string name)
    {   
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Author name cannot be empty.", nameof(name));

        Author? author = null;
        using (SqlConnection con = new SqlConnection(_connectionString))
        {
            SqlCommand cmd = new SqlCommand(
                "Select Id, AuthorName from Authors WHERE AuthorName = @name COLLATE SQL_Latin1_General_CP1_CI_AS", con);
            cmd.Parameters.AddWithValue("@name", name);
            con.Open();
            
            using SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                author = new Author(reader["AuthorName"].ToString());
                author.Id = (int)reader["Id"];
            }
        }
        return author;
    }
    public Author GetAuthorById(int id)
    {
        if (id <= 0)
            throw new ArgumentException("ID must be greater than 0.", nameof(id));

        Author? author = null;
        using (SqlConnection con = new SqlConnection(_connectionString))
        {
            SqlCommand cmd = new SqlCommand("Select AuthorName from Authors WHERE Id = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            
            using SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                author = new Author(reader["AuthorName"].ToString());
                author.Id = id;
            }
        }
        return author;
    }

    
    public Author GetOrCreateAuthor(string name)
    {
        Author? author = GetAuthorByName(name);
        if (author is not null)
            return author;

        using (SqlConnection con = new SqlConnection(_connectionString))
        {
            SqlCommand cmd = new SqlCommand("Insert into Authors (AuthorName) values (@name)", con);
            cmd.Parameters.AddWithValue("@name", name);
            con.Open();
            cmd.ExecuteNonQuery();
        }
        return GetAuthorByName(name);
    }
}