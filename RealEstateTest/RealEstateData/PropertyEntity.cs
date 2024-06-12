using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RealEstate.Core;
using RealEstate.Data;
using RealEstateData;

namespace RealEstate.Data
{
    public class PropertyEntity : IDataHelper<RealEstateProperty>
    {
        DBData dB;

        public PropertyEntity()
        {
            dB = new DBData();
        }

        public void Add(RealEstateProperty table)
        {
            if (dB.Database.CanConnect())
            {
                dB.RealEstateProperty.Add(table);
                dB.SaveChanges();
            }
            else
            {
                // Throw an exception indicating database connection failure
                throw new Exception("Database connection failed while trying to add the entity.");
            }
        }


        public void Delete(int id)
        {
            var user = Find(id);
           
            if (dB.Database.CanConnect())
            {
                dB = new DBData();

                dB.RealEstateProperty.Remove(user);
                dB.SaveChanges();

            }
            else
            {
                // Throw an exception indicating database connection failure
                throw new Exception("Database connection failed while trying to add the entity.");
            }
        }

        public RealEstateProperty Find(int id)
        {
            if (dB.Database.CanConnect())
            {
                return dB.RealEstateProperty.Where(x => x.Id == id).First();

            }
            else
            {
                // Throw an exception indicating database connection failure
                throw new Exception("Database connection failed while trying to add the entity.");
            }
        }

        public List<RealEstateProperty> GetData()
        {
            using (var dbContext = new DBData())
            {
                if (dB.Database.CanConnect())
                {
                    dB = new DBData();
                    return dB.RealEstateProperty.ToList();
                    dB = new DBData();

                }
                else
                {
                    // Throw an exception indicating database connection failure
                    throw new Exception("Database connection failed while trying to retrieve data.");
                }
            }
        }

        public List<RealEstateProperty> SearchItem(string searchItem)
        {
            if (dB.Database.CanConnect())
            {
                return dB.RealEstateProperty.Where(x=>x.Id.ToString().Contains(searchItem)
                ||x.OffertypeLiist.Contains(searchItem)
                ||x.FurnishedstatusList.Contains(searchItem)
                ||x.PropertytypeList.Contains(searchItem)
               ||x.PropertystatusList.Contains(searchItem)
               ||x.bathroomsList.Contains(searchItem)
               ||x.AddedDate.ToString().Contains(searchItem)
               ||x.bedroomsList.Contains(searchItem)
               ||x.propertydescription.Contains(searchItem)
               ||x.propertyprice.Contains(searchItem)
               ||x.propertyname.Contains(searchItem)
               ||x.depositamount.Contains(searchItem)
               ||x.propertyage.Contains(searchItem)
               ||x.propertyaddress.Contains(searchItem)
               ||x.totalfloors.Contains(searchItem)
               ||x.floorroom.Contains(searchItem)
               ||x.balconysList.Contains(searchItem)

                ).ToList();
            }
            else
            {
                // Throw an exception indicating database connection failure
                throw new Exception("Database connection failed while trying to add the entity.");
            }
        }

        public void Update(RealEstateProperty table, int id)
        {
         
            if (dB.Database.CanConnect())
            {
                dB = new DBData();
                dB.RealEstateProperty.Update(table);
                dB.SaveChanges();
            }
            else
            {
                // Throw an exception indicating database connection failure
                throw new Exception("Database connection failed while trying to add the entity.");
            }
        }

        public List<RealEstateProperty> GetDataByUserId(string UserId)
        {
            if (dB.Database.CanConnect())
            {
                return dB.RealEstateProperty.Where(x => x.UserId == UserId).ToList();
            }
            else
            {
                return null;
            }
        }

        public int PostsCounts(string UserId)
        {
            return dB.RealEstateProperty.Where(x => x.UserId == UserId).Count();
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

        public List<RealEstateProperty> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
