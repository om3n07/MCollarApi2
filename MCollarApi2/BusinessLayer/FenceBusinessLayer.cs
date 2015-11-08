using MCollarApi2.DataAccess;
using MCollarApi2.Model;
using System.Collections.Generic;
using System.Linq;

namespace MCollarApi2.BusinessLayer
{
    /// <summary>
    /// Manages fences and their respective fence posts
    /// </summary>
    public class FenceBusinessLayer : IFenceBusinessLayer
    {
        private MCollarDataBaseContext _dbContext;

        public FenceBusinessLayer()
        {
            _dbContext = new MCollarDataBaseContext();
        }

        public Fence GetFence(int fenceId)
        {
            return _dbContext.Fences.FirstOrDefault(f => f.FenceId == fenceId);
        }

        public IEnumerable<Fence> GetFences()
        {
            IEnumerable<Fence> fences = _dbContext.Fences.ToList().Where(f => { f.FencePosts = _dbContext.FencePosts.Where(fp => fp.FenceId == f.FenceId); return true; });

            return fences;
        }

        public IEnumerable<Fence> GetFencesByCollarId(int collarId)
        {
            return _dbContext.Fences.Where(f=>f.CollarId == collarId);
        }

        public int SaveFence(Fence fence)
        {
            var savedFence =_dbContext.Fences.Add(fence);
            _dbContext.SaveChanges();

            foreach (var fp in fence.FencePosts)
            {
                fp.FenceId = savedFence.FenceId;
            }

            var savedFencePosts = _dbContext.FencePosts.AddRange(fence.FencePosts);
            _dbContext.SaveChanges();

            return savedFence.FenceId;
        }

        /// <summary>
        /// Gets all fence posts. Should only be used for debugging
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FencePost> GetAllFencePosts()
        {
            return _dbContext.FencePosts;
        }

        /// <summary>
        /// Deletes fence and all related posts
        /// </summary>
        /// <param name="fenceId"></param>
        /// <returns></returns>
        public Fence DeleteFence(int fenceId)
        {
            var fenceToDelete = _dbContext.Fences.FirstOrDefault(f => f.FenceId == fenceId);
            Fence deletedFence = null;
            if (fenceToDelete != null)
            {
                deletedFence = _dbContext.Fences.Remove(_dbContext.Fences.FirstOrDefault(f => f.FenceId == fenceId));

                var fencePosts = _dbContext.FencePosts.Where(fp => fp.FenceId == deletedFence.FenceId);
                if (fencePosts != null)
                {
                    _dbContext.FencePosts.RemoveRange(fencePosts);
                }

                _dbContext.SaveChanges();
            }

            return deletedFence;
        }
    }
}