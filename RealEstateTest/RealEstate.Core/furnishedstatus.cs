using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Core
{
    public  class furnishedstatus
    {
        public int id { get; set; }
        public string Furnishedstatus { get; set; }
        public virtual List<RealEstateProperty> RealEstateProperties { get; set; }


    }
}
