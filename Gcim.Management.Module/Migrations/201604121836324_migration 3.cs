namespace Gcim.Management.Module.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UdmDimensions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EntityName = c.String(),
                        EntityAttributeName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UdmFacts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EntityName = c.String(),
                        EntityAttributeName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UdmMeasures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Measure = c.String(),
                        EtlOrSsas = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UdmMeasures");
            DropTable("dbo.UdmFacts");
            DropTable("dbo.UdmDimensions");
        }
    }
}
