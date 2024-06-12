using RealEstate.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Data
{
    public interface IDataHelper<Table>
    {
        public List<Table> GetData();
        public List<Table> GetById(int id);

        public List<Table> SearchItem(string searchItem);
        public Table Find(int id);
        public void Add(Table table);
        public void Update(Table table,int id);
        public void Delete(int id);

        public List<Table> GetDataByUserId(string UserId);
        public int PostsCounts(string UserId);
        public bool CheckIfUserHasSavedProperty(string UserId, int id);
        public void SavePost(string userId, int postId);
        public void UnsavePost(string userId, int postId);
        void TogglePostStatus(string userId, int postId, bool isSave);

    }
}
