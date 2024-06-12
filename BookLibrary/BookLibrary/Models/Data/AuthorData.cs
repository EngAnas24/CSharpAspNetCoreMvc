using BookLibrary.Models;
namespace BookLibrary.Models.Data
{
    public class AuthorData : IDataHelper<Author>
    {
        DataConnection connection;
        public AuthorData()
        {
           connection = new DataConnection();
        }

        public void Add(Author tabel)
        {
            if (connection.Database.CanConnect())
            {
                connection.authors.Add(tabel);
                connection.SaveChanges();
            }
        }

        public void Edite(int id, Author a)
        {
            var user = Find(id);
            if (connection.Database.CanConnect())
            {
                DataConnection data = new DataConnection();
                connection.authors.Update(user);
                connection.SaveChanges();
            }

        }

        public Author Find(int id)
        {
            return connection.authors.Where(x => x.Id == id).First();
        }

        public List<Author> GetData()
        {
            return connection.authors.ToList() ;
        }

        public void Remove(int id)
        {
            var user = Find(id);
            if (connection.Database.CanConnect())
            {
                DataConnection data = new DataConnection();
                connection.authors.Remove(user);
                connection.SaveChanges();
            }
        }
    }
}
