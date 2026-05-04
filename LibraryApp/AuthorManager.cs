namespace LibraryApp;
using System.Data;
using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;

public class AuthorManager (string connectionString)
{
    private readonly string _connectionString = connectionString;
    
    public bool AddAuthor(string name)
    {
        return true;
    }

    public  bool DeleteAuthor(string name)
    {
        return true;
    }

    public Author? GeyByName(string name)
    {
        Author? author = null;

        using (SqlConnection con = new SqlConnection(_connectionString))
        {
            SqlCommand cmd = new SqlCommand("select * from Authors where Name = @name", con);
            cmd.Parameters.AddWithValue("@name", name);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                author = new Author(reader["AuthorName"].ToString());
                author.Id = int.Parse(reader["Id"].ToString());
            }
        }
        return author;
    }
    
    public Author? GetById(int id)
    {
        Author? author = null;
        using (SqlConnection con = new SqlConnection(_connectionString))
        {
            SqlCommand cmd = new SqlCommand("select * from Authors where Id = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                author = new Author(reader["AuthorName"].ToString());
            }
        }
        return author;
    }
}