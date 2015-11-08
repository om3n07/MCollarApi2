using MCollarApi2.BusinessLayer;
using MCollarApi2.Model;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MCollarApi2.Controllers
{
    [EnableCors(origins: "http://mcollarapi2.azurewebsites.net", headers: "*", methods: "*")]
    [RoutePrefix("api")]
    public class FencesController : ApiController
    {
        private IFenceBusinessLayer _fenceBusinessLayer;

        public IFenceBusinessLayer FenceBusinessLayer
        {
            get { return _fenceBusinessLayer ?? (_fenceBusinessLayer = new FenceBusinessLayer()); }
        }

        [HttpGet]
        [Route("Fences")]
        public HttpResponseMessage GetFences()
        {
            var fences = FenceBusinessLayer.GetFences();
            if (fences == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, fences);
        }

        [HttpGet]
        [Route("Fences/{fenceId}")]
        public HttpResponseMessage GetFence([FromUri] int fenceId)
        {
            var fence = FenceBusinessLayer.GetFence(fenceId);
            if (fence == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, fence);
        }

        [HttpGet]
        [Route("Collars/{collarId}/Fences")]
        public HttpResponseMessage GetFencesByCollarId([FromUri] int collarId)
        {
            var fences = FenceBusinessLayer.GetFencesByCollarId(collarId);
            if (fences == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, fences);
        }

        [HttpGet]
        [Route("Fences/FencePosts")]
        public HttpResponseMessage GetAllFencePosts()
        {
            var fencePosts = FenceBusinessLayer.GetAllFencePosts();
            return Request.CreateResponse(HttpStatusCode.OK, fencePosts);
        }

        [HttpPost]
        [Route("Fences/RegularFence")]
        public HttpResponseMessage SaveFence([FromBody] RegularFence fence)
        {
            var savedFenceId = FenceBusinessLayer.SaveFence(fence);
            return Request.CreateResponse(HttpStatusCode.OK, savedFenceId);
        }

        [HttpPost]
        [Route("Fences/CustomFence")]
        public HttpResponseMessage SaveFence([FromBody] CustomFence fence)
        {
            var savedFenceId = FenceBusinessLayer.SaveFence(fence);
            return Request.CreateResponse(HttpStatusCode.OK, savedFenceId);
        }

        [HttpDelete]
        [Route("Fences/{fenceId}")]
        public HttpResponseMessage DeleteFence([FromUri] int fenceId)
        {
            var deletedFence = FenceBusinessLayer.DeleteFence(fenceId);
            if (deletedFence == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, deletedFence);
        }
    }
}
