namespace PowerOutageApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Collar",
                c => new
                    {
                        CollarId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.CollarId);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        Locationid = c.Int(nullable: false, identity: true),
                        CollarId = c.Int(nullable: false),
                        RecordTime = c.DateTime(nullable: false),
                        XCoord = c.Double(nullable: false),
                        YCoord = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Locationid)
                .ForeignKey("dbo.Collar", t => t.CollarId, cascadeDelete: true)
                .Index(t => t.CollarId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Location", "CollarId", "dbo.Collar");
            DropIndex("dbo.Location", new[] { "CollarId" });
            DropTable("dbo.Location");
            DropTable("dbo.Collar");
        }
    }
}
