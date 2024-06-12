using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Core
{
    public class Bedrooms
    {
        public int id { get; set; }
        public string bedrooms { get; set; }
        public virtual List<RealEstateProperty> RealEstateProperties { get; set; }

    }
}
