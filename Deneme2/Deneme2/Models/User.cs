using System.ComponentModel.DataAnnotations.Schema;

namespace Deneme2.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte [] image { get; set; }
        [NotMapped]
        public string? ImageSrc
        {
            get
            {
                if (image != null && image.Length > 0)
                {
                    string base64String = Convert.ToBase64String(image);
                    return $"data:image/jpeg;base64,{base64String}";
                }
                else
                {
                    return string.Empty;
                }
            }
        }

    }
}
