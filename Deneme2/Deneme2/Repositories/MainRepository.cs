using Deneme2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Deneme2.Repositories
{
    public class MainRepository<T> : IRepository<T> where T : class
    {
        DBData dB;
        public MainRepository(DBData dB)
        {

            dB = new DBData();
            this.dB = dB;
        }

        public void Add(T Table)
        {
            dB.Set<T>().Add(Table);
            dB.SaveChanges();
        }

        public void Delete(T Table, int id)
        {
            dB = new DBData();
            dB.Set<T>().Remove(Table);
            dB.SaveChanges();

        }

        public T Find(int id)
        {
            return dB.Set<T>().Find(id);
        }

        public List<T> GetData(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> IncludeGetData(params string[] args)
        {
            IQueryable<T> queryable = dB.Set<T>();
            if (args.Length > 0)
            {
                foreach(var ager in args)
                {
                    queryable = queryable.Include(ager);
                }
            }
            return queryable.ToList();
        }



        public void Update(T Table, int id)
        {
            dB = new DBData();
            dB.Set<T>().Update(Table);
            dB.SaveChanges();

        }

      public  List<T> GetData()
        {
            return dB.Set<T>().ToList();
        }
    }
}
      