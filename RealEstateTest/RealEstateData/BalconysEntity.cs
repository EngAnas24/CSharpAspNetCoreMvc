using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RealEstate.Core;
using RealEstateData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Data
{
    public class BalconysEntity:IDataHelper<Balconys>
    { 
        DBData dB;

        public BalconysEntity()
        {
            dB = new DBData();
        }

        public void Add(Balconys table)
        {
            throw new NotImplementedException();
        }

        public bool CheckIfUserHasSavedProperty(string UserId, int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Balconys Find(int id)
        {
            return dB.Balconys.Where(x => x.id == id).First();
        }

        public List<Balconys> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Balconys> GetData()
        {
            return dB.Balconys.ToList();
        }

        public List<Balconys> GetDataByUserId(string UserId)
        {
            throw new NotImplementedException();
        }

        public int PostsCounts(string UserId)
        {
            throw new NotImplementedException();
        }

        public void SavePost(string userId, int postId)
        {
            throw new NotImplementedException();
        }

        public List<Balconys> SearchItem(string searchItem)
        {
            throw new NotImplementedException();
        }

        public void TogglePostStatus(string userId, int postId, bool isSave)
        {
            throw new NotImplementedException();
        }

        public void UnsavePost(string userId, int postId)
        {
            throw new NotImplementedException();
        }

        public void Update(Balconys table, int id)
        {
            throw new NotImplementedException();
        }
    }
}
