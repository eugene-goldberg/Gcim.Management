namespace Gcim.Management.Module.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DataEntities", "UdmDimension_ID", "dbo.UdmDimensions");
            DropForeignKey("dbo.DataEntities", "UdmFact_ID", "dbo.UdmFacts");
            DropForeignKey("dbo.DataEntities", "UdmMeasure_ID", "dbo.UdmMeasures");
            DropIndex("dbo.DataEntities", new[] { "UdmDimension_ID" });
            DropIndex("dbo.DataEntities", new[] { "UdmFact_ID" });
            DropIndex("dbo.DataEntities", new[] { "UdmMeasure_ID" });
            CreateTable(
                "dbo.UdmDimensionDataEntities",
                c => new
                    {
                        UdmDimension_ID = c.Int(nullable: false),
                        DataEntity_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UdmDimension_ID, t.DataEntity_ID })
                .ForeignKey("dbo.UdmDimensions", t => t.UdmDimension_ID, cascadeDelete: true)
                .ForeignKey("dbo.DataEntities", t => t.DataEntity_ID, cascadeDelete: true)
                .Index(t => t.UdmDimension_ID)
                .Index(t => t.DataEntity_ID);
            
            CreateTable(
                "dbo.UdmFactDataEntities",
                c => new
                    {
                        UdmFact_ID = c.Int(nullable: false),
                        DataEntity_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UdmFact_ID, t.DataEntity_ID })
                .ForeignKey("dbo.UdmFacts", t => t.UdmFact_ID, cascadeDelete: true)
                .ForeignKey("dbo.DataEntities", t => t.DataEntity_ID, cascadeDelete: true)
                .Index(t => t.UdmFact_ID)
                .Index(t => t.DataEntity_ID);
            
            CreateTable(
                "dbo.UdmMeasureDataEntities",
                c => new
                    {
                        UdmMeasure_ID = c.Int(nullable: false),
                        DataEntity_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UdmMeasure_ID, t.DataEntity_ID })
                .ForeignKey("dbo.UdmMeasures", t => t.UdmMeasure_ID, cascadeDelete: true)
                .ForeignKey("dbo.DataEntities", t => t.DataEntity_ID, cascadeDelete: true)
                .Index(t => t.UdmMeasure_ID)
                .Index(t => t.DataEntity_ID);
            
            DropColumn("dbo.DataEntities", "UdmDimension_ID");
            DropColumn("dbo.DataEntities", "UdmFact_ID");
            DropColumn("dbo.DataEntities", "UdmMeasure_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DataEntities", "UdmMeasure_ID", c => c.Int());
            AddColumn("dbo.DataEntities", "UdmFact_ID", c => c.Int());
            AddColumn("dbo.DataEntities", "UdmDimension_ID", c => c.Int());
            DropForeignKey("dbo.UdmMeasureDataEntities", "DataEntity_ID", "dbo.DataEntities");
            DropForeignKey("dbo.UdmMeasureDataEntities", "UdmMeasure_ID", "dbo.UdmMeasures");
            DropForeignKey("dbo.UdmFactDataEntities", "DataEntity_ID", "dbo.DataEntities");
            DropForeignKey("dbo.UdmFactDataEntities", "UdmFact_ID", "dbo.UdmFacts");
            DropForeignKey("dbo.UdmDimensionDataEntities", "DataEntity_ID", "dbo.DataEntities");
            DropForeignKey("dbo.UdmDimensionDataEntities", "UdmDimension_ID", "dbo.UdmDimensions");
            DropIndex("dbo.UdmMeasureDataEntities", new[] { "DataEntity_ID" });
            DropIndex("dbo.UdmMeasureDataEntities", new[] { "UdmMeasure_ID" });
            DropIndex("dbo.UdmFactDataEntities", new[] { "DataEntity_ID" });
            DropIndex("dbo.UdmFactDataEntities", new[] { "UdmFact_ID" });
            DropIndex("dbo.UdmDimensionDataEntities", new[] { "DataEntity_ID" });
            DropIndex("dbo.UdmDimensionDataEntities", new[] { "UdmDimension_ID" });
            DropTable("dbo.UdmMeasureDataEntities");
            DropTable("dbo.UdmFactDataEntities");
            DropTable("dbo.UdmDimensionDataEntities");
            CreateIndex("dbo.DataEntities", "UdmMeasure_ID");
            CreateIndex("dbo.DataEntities", "UdmFact_ID");
            CreateIndex("dbo.DataEntities", "UdmDimension_ID");
            AddForeignKey("dbo.DataEntities", "UdmMeasure_ID", "dbo.UdmMeasures", "ID");
            AddForeignKey("dbo.DataEntities", "UdmFact_ID", "dbo.UdmFacts", "ID");
            AddForeignKey("dbo.DataEntities", "UdmDimension_ID", "dbo.UdmDimensions", "ID");
        }
    }
}
