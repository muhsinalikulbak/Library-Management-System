namespace LibraryApp;

public class Book
{
    public string  Title { get; set; }
    public int Id { get; set; }
    public int AuthorId { get; set; }
    public Author Author { get; set; }
    
    public Book(string title, Author author)
    {
        Title = string.Join(" ", title.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries));
        Author = author;
        AuthorId =  author.Id;
    }
}
