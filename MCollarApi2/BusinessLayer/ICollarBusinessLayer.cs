using MCollarApi2.Model;
using System.Collections.Generic;

namespace MCollarApi2.BusinessLayer
{
    public interface ICollarBusinessLayer
    {
        Collar GetCollarById(int collarId);
        Collar GetCollarByDeviceId(string deviceId);
        int SaveCollar(Collar collar);
        IEnumerable<Collar> GetAllCollars();
        int SaveLocation(CollarLocation location);
    }
}