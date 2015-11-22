using PowerOutageApi.Model;
using System;
using System.Collections.Generic;

namespace PowerOutageApi.BusinessLayer
{
    public interface IPowerCheckinBusinessLayer
    {
        DateTime UpdateCheckinTime(int powerCheckinDeviceId);

        int SavePowerCheckinDevice(string deviceName);

        PowerCheckinDevice GetPowerCheckinDevice(int powerCheckinDeviceId);

        List<PowerCheckinDevice> GetPowerCheckinDevice(string powerCheckinDeviceId = null);
    }
}
