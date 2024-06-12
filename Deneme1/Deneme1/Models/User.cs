namespace Deneme1.Models
{
    // Models/User.cs

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Occupation { get; set; }
        public bool IsActive { get; set; } = true; // Default value is true (active)
    }
}
