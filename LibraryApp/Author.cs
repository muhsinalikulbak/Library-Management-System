namespace LibraryApp;

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Book>? Books { get; set; }

    public Author(string name)
    {
        Name = string.Join(" ", name.Split(' ', StringSplitOptions.RemoveEmptyEntries));
        Books = null;
    }
}