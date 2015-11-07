using System;

namespace MCollarApi2.Model
{
    public class FencePost
    {
        public int FenceId { get; set; }
        public int FencePostId { get; set; }
        public DateTime CreateDate { get; set; }
        public double XCoord { get; set; }
        public double YCoord { get; set; }
    }
}