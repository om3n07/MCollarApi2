using PowerOutageApi.DataAccess;
using PowerOutageApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PowerOutageApi.BusinessLayer
{
    public class PowerCheckinBusinessLayer : IPowerCheckinBusinessLayer
    {
        private static PowerCheckinDB _dbContext;

        public PowerCheckinBusinessLayer()
        {
            _dbContext = new PowerCheckinDB();
        }

        public DateTime UpdateCheckinTime(int powerCheckinDeviceId)
        {
            var device = GetPowerCheckinDevice(powerCheckinDeviceId);
            var updateTime = DateTime.Now;

            device.LastCheckinTime = updateTime;
            _dbContext.SaveChanges();

            return updateTime;
        }

        public int SavePowerCheckinDevice(string deviceName)
        {
            var device = new PowerCheckinDevice
            {
                DeviceName = deviceName,
                LastCheckinTime = DateTime.Now
            };

            if (GetPowerCheckinDevice(deviceName).Count > 0)
            {
                return -1;
            }

            var savedLocation = _dbContext.PowerCheckingDevices.Add(device);
            _dbContext.SaveChanges();
            return savedLocation.PowerCheckinDeviceId;
        }

        public PowerCheckinDevice GetPowerCheckinDevice(int powerCheckinDeviceId)
        {
            return _dbContext.PowerCheckingDevices.FirstOrDefault(d => d.PowerCheckinDeviceId == powerCheckinDeviceId);
        }

        public List<PowerCheckinDevice> GetPowerCheckinDevice(string deviceName = null)
        {
            if (string.IsNullOrEmpty(deviceName))
            {
                return _dbContext.PowerCheckingDevices.ToList();
            }
            return _dbContext.PowerCheckingDevices.Where(d => string.Equals(d.DeviceName, deviceName)).ToList();
        }
    }
}
