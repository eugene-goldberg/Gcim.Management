namespace Gcim.Management.Module.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OdsDataAttributes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ToolInstanceName = c.String(),
                        OdsDatabaseName = c.String(),
                        SourceTableName = c.String(),
                        SourceColumnName = c.String(),
                        SourceColumnType = c.String(),
                        SourceColumnLength = c.Int(nullable: false),
                        OdsTableName = c.String(),
                        OdsColumnName = c.String(),
                        OdsColumnType = c.String(),
                        OdsColumnLength = c.Int(nullable: false),
                        Transformation = c.String(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.DataEntities", "OdsDataAttribute_ID", c => c.Int());
            CreateIndex("dbo.DataEntities", "OdsDataAttribute_ID");
            AddForeignKey("dbo.DataEntities", "OdsDataAttribute_ID", "dbo.OdsDataAttributes", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DataEntities", "OdsDataAttribute_ID", "dbo.OdsDataAttributes");
            DropIndex("dbo.DataEntities", new[] { "OdsDataAttribute_ID" });
            DropColumn("dbo.DataEntities", "OdsDataAttribute_ID");
            DropTable("dbo.OdsDataAttributes");
        }
    }
}
