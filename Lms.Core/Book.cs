namespace Lms.Core
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int Year { get; set; }
        public bool IsAvailable { get; set; } = true;

        public Book(int id, string title, string author, string isbn, int year)
        {
            Id = id;
            Title = title;
            Author = author;
            ISBN = isbn;
            Year = year;
            IsAvailable = true;
        }

        public override string ToString()
        {
            return $"{Id}: {Title} by {Author} ({Year}) - ISBN: {ISBN} - " +
                   (IsAvailable ? "Available" : "Not Available");
        }
    }
}
 
