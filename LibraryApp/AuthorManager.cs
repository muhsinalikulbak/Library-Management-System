namespace LibraryApp;
using System.Data;
using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;

public class AuthorManager (string connectionString)
{
    private readonly string _connectionString = connectionString;
    
    public void AddAuthor(string name)
    {
        if (GeyByName(name) != null)
        {
            Console.WriteLine($"{name} already exists");
        }
    }

    public  void DeleteAuthor(string name)
    {
        Author? author = GeyByName(name);
        if (author is not null)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("delete from Authors where Name = @name", con);
                cmd.Parameters.AddWithValue("@name", name);
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Successfully deleted author");
            }
        }
        else
            Console.WriteLine($"{name} not found");
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