using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RealEstate.Core;
using RealEstateData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Data.Contacts
{
    public class ContactEntity : IDataHelper<Contact>
    {
        DBData dB;
        Contact contact;
        public ContactEntity()
        {
            dB = new DBData();
        }

        public void Add(Contact table)
        {
            dB.Contact.Add(table);
            dB.SaveChanges();
        }

        public void Delete(int id)
        {
            contact = Find(id);
            dB.Contact.Remove(contact);
            dB.SaveChanges();

        }

        public List<Contact> GetData()
        {
            return dB.Contact.ToList();
        }

        public List<Contact> SearchItem(string searchItem)
        {
            return dB.Contact
                .Where(a => a.Id.ToString().Equals(searchItem)
                    || a.Name.Contains(searchItem)
                    || a.Number.ToString().Contains(searchItem)
                    || a.Email.Contains(searchItem))
                .ToList();
        }


        public void Update(Contact table, int id)
        {
            contact = Find(id);
            dB.Contact.Update(contact);
            dB.SaveChanges();

        }

        public Contact Find(int id)
        {
            return dB.Contact.Where(x => x.Id == id).First();
        }

        public List<Contact> GetDataByUserId(string UserId)
        {
            throw new NotImplementedException();
        }

        public int PostsCounts(string UserId)
        {
            throw new NotImplementedException();
        }

        public bool CheckIfUserHasSavedProperty(string UserId, int id)
        {
            throw new NotImplementedException();
        }

        public void SavePost(string userId, int postId)
        {
            throw new NotImplementedException();
        }

        public void UnsavePost(string userId, int postId)
        {
            throw new NotImplementedException();
        }

        public void TogglePostStatus(string userId, int postId, bool isSave)
        {
            throw new NotImplementedException();
        }

        public List<Contact> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
