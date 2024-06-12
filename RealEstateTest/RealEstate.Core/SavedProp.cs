using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RealEstate.Core
{
    public class SavedProp
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int PostId { get; set; }
        public virtual RealEstateProperty Post { get; set; }
        [NotMapped]
        public virtual List<RealEstateProperty> PostList { get; set; }

        public bool IsSaved { get; set; }


    }
}
