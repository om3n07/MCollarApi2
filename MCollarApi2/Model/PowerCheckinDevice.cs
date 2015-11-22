using System;

namespace PowerOutageApi.Model
{
    public class PowerCheckinDevice
    {
        public string DeviceName { get; set; }
        public DateTime LastCheckinTime{ get; set; }
        public int PowerCheckinDeviceId { get; set; }
    }
}