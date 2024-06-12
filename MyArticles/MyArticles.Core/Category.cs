namespace MyArticles.Core
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation
        public virtual List<AuthorPost> AuthorPosts { get; set; }
    }
}