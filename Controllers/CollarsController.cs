using MCollarApi2.BusinessLayer;
using MCollarApi2.Model;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MCollarApi2.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [EnableCors(origins: "http://mcollarapi2.azurewebsites.net", headers: "*", methods: "*")]
    [RoutePrefix("api")]
    public class CollarsController : ApiController
    {
        private ICollarBusinessLayer _collarBusinessLayer;
        
        /// <summary>
        /// 
        /// </summary>
        public ICollarBusinessLayer CollarBusinessLayer
        {
            get
            {
                return _collarBusinessLayer ?? (_collarBusinessLayer = new CollarBusinessLayer());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collarId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Collars/{collarId}")]
        public HttpResponseMessage GetCollar(int collarId)
        {
            var collar = CollarBusinessLayer.GetCollarById(collarId);
            if (collar == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, collar);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Collars")]
        public HttpResponseMessage GetAllCollars()
        {
            var collars = CollarBusinessLayer.GetAllCollars();
            if (collars == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, collars);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collar"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Collars/")]
        public HttpResponseMessage SaveCollar([FromBody]Collar collar)
        {
            int locationId = CollarBusinessLayer.SaveCollar(collar);
            return Request.CreateResponse(HttpStatusCode.OK, locationId); 
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Collars/Locations")]
        public HttpResponseMessage SaveLocation([FromBody]Location location)
        {
            int locationId = CollarBusinessLayer.SaveLocation(location);
            return Request.CreateResponse(HttpStatusCode.OK, locationId);
        }
    }
}
