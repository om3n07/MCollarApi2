using MCollarApi2.DataAccess;
using MCollarApi2.Model;
using System.Collections.Generic;
using System.Linq;

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

    public class CollarBusinessLayer : ICollarBusinessLayer
    {
        private static MCollarDataBaseContext _dbContext;

        public CollarBusinessLayer()
        {
            _dbContext = new MCollarDataBaseContext();
        }

        public int SaveLocation(CollarLocation location)
        {
            var savedLocation = _dbContext.Locations.Add(location);
            _dbContext.SaveChanges();
            return savedLocation.LocationId;
        }

        public IEnumerable<Collar> GetAllCollars()
        {

            return _dbContext.Collars;
        }

        public Collar GetCollarById(int collarId)
        {
            var collars = _dbContext.Collars;
            var collar = _dbContext.Collars.FirstOrDefault(c => c.CollarId == collarId);
            //collar.Locations = _dbContext.Locations.Where(l => l.CollarId == collarId);

            return collar;
        }

        public Collar GetCollarByDeviceId(string deviceId)
        {
            var collars = _dbContext.Collars;
            var collar = _dbContext.Collars.FirstOrDefault(c => c.CollarDeviceId == deviceId);
            //collar.Locations = _dbContext.Locations.Where(l => l.CollarId == collar.CollarId);

            return collar;
        }

        public int SaveCollar(Collar collar)
        {
            var savedCollar = _dbContext.Collars.Add(collar);
            _dbContext.SaveChanges();
            return savedCollar.CollarId;
        }
    }
}
