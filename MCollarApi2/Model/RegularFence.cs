using MCollarApi2.ModelMetaData;
using System.ComponentModel.DataAnnotations;

namespace MCollarApi2.Model
{
    public class RegularFence : Fence
    {
        // Note: This value is used as side length on shapes with straight sides
        [Units(DistanceUnitType.Feet)]
        [Required]
        public int radius { get; set; }
        [Required]
        public ShapeType shapeType { get; set; }
    }
}