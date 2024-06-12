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
        public class FurnishedstatusEntity:IDataHelper<furnishedstatus>
        {
        DBData dB;

        public FurnishedstatusEntity()
        {
            dB = new DBData();
        }

        public void Add(furnishedstatus table)
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

        public furnishedstatus Find(int id)
        {
            return dB.furnishedstatus.Where(x => x.id == id).First();
        }

        public List<furnishedstatus> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<furnishedstatus> GetData()
        {
            return dB.furnishedstatus.ToList();
        }

        public List<furnishedstatus> GetDataByUserId(string UserId)
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

        public List<furnishedstatus> SearchItem(string searchItem)
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

        public void Update(furnishedstatus table, int id)
        {
            throw new NotImplementedException();
        }
    }
 }
