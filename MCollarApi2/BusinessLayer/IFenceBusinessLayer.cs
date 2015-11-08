using MCollarApi2.Model;
using System.Collections.Generic;

namespace MCollarApi2.BusinessLayer
{
    public interface IFenceBusinessLayer
    {
        Fence GetFence(int fenceId);
        IEnumerable<Fence> GetFences();
        IEnumerable<Fence> GetFencesByCollarId(int collarId);
        int SaveFence(Fence fence);
        IEnumerable<FencePost> GetAllFencePosts();
        Fence DeleteFence(int fenceId);
    }
}