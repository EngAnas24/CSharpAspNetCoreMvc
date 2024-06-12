namespace MyArticles.Data
{
    public interface IDataHelper<Table>
    {
        //Read Operations
        List<Table> GetAllData();
        List<Table> Search(string SerachItem);
        List<Table> GetDataByUser(string UserId);
        Table Find(int id);

        //Write Operations
        public int Add(Table table);
        public int Edit(int id ,Table table);
        public int Delete(int id);


    }
}