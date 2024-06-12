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
    public class BedroomsEntiity:IDataHelper<Bedrooms>
    {
        DBData dB;

        public BedroomsEntiity()
        {
            dB = new DBData();
        }

        public void Add(Bedrooms table)
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

        public Bedrooms Find(int id)
        {
            return dB.Bedrooms.Where(x => x.id == id).First();
        }

        public List<Bedrooms> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Bedrooms> GetData()
        {
            return dB.Bedrooms.ToList();
        }

        public List<Bedrooms> GetDataByUserId(string UserId)
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

        public List<Bedrooms> SearchItem(string searchItem)
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

        public void Update(Bedrooms table, int id)
        {
            throw new NotImplementedException();
        }
    }
}
