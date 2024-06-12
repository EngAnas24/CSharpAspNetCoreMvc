namespace Deneme2.Repositories
{
    public interface IRepository<T> where T : class
    {
        public void Add(T Table);
        public void Update(T Table,int id);
        public void Delete(T Table,int id);
        public List<T> GetData(int id);
        public List<T> GetData();
        public T Find(int id);
        public IEnumerable<T> IncludeGetData(params string[] args);




    }
}
