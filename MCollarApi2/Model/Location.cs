using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCollarApi2.Model
{
    public class CollarLocation
    {
        public int CollarId { get; set; }
        
        public int CollarLocationId { get; set; }
        public DateTime RecordTime { get; set; }
        public double XCoord { get; set; }
        public double YCoord { get; set; }
    }
}