using System;
using System.Collections.Generic;

namespace MCollarApi2.Model
{
    public class Collar
    {
        public int CollarId { get; set; }
        public string Name { get; set; }
        public string CollarDeviceId { get; set; }
        //public IEnumerable<Location> Locations { get; set; }
        //public IEnumerable<Fence> Fences { get; set; }
        public DateTime CreateDate { get; set; }
    }
}