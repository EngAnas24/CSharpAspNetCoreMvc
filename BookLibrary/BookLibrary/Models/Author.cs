using BookLibrary.Models;
namespace BookLibrary.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string Birthday { get; set; }
        public string Deathday { get; set; }

       public ICollection<Book> Books { get; set; }


    }
}
