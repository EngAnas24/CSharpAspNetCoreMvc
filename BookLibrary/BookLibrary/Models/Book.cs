using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Models
{
    public class Book
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string AuthorNameList  { get; set; }
        public int AuthorId { get; set; }
         public Author author { get; set; }

    }
}
