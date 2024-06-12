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
    public class OfferTypeEntity : IDataHelper<offertype>
    {
        DBData dB;

        public OfferTypeEntity()
        {
            dB = new DBData();
        }

        public void Add(offertype table)
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

        public offertype Find(int id)
        {
            return dB.offertype.Where(x => x.id == id).First();
        }

        public List<offertype> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<offertype> GetData()
        {
           return dB.offertype.ToList();
        }

        public List<offertype> GetDataByUserId(string UserId)
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

        public List<offertype> SearchItem(string searchItem)
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

        public void Update(offertype table, int id)
        {
            throw new NotImplementedException();
        }
    }
}
