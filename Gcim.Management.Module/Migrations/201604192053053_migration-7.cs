namespace Gcim.Management.Module.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DataEntities", "OdsDataAttribute_ID", "dbo.OdsDataAttributes");
            DropIndex("dbo.DataEntities", new[] { "OdsDataAttribute_ID" });
            CreateTable(
                "dbo.OdsDataAttributeDataEntities",
                c => new
                    {
                        OdsDataAttribute_ID = c.Int(nullable: false),
                        DataEntity_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OdsDataAttribute_ID, t.DataEntity_ID })
                .ForeignKey("dbo.OdsDataAttributes", t => t.OdsDataAttribute_ID, cascadeDelete: true)
                .ForeignKey("dbo.DataEntities", t => t.DataEntity_ID, cascadeDelete: true)
                .Index(t => t.OdsDataAttribute_ID)
                .Index(t => t.DataEntity_ID);
            
            DropColumn("dbo.DataEntities", "OdsDataAttribute_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DataEntities", "OdsDataAttribute_ID", c => c.Int());
            DropForeignKey("dbo.OdsDataAttributeDataEntities", "DataEntity_ID", "dbo.DataEntities");
            DropForeignKey("dbo.OdsDataAttributeDataEntities", "OdsDataAttribute_ID", "dbo.OdsDataAttributes");
            DropIndex("dbo.OdsDataAttributeDataEntities", new[] { "DataEntity_ID" });
            DropIndex("dbo.OdsDataAttributeDataEntities", new[] { "OdsDataAttribute_ID" });
            DropTable("dbo.OdsDataAttributeDataEntities");
            CreateIndex("dbo.DataEntities", "OdsDataAttribute_ID");
            AddForeignKey("dbo.DataEntities", "OdsDataAttribute_ID", "dbo.OdsDataAttributes", "ID");
        }
    }
}
