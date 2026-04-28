namespace LibraryApp;

public class Book
{
   public Book(string name, string author)
   {
        _name = string.Join(" ", name.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries));
        _author = author.ToLower();
   }
   
   private string _name = "";
   private string _author = "";
   private int _id = 0;
   
   public string Name { get => _name; set => _name = value;}
   public string Author { get => _author ; set => _author = value; }
   public int Id { get => _id; set  => _id = value; }
}
