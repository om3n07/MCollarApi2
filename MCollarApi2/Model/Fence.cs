using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MCollarApi2.Model
{
    public abstract class Fence
    {
        public int CollarId { get; set; }
        public int FenceId { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public IEnumerable<FencePost> FencePosts { get; set; }
    }
}
