using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Core
{
    public class RealEstateProperty
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string propertyname { get; set; }
        public string propertyprice { get; set; }
        public string depositamount  { get; set; }
        public string propertyaddress { get; set; }

        public string OffertypeLiist { get; set; }
        public string PropertytypeList { get; set; }
        public string PropertystatusList { get; set; }
        public string FurnishedstatusList { get; set; }
        public string bedroomsList { get; set; }
        public string bathroomsList { get; set; }
        public string balconysList { get; set; }

        public int OffertypeId { get; set; }
        public offertype Offertype { get; set; }

        public int PropertytypeId { get; set; }
        public propertytype Propertytype { get; set; }

        public int PropertystatusId { get; set; }
        public propertystatus Propertystatus  { get; set; }

        public int FurnishedstatusId { get; set; }
        public furnishedstatus Furnishedstatus { get; set; }

        public int bedroomsId { get; set; }
        public Bedrooms bedrooms { get; set; }

        public int bathroomsId { get; set; }
        public Bathrooms bathrooms { get; set; }

        public int balconysId { get; set; }
        public Balconys balconys { get; set; }

        public string carpetarea { get; set; }
        public string propertyage { get; set; }
        public string totalfloors { get; set; }
        public string floorroom { get; set; }
        public string propertydescription { get; set; }
        public DateTime AddedDate { get; set; }


        public string ImageUrl1 { get; set; }
        public string ImageUrl2 { get; set; }
        public string ImageUrl3 { get; set; }
        public string ImageUrl4 { get; set; }
        public string ImageUrl5 { get; set; }
        public int ImagesCounts { get; set; }

        public virtual ICollection<SavedProp> SavedByUsers { get; set; }
      public bool IsSaved { get; set; }
      


    }
}
