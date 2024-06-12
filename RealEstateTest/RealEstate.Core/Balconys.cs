using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Core
{
    public class Balconys
    {
        public int id { get; set; }
        public string balconys { get; set; }
        public virtual List<RealEstateProperty> RealEstateProperties { get; set; }


    }
}
