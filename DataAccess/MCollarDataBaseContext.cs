using MCollarApi2.Migrations;
using MCollarApi2.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MCollarApi2.DataAccess
{
    public class MCollarDataBaseContext : DbContext
    {
        public MCollarDataBaseContext() : base("MCollarDB")
        {

        }

        public DbSet<Collar> Collars { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MCollarDataBaseContext, Configuration>());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
