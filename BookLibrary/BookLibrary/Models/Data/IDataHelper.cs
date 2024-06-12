namespace BookLibrary.Models.Data
{
    public interface IDataHelper<Tabel>
    {
        List<Tabel> GetData();
        Tabel Find(int id);
        void Add(Tabel tabel);
        void Remove(int id);
        void Edite(int id ,Tabel tabel);
    }
}
