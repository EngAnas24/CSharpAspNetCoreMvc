using BookLibrary.Models;
namespace BookLibrary.Models.Data
{
    public class BookData : IDataHelper<Book>
    {
        DataConnection connection;
        public BookData()
        {
            connection = new DataConnection();
        }

        public void Add(Book tabel)
        {
            if (connection.Database.CanConnect())
            {
                connection.books.Add(tabel);
                connection.SaveChanges();
            }
        }

        public void Edite(int id, Book a)
        {
            var user = Find(id);
            if (connection.Database.CanConnect())
            {
                connection = new DataConnection();
                connection.books.Update(user);
                connection.SaveChanges();
            }

        }

        public Book Find(int id)
        {
            return connection.books.Where(x => x.Id == id).First();
        }

        public List<Book> GetData()
        {
            return connection.books.ToList();
        }

        public void Remove(int id)
        {
            var user = Find(id);
            if (connection.Database.CanConnect())
            {
                connection = new DataConnection();
                connection.books.Remove(user);
                connection.SaveChanges();
            }
        }
    }
}
