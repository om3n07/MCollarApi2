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
        public DbSet<CollarLocation> Locations { get; set; }
        public DbSet<Fence> Fences { get; set; }
        public DbSet<FencePost> FencePosts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MCollarDataBaseContext, Configuration>());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
