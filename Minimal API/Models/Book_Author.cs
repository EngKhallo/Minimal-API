namespace Minimal_API.Models
{
    public class Book_Author
    {
        public int Id { get; set; }
        public Author? Author { get; set; }
        public Book? Book { get; set; }
    }
}
