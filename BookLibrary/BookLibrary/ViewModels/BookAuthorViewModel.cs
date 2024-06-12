using BookLibrary.Models;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace BookLibrary.ViewModels
{
    public class BookAuthorViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile File { get;set; }
        public string ImageUrl { get; set; }
        public string AuthorNameList { get; set; }

        public int AuthorId { get; set; }
        public Author author { get; set; }

    }
}
