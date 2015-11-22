using PowerOutageApi.BusinessLayer;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PowerOutageApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api")]
    public class PowerCheckinDeviceController : ApiController
    {
        private IPowerCheckinBusinessLayer _powerCheckinDeviceBusinessLayer;
        
        /// <summary>
        /// 
        /// </summary>
        public IPowerCheckinBusinessLayer PowerCheckinDeviceBusinessLayer
        {
            get
            {
                return _powerCheckinDeviceBusinessLayer ?? (_powerCheckinDeviceBusinessLayer = new PowerCheckinBusinessLayer());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="powerCheckinDeviceId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("PowerCheckinDevices/{powerCheckinDeviceId}")]
        public HttpResponseMessage GetDevice([FromUri]int powerCheckinDeviceId)
        {
            var device = PowerCheckinDeviceBusinessLayer.GetPowerCheckinDevice(powerCheckinDeviceId);
            if (device == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, device);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="powerCheckinDeviceId"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("PowerCheckinDevices/{powerCheckinDeviceId}")]
        public HttpResponseMessage DeviceCheckin([FromUri]int powerCheckinDeviceId)
        {
            var updateTime = PowerCheckinDeviceBusinessLayer.UpdateCheckinTime(powerCheckinDeviceId);
            return Request.CreateResponse(HttpStatusCode.OK, updateTime);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("PowerCheckinDevices")]
        public HttpResponseMessage GetDevice(string deviceName = null)
        {
            var device = PowerCheckinDeviceBusinessLayer.GetPowerCheckinDevice(deviceName);
            if (device == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, device);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceName"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("PowerCheckinDevices/{deviceName}")]
        public HttpResponseMessage SaveDevice([FromUri]string deviceName)
        {
            var deviceId = PowerCheckinDeviceBusinessLayer.SavePowerCheckinDevice(deviceName);
            if (deviceId > 0) return Request.CreateResponse(HttpStatusCode.OK, deviceId);
            else return Request.CreateResponse(HttpStatusCode.Forbidden, "Device with name '" + deviceName + "' already exists.");
        }
    }
}
