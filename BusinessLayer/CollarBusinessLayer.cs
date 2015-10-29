using MCollarApi2.DataAccess;
using MCollarApi2.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace MCollarApi2.BusinessLayer
{
    public interface ICollarBusinessLayer
    {
        Collar GetCollarById(int collarId);
        int SaveCollar(Collar collar);
        List<Collar> GetAllCollars();
        int SaveLocation(Location location);
    }

    public class CollarBusinessLayer : ICollarBusinessLayer
    {
        private static MCollarDataBaseContext _dbContext;

        public CollarBusinessLayer()
        {
            _dbContext = new MCollarDataBaseContext();
        }

        public int SaveLocation(Location location)
        {
            var savedLocation = _dbContext.Locations.Add(location);
            _dbContext.SaveChanges();
            return savedLocation.Locationid;
        }

        public List<Collar> GetAllCollars()
        {
            return _dbContext.Collars.ToList();
        }

        public Collar GetCollarById(int collarId)
        {
            var collars = _dbContext.Collars;
            var collar = _dbContext.Collars.FirstOrDefault(c => c.CollarId == collarId);
            collar.Locations = _dbContext.Locations.Where(l => l.CollarId == collarId).ToList();

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
