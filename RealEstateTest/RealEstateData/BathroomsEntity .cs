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
    public class BathroomsEntity:IDataHelper<Bathrooms>
    {
        DBData dB;

        public BathroomsEntity()
        {
            dB = new DBData();
        }

        public void Add(Bathrooms table)
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

        public Bathrooms Find(int id)
        {
            return dB.Bathrooms.Where(x => x.id == id).First();
        }

        public List<Bathrooms> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Bathrooms> GetData()
        {
            return dB.Bathrooms.ToList();
        }

        public List<Bathrooms> GetDataByUserId(string UserId)
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

        public List<Bathrooms> SearchItem(string searchItem)
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

        public void Update(Bathrooms table, int id)
        {
            throw new NotImplementedException();
        }
    }
}
