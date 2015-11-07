using System;
using System.Collections.Generic;

namespace MCollarApi2.Model
{
    public class Fence
    {
        public int CollarId { get; set; }
        public int FenceId { get; set; }
        public IEnumerable<FencePost> FencePosts { get; set; }
        public DateTime CreateDate { get; set; }
        public string Name { get; set; }
    }
}
