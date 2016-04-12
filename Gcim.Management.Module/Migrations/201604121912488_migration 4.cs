namespace Gcim.Management.Module.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration4 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.SourceToolUdms", newName: "UdmSourceTools");
            RenameTable(name: "dbo.MasterDataSourceTools", newName: "SourceToolMasterDatas");
            DropForeignKey("dbo.DataAttributeBusinessEntities", "DataAttribute_ID", "dbo.DataAttributes");
            DropForeignKey("dbo.DataAttributeBusinessEntities", "BusinessEntity_ID", "dbo.BusinessEntities");
            DropForeignKey("dbo.DataAttributeDataEntities", "DataAttribute_ID", "dbo.DataAttributes");
            DropForeignKey("dbo.DataAttributeDataEntities", "DataEntity_ID", "dbo.DataEntities");
            DropForeignKey("dbo.UdmDataAttribute1", "Udm_ID", "dbo.Udms");
            DropForeignKey("dbo.UdmDataAttribute1", "DataAttribute_ID", "dbo.DataAttributes");
            DropForeignKey("dbo.BiFactBiDimensions", "BiFact_ID", "dbo.BiFacts");
            DropForeignKey("dbo.BiFactBiDimensions", "BiDimension_ID", "dbo.BiDimensions");
            DropForeignKey("dbo.BiMeasureBiDimensions", "BiMeasure_ID", "dbo.BiMeasures");
            DropForeignKey("dbo.BiMeasureBiDimensions", "BiDimension_ID", "dbo.BiDimensions");
            DropForeignKey("dbo.BiMeasureBiFacts", "BiMeasure_ID", "dbo.BiMeasures");
            DropForeignKey("dbo.BiMeasureBiFacts", "BiFact_ID", "dbo.BiFacts");
            DropForeignKey("dbo.DataEntities", "BiMeasure_ID", "dbo.BiMeasures");
            DropForeignKey("dbo.DataAttributes", "BiFact_ID", "dbo.BiFacts");
            DropForeignKey("dbo.DataEntities", "BiFact_ID", "dbo.BiFacts");
            DropForeignKey("dbo.DataSources", "BiFact_ID", "dbo.BiFacts");
            DropForeignKey("dbo.DataEntities", "BiDimension_ID", "dbo.BiDimensions");
            DropIndex("dbo.DataSources", new[] { "BiFact_ID" });
            DropIndex("dbo.DataEntities", new[] { "BiMeasure_ID" });
            DropIndex("dbo.DataEntities", new[] { "BiFact_ID" });
            DropIndex("dbo.DataEntities", new[] { "BiDimension_ID" });
            DropIndex("dbo.DataAttributes", new[] { "BiFact_ID" });
            DropIndex("dbo.DataAttributeBusinessEntities", new[] { "DataAttribute_ID" });
            DropIndex("dbo.DataAttributeBusinessEntities", new[] { "BusinessEntity_ID" });
            DropIndex("dbo.DataAttributeDataEntities", new[] { "DataAttribute_ID" });
            DropIndex("dbo.DataAttributeDataEntities", new[] { "DataEntity_ID" });
            DropIndex("dbo.UdmDataAttribute1", new[] { "Udm_ID" });
            DropIndex("dbo.UdmDataAttribute1", new[] { "DataAttribute_ID" });
            DropIndex("dbo.BiFactBiDimensions", new[] { "BiFact_ID" });
            DropIndex("dbo.BiFactBiDimensions", new[] { "BiDimension_ID" });
            DropIndex("dbo.BiMeasureBiDimensions", new[] { "BiMeasure_ID" });
            DropIndex("dbo.BiMeasureBiDimensions", new[] { "BiDimension_ID" });
            DropIndex("dbo.BiMeasureBiFacts", new[] { "BiMeasure_ID" });
            DropIndex("dbo.BiMeasureBiFacts", new[] { "BiFact_ID" });
            DropPrimaryKey("dbo.UdmSourceTools");
            DropPrimaryKey("dbo.SourceToolMasterDatas");
            CreateTable(
                "dbo.UdmDataAttributeBusinessEntities",
                c => new
                    {
                        UdmDataAttribute_ID = c.Int(nullable: false),
                        BusinessEntity_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UdmDataAttribute_ID, t.BusinessEntity_ID })
                .ForeignKey("dbo.UdmDataAttributes", t => t.UdmDataAttribute_ID, cascadeDelete: true)
                .ForeignKey("dbo.BusinessEntities", t => t.BusinessEntity_ID, cascadeDelete: true)
                .Index(t => t.UdmDataAttribute_ID)
                .Index(t => t.BusinessEntity_ID);
            
            CreateTable(
                "dbo.UdmDataAttributeDataEntities",
                c => new
                    {
                        UdmDataAttribute_ID = c.Int(nullable: false),
                        DataEntity_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UdmDataAttribute_ID, t.DataEntity_ID })
                .ForeignKey("dbo.UdmDataAttributes", t => t.UdmDataAttribute_ID, cascadeDelete: true)
                .ForeignKey("dbo.DataEntities", t => t.DataEntity_ID, cascadeDelete: true)
                .Index(t => t.UdmDataAttribute_ID)
                .Index(t => t.DataEntity_ID);
            
            CreateTable(
                "dbo.UdmDataAttributeUdms",
                c => new
                    {
                        UdmDataAttribute_ID = c.Int(nullable: false),
                        Udm_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UdmDataAttribute_ID, t.Udm_ID })
                .ForeignKey("dbo.UdmDataAttributes", t => t.UdmDataAttribute_ID, cascadeDelete: true)
                .ForeignKey("dbo.Udms", t => t.Udm_ID, cascadeDelete: true)
                .Index(t => t.UdmDataAttribute_ID)
                .Index(t => t.Udm_ID);
            
            CreateTable(
                "dbo.UdmFactUdmDimensions",
                c => new
                    {
                        UdmFact_ID = c.Int(nullable: false),
                        UdmDimension_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UdmFact_ID, t.UdmDimension_ID })
                .ForeignKey("dbo.UdmFacts", t => t.UdmFact_ID, cascadeDelete: true)
                .ForeignKey("dbo.UdmDimensions", t => t.UdmDimension_ID, cascadeDelete: true)
                .Index(t => t.UdmFact_ID)
                .Index(t => t.UdmDimension_ID);
            
            CreateTable(
                "dbo.UdmMeasureUdmDimensions",
                c => new
                    {
                        UdmMeasure_ID = c.Int(nullable: false),
                        UdmDimension_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UdmMeasure_ID, t.UdmDimension_ID })
                .ForeignKey("dbo.UdmMeasures", t => t.UdmMeasure_ID, cascadeDelete: true)
                .ForeignKey("dbo.UdmDimensions", t => t.UdmDimension_ID, cascadeDelete: true)
                .Index(t => t.UdmMeasure_ID)
                .Index(t => t.UdmDimension_ID);
            
            CreateTable(
                "dbo.UdmMeasureUdmFacts",
                c => new
                    {
                        UdmMeasure_ID = c.Int(nullable: false),
                        UdmFact_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UdmMeasure_ID, t.UdmFact_ID })
                .ForeignKey("dbo.UdmMeasures", t => t.UdmMeasure_ID, cascadeDelete: true)
                .ForeignKey("dbo.UdmFacts", t => t.UdmFact_ID, cascadeDelete: true)
                .Index(t => t.UdmMeasure_ID)
                .Index(t => t.UdmFact_ID);
            
            AddColumn("dbo.DataSources", "UdmFact_ID", c => c.Int());
            AddColumn("dbo.DataEntities", "UdmDimension_ID", c => c.Int());
            AddColumn("dbo.DataEntities", "UdmFact_ID", c => c.Int());
            AddColumn("dbo.DataEntities", "UdmMeasure_ID", c => c.Int());
            AddColumn("dbo.UdmDataAttributes", "EntityAttributeDescription", c => c.String());
            AddColumn("dbo.UdmDataAttributes", "DataMartDatabaseName", c => c.String());
            AddColumn("dbo.UdmDataAttributes", "DataMartTableName", c => c.String());
            AddColumn("dbo.UdmDataAttributes", "DataMartAttributeName", c => c.String());
            AddColumn("dbo.UdmDataAttributes", "OdsDatabaseName", c => c.String());
            AddColumn("dbo.UdmDataAttributes", "OdsTableName", c => c.String());
            AddColumn("dbo.UdmDataAttributes", "OdsColumnName", c => c.String());
            AddColumn("dbo.UdmDataAttributes", "BusinessRules", c => c.String());
            AddColumn("dbo.UdmDataAttributes", "LoadProgram", c => c.String());
            AddColumn("dbo.UdmDataAttributes", "ToolInstanceName", c => c.String());
            AddColumn("dbo.UdmDataAttributes", "UdmFact_ID", c => c.Int());
            AddColumn("dbo.UdmDimensions", "EntityAttributeDescription", c => c.String());
            AddColumn("dbo.UdmDimensions", "DataMartDatabaseName", c => c.String());
            AddColumn("dbo.UdmDimensions", "DimensionTableName", c => c.String());
            AddColumn("dbo.UdmDimensions", "DimensionColumnName", c => c.String());
            AddColumn("dbo.UdmDimensions", "DimensionLoadProcedure", c => c.String());
            AddColumn("dbo.UdmFacts", "EntityAttributeDescription", c => c.String());
            AddColumn("dbo.UdmFacts", "DataMartDatabaseName", c => c.String());
            AddColumn("dbo.UdmFacts", "FactTableName", c => c.String());
            AddColumn("dbo.UdmFacts", "DimensionTableName", c => c.String());
            AddColumn("dbo.UdmFacts", "DimensionColumnName", c => c.String());
            AddColumn("dbo.UdmFacts", "DimensionLoadProcedure", c => c.String());
            AddColumn("dbo.UdmMeasures", "SsasCalculation", c => c.String());
            AddColumn("dbo.UdmMeasures", "DataMartDatabaseName", c => c.String());
            AddColumn("dbo.UdmMeasures", "FactTableName", c => c.String());
            AddColumn("dbo.UdmMeasures", "DetailTableName", c => c.String());
            AddPrimaryKey("dbo.UdmSourceTools", new[] { "Udm_ID", "SourceTool_ID" });
            AddPrimaryKey("dbo.SourceToolMasterDatas", new[] { "SourceTool_ID", "MasterData_ID" });
            CreateIndex("dbo.DataSources", "UdmFact_ID");
            CreateIndex("dbo.DataEntities", "UdmDimension_ID");
            CreateIndex("dbo.DataEntities", "UdmFact_ID");
            CreateIndex("dbo.DataEntities", "UdmMeasure_ID");
            CreateIndex("dbo.UdmDataAttributes", "UdmFact_ID");
            AddForeignKey("dbo.DataEntities", "UdmDimension_ID", "dbo.UdmDimensions", "ID");
            AddForeignKey("dbo.DataEntities", "UdmFact_ID", "dbo.UdmFacts", "ID");
            AddForeignKey("dbo.DataSources", "UdmFact_ID", "dbo.UdmFacts", "ID");
            AddForeignKey("dbo.UdmDataAttributes", "UdmFact_ID", "dbo.UdmFacts", "ID");
            AddForeignKey("dbo.DataEntities", "UdmMeasure_ID", "dbo.UdmMeasures", "ID");
            DropColumn("dbo.DataSources", "BiFact_ID");
            DropColumn("dbo.DataEntities", "BiMeasure_ID");
            DropColumn("dbo.DataEntities", "BiFact_ID");
            DropColumn("dbo.DataEntities", "BiDimension_ID");
            //DropTable("dbo.DataAttributes");
            DropTable("dbo.BiDimensions");
            DropTable("dbo.BiFacts");
            DropTable("dbo.BiMeasures");
            DropTable("dbo.DataAttributeBusinessEntities");
            DropTable("dbo.DataAttributeDataEntities");
            DropTable("dbo.UdmDataAttribute1");
            DropTable("dbo.BiFactBiDimensions");
            DropTable("dbo.BiMeasureBiDimensions");
            DropTable("dbo.BiMeasureBiFacts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BiMeasureBiFacts",
                c => new
                    {
                        BiMeasure_ID = c.Int(nullable: false),
                        BiFact_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BiMeasure_ID, t.BiFact_ID });
            
            CreateTable(
                "dbo.BiMeasureBiDimensions",
                c => new
                    {
                        BiMeasure_ID = c.Int(nullable: false),
                        BiDimension_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BiMeasure_ID, t.BiDimension_ID });
            
            CreateTable(
                "dbo.BiFactBiDimensions",
                c => new
                    {
                        BiFact_ID = c.Int(nullable: false),
                        BiDimension_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BiFact_ID, t.BiDimension_ID });
            
            CreateTable(
                "dbo.UdmDataAttribute1",
                c => new
                    {
                        Udm_ID = c.Int(nullable: false),
                        DataAttribute_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Udm_ID, t.DataAttribute_ID });
            
            CreateTable(
                "dbo.DataAttributeDataEntities",
                c => new
                    {
                        DataAttribute_ID = c.Int(nullable: false),
                        DataEntity_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DataAttribute_ID, t.DataEntity_ID });
            
            CreateTable(
                "dbo.DataAttributeBusinessEntities",
                c => new
                    {
                        DataAttribute_ID = c.Int(nullable: false),
                        BusinessEntity_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DataAttribute_ID, t.BusinessEntity_ID });
            
            CreateTable(
                "dbo.BiMeasures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Measure = c.String(),
                        EtlOrSsas = c.String(),
                        SsasCalculation = c.String(),
                        DataMartDatabaseName = c.String(),
                        FactTableName = c.String(),
                        DetailTableName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BiFacts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TableName = c.String(),
                        Version = c.String(),
                        Notes = c.String(),
                        DateRecorded = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BiDimensions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TableName = c.String(),
                        DataMartDatabaseName = c.String(),
                        Conformed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DataAttributes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UdmDataEntityAttributeName = c.String(),
                        SourceTableName = c.String(),
                        SourceColumnName = c.String(),
                        SourceColumnLength = c.Int(nullable: false),
                        OdsTableName = c.String(),
                        OdsColumnName = c.String(),
                        OdsColumnType = c.String(),
                        OdsColumnLength = c.Int(nullable: false),
                        Transformation = c.String(),
                        Notes = c.String(),
                        BiFact_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.DataEntities", "BiDimension_ID", c => c.Int());
            AddColumn("dbo.DataEntities", "BiFact_ID", c => c.Int());
            AddColumn("dbo.DataEntities", "BiMeasure_ID", c => c.Int());
            AddColumn("dbo.DataSources", "BiFact_ID", c => c.Int());
            DropForeignKey("dbo.UdmMeasureUdmFacts", "UdmFact_ID", "dbo.UdmFacts");
            DropForeignKey("dbo.UdmMeasureUdmFacts", "UdmMeasure_ID", "dbo.UdmMeasures");
            DropForeignKey("dbo.UdmMeasureUdmDimensions", "UdmDimension_ID", "dbo.UdmDimensions");
            DropForeignKey("dbo.UdmMeasureUdmDimensions", "UdmMeasure_ID", "dbo.UdmMeasures");
            DropForeignKey("dbo.DataEntities", "UdmMeasure_ID", "dbo.UdmMeasures");
            DropForeignKey("dbo.UdmFactUdmDimensions", "UdmDimension_ID", "dbo.UdmDimensions");
            DropForeignKey("dbo.UdmFactUdmDimensions", "UdmFact_ID", "dbo.UdmFacts");
            DropForeignKey("dbo.UdmDataAttributes", "UdmFact_ID", "dbo.UdmFacts");
            DropForeignKey("dbo.DataSources", "UdmFact_ID", "dbo.UdmFacts");
            DropForeignKey("dbo.DataEntities", "UdmFact_ID", "dbo.UdmFacts");
            DropForeignKey("dbo.DataEntities", "UdmDimension_ID", "dbo.UdmDimensions");
            DropForeignKey("dbo.UdmDataAttributeUdms", "Udm_ID", "dbo.Udms");
            DropForeignKey("dbo.UdmDataAttributeUdms", "UdmDataAttribute_ID", "dbo.UdmDataAttributes");
            DropForeignKey("dbo.UdmDataAttributeDataEntities", "DataEntity_ID", "dbo.DataEntities");
            DropForeignKey("dbo.UdmDataAttributeDataEntities", "UdmDataAttribute_ID", "dbo.UdmDataAttributes");
            DropForeignKey("dbo.UdmDataAttributeBusinessEntities", "BusinessEntity_ID", "dbo.BusinessEntities");
            DropForeignKey("dbo.UdmDataAttributeBusinessEntities", "UdmDataAttribute_ID", "dbo.UdmDataAttributes");
            DropIndex("dbo.UdmMeasureUdmFacts", new[] { "UdmFact_ID" });
            DropIndex("dbo.UdmMeasureUdmFacts", new[] { "UdmMeasure_ID" });
            DropIndex("dbo.UdmMeasureUdmDimensions", new[] { "UdmDimension_ID" });
            DropIndex("dbo.UdmMeasureUdmDimensions", new[] { "UdmMeasure_ID" });
            DropIndex("dbo.UdmFactUdmDimensions", new[] { "UdmDimension_ID" });
            DropIndex("dbo.UdmFactUdmDimensions", new[] { "UdmFact_ID" });
            DropIndex("dbo.UdmDataAttributeUdms", new[] { "Udm_ID" });
            DropIndex("dbo.UdmDataAttributeUdms", new[] { "UdmDataAttribute_ID" });
            DropIndex("dbo.UdmDataAttributeDataEntities", new[] { "DataEntity_ID" });
            DropIndex("dbo.UdmDataAttributeDataEntities", new[] { "UdmDataAttribute_ID" });
            DropIndex("dbo.UdmDataAttributeBusinessEntities", new[] { "BusinessEntity_ID" });
            DropIndex("dbo.UdmDataAttributeBusinessEntities", new[] { "UdmDataAttribute_ID" });
            DropIndex("dbo.UdmDataAttributes", new[] { "UdmFact_ID" });
            DropIndex("dbo.DataEntities", new[] { "UdmMeasure_ID" });
            DropIndex("dbo.DataEntities", new[] { "UdmFact_ID" });
            DropIndex("dbo.DataEntities", new[] { "UdmDimension_ID" });
            DropIndex("dbo.DataSources", new[] { "UdmFact_ID" });
            DropPrimaryKey("dbo.SourceToolMasterDatas");
            DropPrimaryKey("dbo.UdmSourceTools");
            DropColumn("dbo.UdmMeasures", "DetailTableName");
            DropColumn("dbo.UdmMeasures", "FactTableName");
            DropColumn("dbo.UdmMeasures", "DataMartDatabaseName");
            DropColumn("dbo.UdmMeasures", "SsasCalculation");
            DropColumn("dbo.UdmFacts", "DimensionLoadProcedure");
            DropColumn("dbo.UdmFacts", "DimensionColumnName");
            DropColumn("dbo.UdmFacts", "DimensionTableName");
            DropColumn("dbo.UdmFacts", "FactTableName");
            DropColumn("dbo.UdmFacts", "DataMartDatabaseName");
            DropColumn("dbo.UdmFacts", "EntityAttributeDescription");
            DropColumn("dbo.UdmDimensions", "DimensionLoadProcedure");
            DropColumn("dbo.UdmDimensions", "DimensionColumnName");
            DropColumn("dbo.UdmDimensions", "DimensionTableName");
            DropColumn("dbo.UdmDimensions", "DataMartDatabaseName");
            DropColumn("dbo.UdmDimensions", "EntityAttributeDescription");
            DropColumn("dbo.UdmDataAttributes", "UdmFact_ID");
            DropColumn("dbo.UdmDataAttributes", "ToolInstanceName");
            DropColumn("dbo.UdmDataAttributes", "LoadProgram");
            DropColumn("dbo.UdmDataAttributes", "BusinessRules");
            DropColumn("dbo.UdmDataAttributes", "OdsColumnName");
            DropColumn("dbo.UdmDataAttributes", "OdsTableName");
            DropColumn("dbo.UdmDataAttributes", "OdsDatabaseName");
            DropColumn("dbo.UdmDataAttributes", "DataMartAttributeName");
            DropColumn("dbo.UdmDataAttributes", "DataMartTableName");
            DropColumn("dbo.UdmDataAttributes", "DataMartDatabaseName");
            DropColumn("dbo.UdmDataAttributes", "EntityAttributeDescription");
            DropColumn("dbo.DataEntities", "UdmMeasure_ID");
            DropColumn("dbo.DataEntities", "UdmFact_ID");
            DropColumn("dbo.DataEntities", "UdmDimension_ID");
            DropColumn("dbo.DataSources", "UdmFact_ID");
            DropTable("dbo.UdmMeasureUdmFacts");
            DropTable("dbo.UdmMeasureUdmDimensions");
            DropTable("dbo.UdmFactUdmDimensions");
            DropTable("dbo.UdmDataAttributeUdms");
            DropTable("dbo.UdmDataAttributeDataEntities");
            DropTable("dbo.UdmDataAttributeBusinessEntities");
            AddPrimaryKey("dbo.SourceToolMasterDatas", new[] { "MasterData_ID", "SourceTool_ID" });
            AddPrimaryKey("dbo.UdmSourceTools", new[] { "SourceTool_ID", "Udm_ID" });
            CreateIndex("dbo.BiMeasureBiFacts", "BiFact_ID");
            CreateIndex("dbo.BiMeasureBiFacts", "BiMeasure_ID");
            CreateIndex("dbo.BiMeasureBiDimensions", "BiDimension_ID");
            CreateIndex("dbo.BiMeasureBiDimensions", "BiMeasure_ID");
            CreateIndex("dbo.BiFactBiDimensions", "BiDimension_ID");
            CreateIndex("dbo.BiFactBiDimensions", "BiFact_ID");
            CreateIndex("dbo.UdmDataAttribute1", "DataAttribute_ID");
            CreateIndex("dbo.UdmDataAttribute1", "Udm_ID");
            CreateIndex("dbo.DataAttributeDataEntities", "DataEntity_ID");
            CreateIndex("dbo.DataAttributeDataEntities", "DataAttribute_ID");
            CreateIndex("dbo.DataAttributeBusinessEntities", "BusinessEntity_ID");
            CreateIndex("dbo.DataAttributeBusinessEntities", "DataAttribute_ID");
            CreateIndex("dbo.DataAttributes", "BiFact_ID");
            CreateIndex("dbo.DataEntities", "BiDimension_ID");
            CreateIndex("dbo.DataEntities", "BiFact_ID");
            CreateIndex("dbo.DataEntities", "BiMeasure_ID");
            CreateIndex("dbo.DataSources", "BiFact_ID");
            AddForeignKey("dbo.DataEntities", "BiDimension_ID", "dbo.BiDimensions", "ID");
            AddForeignKey("dbo.DataSources", "BiFact_ID", "dbo.BiFacts", "ID");
            AddForeignKey("dbo.DataEntities", "BiFact_ID", "dbo.BiFacts", "ID");
            AddForeignKey("dbo.DataAttributes", "BiFact_ID", "dbo.BiFacts", "ID");
            AddForeignKey("dbo.DataEntities", "BiMeasure_ID", "dbo.BiMeasures", "ID");
            AddForeignKey("dbo.BiMeasureBiFacts", "BiFact_ID", "dbo.BiFacts", "ID", cascadeDelete: true);
            AddForeignKey("dbo.BiMeasureBiFacts", "BiMeasure_ID", "dbo.BiMeasures", "ID", cascadeDelete: true);
            AddForeignKey("dbo.BiMeasureBiDimensions", "BiDimension_ID", "dbo.BiDimensions", "ID", cascadeDelete: true);
            AddForeignKey("dbo.BiMeasureBiDimensions", "BiMeasure_ID", "dbo.BiMeasures", "ID", cascadeDelete: true);
            AddForeignKey("dbo.BiFactBiDimensions", "BiDimension_ID", "dbo.BiDimensions", "ID", cascadeDelete: true);
            AddForeignKey("dbo.BiFactBiDimensions", "BiFact_ID", "dbo.BiFacts", "ID", cascadeDelete: true);
            AddForeignKey("dbo.UdmDataAttribute1", "DataAttribute_ID", "dbo.DataAttributes", "ID", cascadeDelete: true);
            AddForeignKey("dbo.UdmDataAttribute1", "Udm_ID", "dbo.Udms", "ID", cascadeDelete: true);
            AddForeignKey("dbo.DataAttributeDataEntities", "DataEntity_ID", "dbo.DataEntities", "ID", cascadeDelete: true);
            AddForeignKey("dbo.DataAttributeDataEntities", "DataAttribute_ID", "dbo.DataAttributes", "ID", cascadeDelete: true);
            AddForeignKey("dbo.DataAttributeBusinessEntities", "BusinessEntity_ID", "dbo.BusinessEntities", "ID", cascadeDelete: true);
            AddForeignKey("dbo.DataAttributeBusinessEntities", "DataAttribute_ID", "dbo.DataAttributes", "ID", cascadeDelete: true);
            RenameTable(name: "dbo.SourceToolMasterDatas", newName: "MasterDataSourceTools");
            RenameTable(name: "dbo.UdmSourceTools", newName: "SourceToolUdms");
        }
    }
}
