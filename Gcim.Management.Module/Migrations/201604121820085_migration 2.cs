namespace Gcim.Management.Module.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UdmDataAttributes", newName: "UdmDataAttribute1");
            CreateTable(
                "dbo.UdmDataAttributes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EntityName = c.String(),
                        EntityAttributeName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UdmDataAttributes");
            RenameTable(name: "dbo.UdmDataAttribute1", newName: "UdmDataAttributes");
        }
    }
}
