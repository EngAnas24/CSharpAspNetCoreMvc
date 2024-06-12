using System.ComponentModel.DataAnnotations.Schema;

namespace Deneme2.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
     
        public IFormFile File { get; set; }
    }
}
