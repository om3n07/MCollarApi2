using PowerOutageApi.Migrations;
using PowerOutageApi.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PowerOutageApi.DataAccess
{
    public class PowerCheckinDB : DbContext
    {
        public PowerCheckinDB() : base("PowerCheckinDB")
        {

        }

        public DbSet<PowerCheckinDevice> PowerCheckingDevices { get; set; }
        //public DbSet<Collar> Collars { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PowerCheckinDB, Configuration>());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
