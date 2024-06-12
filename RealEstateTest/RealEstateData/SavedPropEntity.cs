
using Microsoft.EntityFrameworkCore;
using RealEstate.Core;
using RealEstateData;


namespace RealEstate.Data
{
    public class SavedPropEntity : IDataHelper<SavedProp>
    { 
        DBData dB;

        public SavedPropEntity()
        {
            dB = new DBData();
        }

        public void SavePost(string userId, int postId)
        {
            // Check if post is already saved by the user
            if (!dB.savedProps.Any(sp => sp.UserId == userId && sp.PostId == postId))
            {
                dB.savedProps.Add(new SavedProp { UserId = userId,PostId = postId });
                dB.SaveChanges();
            }
        }

        public void UnsavePost(string userId, int postId)
        {
            var savedPost = dB.savedProps.FirstOrDefault(sp => sp.UserId == userId && sp.PostId == postId);
            if (savedPost != null)
            {
                dB.savedProps.Remove(savedPost);
                dB.SaveChanges();
            }
        }



        public bool CheckIfUserHasSavedProperty(string userId, int propertyId)
        {
            // Check if there's any record matching the user ID and property ID
            return dB.savedProps.Any(x => x.UserId == userId && x.PostId == propertyId&&x.IsSaved==true);
        }




        public SavedProp Find(int id)
        {
            return dB.savedProps.Where(x => x.Id == id).First();
        }

        public List<SavedProp> GetData()
        {
            return dB.savedProps.Include(sp => sp.Post).ToList();
        }

        public List<SavedProp> GetDataByUserId(string UserId)
        {
            throw new NotImplementedException();
        }

        public int PostsCounts(string UserId)
        {
            throw new NotImplementedException();
        }

        public List<SavedProp> SearchItem(string searchItem)
        {
            throw new NotImplementedException();
        }

        public void Update(SavedProp table, int id)
        {
            throw new NotImplementedException();
        }

        public void Add(SavedProp table)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void TogglePostStatus(string userId, int postId, bool isSave)
        {
            var savedPost = dB.savedProps.FirstOrDefault(sp => sp.UserId == userId && sp.PostId == postId);
            if (savedPost != null)
            {
                savedPost.IsSaved = isSave;
                dB.SaveChanges();
            }
            else if (isSave)
            {
                dB.savedProps.Add(new SavedProp { UserId = userId, PostId = postId, IsSaved = true });
                dB.SaveChanges();
            }
        }

        public int SavedCount(string userid)
        {
            return dB.savedProps.Where(x=>x.UserId==userid&&x.IsSaved).Count();
        }

        public List<SavedProp> GetById(int id)
        {
            return dB.savedProps.Where(x=>x.Id==id).ToList();
        }
    }
}
