namespace LibraryApp;

public class Book
{ 
    private static int _counter = 0; 
    public Book(string name)
    {
        _id = _counter++; 
        name = string.Join(" ", name.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries));
    }

    private string _name = "";
    private string _author = "";
    private int _id = 0;

    public string Author { get => _author; set => _author = value; }
    public string Name { get => _name; set => _name = value;}
    public int Id { get => _id; set  => _id = value; }
}
