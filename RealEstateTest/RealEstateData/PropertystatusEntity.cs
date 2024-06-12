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
    public class PropertystatusEntity:IDataHelper<propertystatus>
    {
        DBData dB;

        public PropertystatusEntity()
        {
            dB = new DBData();
        }

        public void Add(propertystatus table)
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

        public propertystatus Find(int id)
        {
            return dB.propertystatus.Where(x => x.id == id).First();
        }

        public List<propertystatus> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<propertystatus> GetData()
        {
            return dB.propertystatus.ToList();
        }

        public List<propertystatus> GetDataByUserId(string UserId)
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

        public List<propertystatus> SearchItem(string searchItem)
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

        public void Update(propertystatus table, int id)
        {
            throw new NotImplementedException();
        }
    }
}
