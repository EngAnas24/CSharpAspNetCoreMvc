using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Core
{
    public class propertytype
    {
        public int id { get; set; }
        public string Propertytype { get; set; }
        public virtual List<RealEstateProperty> RealEstateProperties { get; set; }

    }
}
