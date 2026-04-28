namespace LibraryApp;

class Program
{
    static void Main(string[] args)
    {
        BookManager bookManager = new BookManager();
        int choice = 0;
        bool cont;
        string name;
        string author;
        
        while (true)
        {
            Console.Write("Please enter choice: ");
            cont = int.TryParse(Console.ReadLine(), out choice);
            if (!cont)
            {   
                Console.WriteLine("Invalid choice");
                continue;
            }

            switch (choice)
            {
                case 1:
                {
                    Console.Write("Plase enter book name : ");
                    name = Console.ReadLine();
                    Console.Write("Plase enter author : ");
                    author = Console.ReadLine();
                    
                    Book book = new Book(name, author);
                    bookManager.AddBook(book);
                }
                    break;
                case 2:
                {
                    bookManager.BookIterator();
                }
                    break;
                case 3:
                {
                    Console.Write("Please enter a book name: ");
                    name = Console.ReadLine();
                    bookManager.SearchBook(name);
                }
                    break;
                case 4:
                {
                    Console.Write("Please enter a book name: ");
                    name = Console.ReadLine();
                    bookManager.DeleteBook(name);
                }
                    break;
                case 5:
                {
                    Console.WriteLine("Quit");
                    Environment.Exit(0);
                }
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}