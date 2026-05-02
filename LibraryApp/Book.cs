namespace LibraryApp;

public class Book
{
   public Book(int id, string name)
   {
       _id = id;
       _name = string.Join(" ", name.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries));
   }
   
   private string _name = "";
   private int _id = 0;
   
   public string Name { get => _name; set => _name = value;}
   public int Id { get => _id; set  => _id = value; }
}
