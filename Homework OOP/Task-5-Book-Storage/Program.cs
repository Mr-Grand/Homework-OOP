namespace Task_5;

class Program
{
    static void Main(string[] args)
    {
        
    }

    class Book
    {
        private string _name;
        private string _author;
        private int _year;
        private int _uniqueCode;
        
        public string Name { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public int UniqueCode { get; set; }
        

        public Book(string name, string author, int year)
        {
            _name = name;
            _author = author;
            _year = year;
        }
        
    }

    class BookShelter
    {
        private List<Book> _booksList = new();
        
        public void AddBook(Book book)
        {
            _booksList.Add(book);
        }

        public void RemoveBook(Book book)
        {
            _booksList.Remove(book);
        }

        public void ShowAllBooks()
        {
            foreach (Book book in _booksList)
            {
                Console.WriteLine($"book name: {book.Name}, author: {book.Author}," +
                                  $" year: {book.Year}, unique code: {book.UniqueCode}");
            }
        }

        private List<Book> FindBookByName(string bookName)
        {
            return _booksList.FindAll(b => b.Name == bookName);
        }
        
        private List<Book> FindBookByAuthor(string bookAuthor)
        {
            return _booksList.FindAll(b => b.Author == bookAuthor);
        }
        
        private List<Book> FindBookByYear(int bookYear)
        {
            return _booksList.FindAll(b => b.Year == bookYear);
        }
        
        private List<Book> FindBookByCode(int bookCode)
        {
            return _booksList.FindAll(b => b.UniqueCode == bookCode);
        }

        public void ShowBookByName(string bookName)
        {
            foreach (Book book in FindBookByName(bookName))
            {
                Console.WriteLine($"book name: {book.Name}, author: {book.Author}," +
                                  $" year: {book.Year},  unique code: {book.UniqueCode}");
            }
        }
        
        public void ShowBookByAuthor(string bookAuthor)
        {
            foreach (Book book in FindBookByAuthor(bookAuthor))
            {
                Console.WriteLine($"book name: {book.Name}, author: {book.Author}," +
                                  $" year: {book.Year},  unique code: {book.UniqueCode}");
            }
        }
        
        public void ShowBookByYear(int bookYear)
        {
            foreach (Book book in FindBookByYear(bookYear))
            {
                Console.WriteLine($"book name: {book.Name}, author: {book.Author}," +
                                  $" year: {book.Year},  unique code: {book.UniqueCode}");
            }
        }
        
        public void ShowBookByCode(int bookCode)
        {
            foreach (Book book in FindBookByCode(bookCode))
            {
                Console.WriteLine($"book name: {book.Name}, author: {book.Author}," +
                                  $" year: {book.Year},  unique code: {book.UniqueCode}");
            }
        }
        
        
    }
}