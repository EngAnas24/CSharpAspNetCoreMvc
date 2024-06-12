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
    public class PropertytypEntitye:IDataHelper<propertytype>
    {
        DBData dB;

        public PropertytypEntitye()
        {
            dB = new DBData();
        }

        public void Add(propertytype table)
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

        public propertytype Find(int id)
        {
            return dB.propertytype.Where(x => x.id == id).First();
        }

        public List<propertytype> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<propertytype> GetData()
        {
            return dB.propertytype.ToList();
        }

        public List<propertytype> GetDataByUserId(string UserId)
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

        public List<propertytype> SearchItem(string searchItem)
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

        public void Update(propertytype table, int id)
        {
            throw new NotImplementedException();
        }

     
    }
}
