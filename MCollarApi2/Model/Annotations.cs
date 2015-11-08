using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCollarApi2.Model
{
    public class Units : System.Attribute
    {
        public DistanceUnitType DistanceUnitType { get; set; }
        public Units(DistanceUnitType distanceUnitType = DistanceUnitType.Feet)
        {
            DistanceUnitType = distanceUnitType;
        }
    }
}