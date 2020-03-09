using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPool.Models
{
    public class City
    {
        public string cityName { get; set; }
        public string streetName { get; set; }
        public string regionName { get; set; }


        public string print()
        {
            if (this.regionName != null)
                return (string.Format("{0} ({1}) {2}", this.cityName, this.regionName, this.streetName));
            else
                return (string.Format("{0} {1}", this.cityName, this.streetName));


        }

    }
}
