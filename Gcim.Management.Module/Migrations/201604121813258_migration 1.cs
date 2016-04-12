namespace Gcim.Management.Module.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnalyticalMethods",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MethodName = c.String(),
                        Description = c.String(),
                        Calculation = c.String(),
                        InformationProduct_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.InformationProducts", t => t.InformationProduct_ID)
                .Index(t => t.InformationProduct_ID);
            
            CreateTable(
                "dbo.BusinessEntities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BusinessGoals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BusinessFunctions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BusinessInitiatives",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleInitial = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        FunctionalRole = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DataSources",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                        SourceSystemName = c.String(),
                        SourceSystemOwner = c.String(),
                        SourceSystemLocation = c.String(),
                        SourceSystemTeam = c.String(),
                        SourceSystemNetworkSegment = c.String(),
                        SourceSystemOsType = c.String(),
                        SourceDatabaseName = c.String(),
                        SourceDatabaseType = c.String(),
                        SourceDatabaseVersion = c.String(),
                        BiFact_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BiFacts", t => t.BiFact_ID)
                .Index(t => t.BiFact_ID);
            
            CreateTable(
                "dbo.DataDeliveryChannels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SourceSystemName = c.String(),
                        SourceTableName = c.String(),
                        SourceQuery = c.String(),
                        OdsDatabaseName = c.String(),
                        OdsTableName = c.String(),
                        OdsProcedure = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DataEntities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        InformationProduct_ID = c.Int(),
                        BiMeasure_ID = c.Int(),
                        BiFact_ID = c.Int(),
                        BiDimension_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.InformationProducts", t => t.InformationProduct_ID)
                .ForeignKey("dbo.BiMeasures", t => t.BiMeasure_ID)
                .ForeignKey("dbo.BiFacts", t => t.BiFact_ID)
                .ForeignKey("dbo.BiDimensions", t => t.BiDimension_ID)
                .Index(t => t.InformationProduct_ID)
                .Index(t => t.BiMeasure_ID)
                .Index(t => t.BiFact_ID)
                .Index(t => t.BiDimension_ID);
            
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BiFacts", t => t.BiFact_ID)
                .Index(t => t.BiFact_ID);
            
            CreateTable(
                "dbo.Udms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        InstanceName = c.String(),
                        Description = c.String(),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SourceTools",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ToolInstanceName = c.String(),
                        Description = c.String(),
                        OdsDatabaseName = c.String(),
                        IntroducingProject = c.String(),
                        DateRecorded = c.DateTime(nullable: false),
                        InUse = c.Boolean(nullable: false),
                        Notes = c.String(),
                        Governance_ID = c.Int(),
                        BusinessInitiative_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Governances", t => t.Governance_ID)
                .ForeignKey("dbo.BusinessInitiatives", t => t.BusinessInitiative_ID)
                .Index(t => t.Governance_ID)
                .Index(t => t.BusinessInitiative_ID);
            
            CreateTable(
                "dbo.InformationProducts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Governance_ID = c.Int(),
                        PerformanceMetric_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Governances", t => t.Governance_ID)
                .ForeignKey("dbo.PerformanceMetrics", t => t.PerformanceMetric_ID)
                .Index(t => t.Governance_ID)
                .Index(t => t.PerformanceMetric_ID);
            
            CreateTable(
                "dbo.MasterDatas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MasterDataEntityName = c.String(),
                        MasterDataAttributeName = c.String(),
                        MasterDataAuthoritativeSystemName = c.String(),
                        MasterDataSourceLink = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PerformanceMetrics",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                        MetricName = c.String(),
                        MetricDefinition = c.String(),
                        Description = c.String(),
                        Governance_ID = c.Int(),
                        DataEntity_ID = c.Int(),
                        BusinessInitiative_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Governances", t => t.Governance_ID)
                .ForeignKey("dbo.DataEntities", t => t.DataEntity_ID)
                .ForeignKey("dbo.BusinessInitiatives", t => t.BusinessInitiative_ID)
                .Index(t => t.Governance_ID)
                .Index(t => t.DataEntity_ID)
                .Index(t => t.BusinessInitiative_ID);
            
            CreateTable(
                "dbo.BusinessQuestions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        QuestionDefinition = c.String(),
                        Comments = c.String(),
                        RelatedSubjectArea = c.String(),
                        AnalyticalMethod_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AnalyticalMethods", t => t.AnalyticalMethod_ID)
                .Index(t => t.AnalyticalMethod_ID);
            
            CreateTable(
                "dbo.SubjectAreas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Governances",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
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
                "dbo.ChangeRecords",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ObjectType = c.String(),
                        ObjectName = c.String(),
                        ProposedChangeContent = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DataLoadMaps",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DataLoadMapName = c.String(),
                        Description = c.String(),
                        FileName = c.String(),
                        ImportFileName = c.String(),
                        FieldMapsImportFile_ID = c.Int(),
                        InputFile_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.FileDatas", t => t.FieldMapsImportFile_ID)
                .ForeignKey("dbo.FileDatas", t => t.InputFile_ID)
                .Index(t => t.FieldMapsImportFile_ID)
                .Index(t => t.InputFile_ID);
            
            CreateTable(
                "dbo.FileDatas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Size = c.Int(nullable: false),
                        FileName = c.String(),
                        Content = c.Binary(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.HCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Parent_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.HCategories", t => t.Parent_ID)
                .Index(t => t.Parent_ID);
            
            CreateTable(
                "dbo.ModelDifferenceAspects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Xml = c.String(),
                        Owner_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ModelDifferences", t => t.Owner_ID)
                .Index(t => t.Owner_ID);
            
            CreateTable(
                "dbo.ModelDifferences",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ContextId = c.String(),
                        Version = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ModuleInfoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Version = c.String(),
                        AssemblyFileName = c.String(),
                        IsMain = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ReportDataV2",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DataTypeName = c.String(),
                        IsInplaceReport = c.Boolean(nullable: false),
                        PredefinedReportTypeName = c.String(),
                        Content = c.Binary(),
                        DisplayName = c.String(),
                        ParametersObjectTypeName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsAdministrative = c.Boolean(nullable: false),
                        CanEditModel = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TypePermissionObjects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AllowRead = c.Boolean(nullable: false),
                        AllowWrite = c.Boolean(nullable: false),
                        AllowCreate = c.Boolean(nullable: false),
                        AllowDelete = c.Boolean(nullable: false),
                        AllowNavigate = c.Boolean(nullable: false),
                        TargetTypeFullName = c.String(),
                        Role_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Roles", t => t.Role_ID)
                .Index(t => t.Role_ID);
            
            CreateTable(
                "dbo.SecuritySystemMemberPermissionsObjects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Members = c.String(),
                        Criteria = c.String(),
                        AllowRead = c.Boolean(nullable: false),
                        AllowWrite = c.Boolean(nullable: false),
                        EffectiveRead = c.Boolean(),
                        EffectiveWrite = c.Boolean(),
                        Owner_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TypePermissionObjects", t => t.Owner_ID)
                .Index(t => t.Owner_ID);
            
            CreateTable(
                "dbo.SecuritySystemObjectPermissionsObjects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Criteria = c.String(),
                        AllowRead = c.Boolean(nullable: false),
                        AllowWrite = c.Boolean(nullable: false),
                        AllowDelete = c.Boolean(nullable: false),
                        AllowNavigate = c.Boolean(nullable: false),
                        EffectiveRead = c.Boolean(),
                        EffectiveWrite = c.Boolean(),
                        EffectiveDelete = c.Boolean(),
                        EffectiveNavigate = c.Boolean(),
                        Owner_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TypePermissionObjects", t => t.Owner_ID)
                .Index(t => t.Owner_ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        ChangePasswordOnFirstLogon = c.Boolean(nullable: false),
                        StoredPassword = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BusinessEntityAnalyticalMethods",
                c => new
                    {
                        BusinessEntity_ID = c.Int(nullable: false),
                        AnalyticalMethod_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BusinessEntity_ID, t.AnalyticalMethod_ID })
                .ForeignKey("dbo.BusinessEntities", t => t.BusinessEntity_ID, cascadeDelete: true)
                .ForeignKey("dbo.AnalyticalMethods", t => t.AnalyticalMethod_ID, cascadeDelete: true)
                .Index(t => t.BusinessEntity_ID)
                .Index(t => t.AnalyticalMethod_ID);
            
            CreateTable(
                "dbo.BusinessGoalBusinessEntities",
                c => new
                    {
                        BusinessGoal_ID = c.Int(nullable: false),
                        BusinessEntity_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BusinessGoal_ID, t.BusinessEntity_ID })
                .ForeignKey("dbo.BusinessGoals", t => t.BusinessGoal_ID, cascadeDelete: true)
                .ForeignKey("dbo.BusinessEntities", t => t.BusinessEntity_ID, cascadeDelete: true)
                .Index(t => t.BusinessGoal_ID)
                .Index(t => t.BusinessEntity_ID);
            
            CreateTable(
                "dbo.BusinessFunctionBusinessGoals",
                c => new
                    {
                        BusinessFunction_ID = c.Int(nullable: false),
                        BusinessGoal_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BusinessFunction_ID, t.BusinessGoal_ID })
                .ForeignKey("dbo.BusinessFunctions", t => t.BusinessFunction_ID, cascadeDelete: true)
                .ForeignKey("dbo.BusinessGoals", t => t.BusinessGoal_ID, cascadeDelete: true)
                .Index(t => t.BusinessFunction_ID)
                .Index(t => t.BusinessGoal_ID);
            
            CreateTable(
                "dbo.BusinessInitiativeBusinessEntities",
                c => new
                    {
                        BusinessInitiative_ID = c.Int(nullable: false),
                        BusinessEntity_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BusinessInitiative_ID, t.BusinessEntity_ID })
                .ForeignKey("dbo.BusinessInitiatives", t => t.BusinessInitiative_ID, cascadeDelete: true)
                .ForeignKey("dbo.BusinessEntities", t => t.BusinessEntity_ID, cascadeDelete: true)
                .Index(t => t.BusinessInitiative_ID)
                .Index(t => t.BusinessEntity_ID);
            
            CreateTable(
                "dbo.BusinessInitiativeBusinessFunctions",
                c => new
                    {
                        BusinessInitiative_ID = c.Int(nullable: false),
                        BusinessFunction_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BusinessInitiative_ID, t.BusinessFunction_ID })
                .ForeignKey("dbo.BusinessInitiatives", t => t.BusinessInitiative_ID, cascadeDelete: true)
                .ForeignKey("dbo.BusinessFunctions", t => t.BusinessFunction_ID, cascadeDelete: true)
                .Index(t => t.BusinessInitiative_ID)
                .Index(t => t.BusinessFunction_ID);
            
            CreateTable(
                "dbo.BusinessInitiativeBusinessGoals",
                c => new
                    {
                        BusinessInitiative_ID = c.Int(nullable: false),
                        BusinessGoal_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BusinessInitiative_ID, t.BusinessGoal_ID })
                .ForeignKey("dbo.BusinessInitiatives", t => t.BusinessInitiative_ID, cascadeDelete: true)
                .ForeignKey("dbo.BusinessGoals", t => t.BusinessGoal_ID, cascadeDelete: true)
                .Index(t => t.BusinessInitiative_ID)
                .Index(t => t.BusinessGoal_ID);
            
            CreateTable(
                "dbo.EmployeeBusinessFunctions",
                c => new
                    {
                        Employee_ID = c.Int(nullable: false),
                        BusinessFunction_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Employee_ID, t.BusinessFunction_ID })
                .ForeignKey("dbo.Employees", t => t.Employee_ID, cascadeDelete: true)
                .ForeignKey("dbo.BusinessFunctions", t => t.BusinessFunction_ID, cascadeDelete: true)
                .Index(t => t.Employee_ID)
                .Index(t => t.BusinessFunction_ID);
            
            CreateTable(
                "dbo.EmployeeBusinessInitiatives",
                c => new
                    {
                        Employee_ID = c.Int(nullable: false),
                        BusinessInitiative_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Employee_ID, t.BusinessInitiative_ID })
                .ForeignKey("dbo.Employees", t => t.Employee_ID, cascadeDelete: true)
                .ForeignKey("dbo.BusinessInitiatives", t => t.BusinessInitiative_ID, cascadeDelete: true)
                .Index(t => t.Employee_ID)
                .Index(t => t.BusinessInitiative_ID);
            
            CreateTable(
                "dbo.DataSourceBusinessEntities",
                c => new
                    {
                        DataSource_ID = c.Int(nullable: false),
                        BusinessEntity_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DataSource_ID, t.BusinessEntity_ID })
                .ForeignKey("dbo.DataSources", t => t.DataSource_ID, cascadeDelete: true)
                .ForeignKey("dbo.BusinessEntities", t => t.BusinessEntity_ID, cascadeDelete: true)
                .Index(t => t.DataSource_ID)
                .Index(t => t.BusinessEntity_ID);
            
            CreateTable(
                "dbo.DataEntityBusinessEntities",
                c => new
                    {
                        DataEntity_ID = c.Int(nullable: false),
                        BusinessEntity_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DataEntity_ID, t.BusinessEntity_ID })
                .ForeignKey("dbo.DataEntities", t => t.DataEntity_ID, cascadeDelete: true)
                .ForeignKey("dbo.BusinessEntities", t => t.BusinessEntity_ID, cascadeDelete: true)
                .Index(t => t.DataEntity_ID)
                .Index(t => t.BusinessEntity_ID);
            
            CreateTable(
                "dbo.DataAttributeBusinessEntities",
                c => new
                    {
                        DataAttribute_ID = c.Int(nullable: false),
                        BusinessEntity_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DataAttribute_ID, t.BusinessEntity_ID })
                .ForeignKey("dbo.DataAttributes", t => t.DataAttribute_ID, cascadeDelete: true)
                .ForeignKey("dbo.BusinessEntities", t => t.BusinessEntity_ID, cascadeDelete: true)
                .Index(t => t.DataAttribute_ID)
                .Index(t => t.BusinessEntity_ID);
            
            CreateTable(
                "dbo.DataAttributeDataEntities",
                c => new
                    {
                        DataAttribute_ID = c.Int(nullable: false),
                        DataEntity_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DataAttribute_ID, t.DataEntity_ID })
                .ForeignKey("dbo.DataAttributes", t => t.DataAttribute_ID, cascadeDelete: true)
                .ForeignKey("dbo.DataEntities", t => t.DataEntity_ID, cascadeDelete: true)
                .Index(t => t.DataAttribute_ID)
                .Index(t => t.DataEntity_ID);
            
            CreateTable(
                "dbo.UdmDataAttributes",
                c => new
                    {
                        Udm_ID = c.Int(nullable: false),
                        DataAttribute_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Udm_ID, t.DataAttribute_ID })
                .ForeignKey("dbo.Udms", t => t.Udm_ID, cascadeDelete: true)
                .ForeignKey("dbo.DataAttributes", t => t.DataAttribute_ID, cascadeDelete: true)
                .Index(t => t.Udm_ID)
                .Index(t => t.DataAttribute_ID);
            
            CreateTable(
                "dbo.UdmDataEntities",
                c => new
                    {
                        Udm_ID = c.Int(nullable: false),
                        DataEntity_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Udm_ID, t.DataEntity_ID })
                .ForeignKey("dbo.Udms", t => t.Udm_ID, cascadeDelete: true)
                .ForeignKey("dbo.DataEntities", t => t.DataEntity_ID, cascadeDelete: true)
                .Index(t => t.Udm_ID)
                .Index(t => t.DataEntity_ID);
            
            CreateTable(
                "dbo.SourceToolBusinessEntities",
                c => new
                    {
                        SourceTool_ID = c.Int(nullable: false),
                        BusinessEntity_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SourceTool_ID, t.BusinessEntity_ID })
                .ForeignKey("dbo.SourceTools", t => t.SourceTool_ID, cascadeDelete: true)
                .ForeignKey("dbo.BusinessEntities", t => t.BusinessEntity_ID, cascadeDelete: true)
                .Index(t => t.SourceTool_ID)
                .Index(t => t.BusinessEntity_ID);
            
            CreateTable(
                "dbo.SourceToolDataEntities",
                c => new
                    {
                        SourceTool_ID = c.Int(nullable: false),
                        DataEntity_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SourceTool_ID, t.DataEntity_ID })
                .ForeignKey("dbo.SourceTools", t => t.SourceTool_ID, cascadeDelete: true)
                .ForeignKey("dbo.DataEntities", t => t.DataEntity_ID, cascadeDelete: true)
                .Index(t => t.SourceTool_ID)
                .Index(t => t.DataEntity_ID);
            
            CreateTable(
                "dbo.SourceToolDataSources",
                c => new
                    {
                        SourceTool_ID = c.Int(nullable: false),
                        DataSource_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SourceTool_ID, t.DataSource_ID })
                .ForeignKey("dbo.SourceTools", t => t.SourceTool_ID, cascadeDelete: true)
                .ForeignKey("dbo.DataSources", t => t.DataSource_ID, cascadeDelete: true)
                .Index(t => t.SourceTool_ID)
                .Index(t => t.DataSource_ID);
            
            CreateTable(
                "dbo.InformationProductBusinessEntities",
                c => new
                    {
                        InformationProduct_ID = c.Int(nullable: false),
                        BusinessEntity_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.InformationProduct_ID, t.BusinessEntity_ID })
                .ForeignKey("dbo.InformationProducts", t => t.InformationProduct_ID, cascadeDelete: true)
                .ForeignKey("dbo.BusinessEntities", t => t.BusinessEntity_ID, cascadeDelete: true)
                .Index(t => t.InformationProduct_ID)
                .Index(t => t.BusinessEntity_ID);
            
            CreateTable(
                "dbo.InformationProductSourceTools",
                c => new
                    {
                        InformationProduct_ID = c.Int(nullable: false),
                        SourceTool_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.InformationProduct_ID, t.SourceTool_ID })
                .ForeignKey("dbo.InformationProducts", t => t.InformationProduct_ID, cascadeDelete: true)
                .ForeignKey("dbo.SourceTools", t => t.SourceTool_ID, cascadeDelete: true)
                .Index(t => t.InformationProduct_ID)
                .Index(t => t.SourceTool_ID);
            
            CreateTable(
                "dbo.MasterDataBusinessEntities",
                c => new
                    {
                        MasterData_ID = c.Int(nullable: false),
                        BusinessEntity_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MasterData_ID, t.BusinessEntity_ID })
                .ForeignKey("dbo.MasterDatas", t => t.MasterData_ID, cascadeDelete: true)
                .ForeignKey("dbo.BusinessEntities", t => t.BusinessEntity_ID, cascadeDelete: true)
                .Index(t => t.MasterData_ID)
                .Index(t => t.BusinessEntity_ID);
            
            CreateTable(
                "dbo.MasterDataDataEntities",
                c => new
                    {
                        MasterData_ID = c.Int(nullable: false),
                        DataEntity_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MasterData_ID, t.DataEntity_ID })
                .ForeignKey("dbo.MasterDatas", t => t.MasterData_ID, cascadeDelete: true)
                .ForeignKey("dbo.DataEntities", t => t.DataEntity_ID, cascadeDelete: true)
                .Index(t => t.MasterData_ID)
                .Index(t => t.DataEntity_ID);
            
            CreateTable(
                "dbo.MasterDataDataSources",
                c => new
                    {
                        MasterData_ID = c.Int(nullable: false),
                        DataSource_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MasterData_ID, t.DataSource_ID })
                .ForeignKey("dbo.MasterDatas", t => t.MasterData_ID, cascadeDelete: true)
                .ForeignKey("dbo.DataSources", t => t.DataSource_ID, cascadeDelete: true)
                .Index(t => t.MasterData_ID)
                .Index(t => t.DataSource_ID);
            
            CreateTable(
                "dbo.MasterDataSourceTools",
                c => new
                    {
                        MasterData_ID = c.Int(nullable: false),
                        SourceTool_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MasterData_ID, t.SourceTool_ID })
                .ForeignKey("dbo.MasterDatas", t => t.MasterData_ID, cascadeDelete: true)
                .ForeignKey("dbo.SourceTools", t => t.SourceTool_ID, cascadeDelete: true)
                .Index(t => t.MasterData_ID)
                .Index(t => t.SourceTool_ID);
            
            CreateTable(
                "dbo.SourceToolUdms",
                c => new
                    {
                        SourceTool_ID = c.Int(nullable: false),
                        Udm_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SourceTool_ID, t.Udm_ID })
                .ForeignKey("dbo.SourceTools", t => t.SourceTool_ID, cascadeDelete: true)
                .ForeignKey("dbo.Udms", t => t.Udm_ID, cascadeDelete: true)
                .Index(t => t.SourceTool_ID)
                .Index(t => t.Udm_ID);
            
            CreateTable(
                "dbo.DataEntityDataDeliveryChannels",
                c => new
                    {
                        DataEntity_ID = c.Int(nullable: false),
                        DataDeliveryChannel_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DataEntity_ID, t.DataDeliveryChannel_ID })
                .ForeignKey("dbo.DataEntities", t => t.DataEntity_ID, cascadeDelete: true)
                .ForeignKey("dbo.DataDeliveryChannels", t => t.DataDeliveryChannel_ID, cascadeDelete: true)
                .Index(t => t.DataEntity_ID)
                .Index(t => t.DataDeliveryChannel_ID);
            
            CreateTable(
                "dbo.DataEntityDataSources",
                c => new
                    {
                        DataEntity_ID = c.Int(nullable: false),
                        DataSource_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DataEntity_ID, t.DataSource_ID })
                .ForeignKey("dbo.DataEntities", t => t.DataEntity_ID, cascadeDelete: true)
                .ForeignKey("dbo.DataSources", t => t.DataSource_ID, cascadeDelete: true)
                .Index(t => t.DataEntity_ID)
                .Index(t => t.DataSource_ID);
            
            CreateTable(
                "dbo.PerformanceMetricAnalyticalMethods",
                c => new
                    {
                        PerformanceMetric_ID = c.Int(nullable: false),
                        AnalyticalMethod_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PerformanceMetric_ID, t.AnalyticalMethod_ID })
                .ForeignKey("dbo.PerformanceMetrics", t => t.PerformanceMetric_ID, cascadeDelete: true)
                .ForeignKey("dbo.AnalyticalMethods", t => t.AnalyticalMethod_ID, cascadeDelete: true)
                .Index(t => t.PerformanceMetric_ID)
                .Index(t => t.AnalyticalMethod_ID);
            
            CreateTable(
                "dbo.PerformanceMetricBusinessEntities",
                c => new
                    {
                        PerformanceMetric_ID = c.Int(nullable: false),
                        BusinessEntity_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PerformanceMetric_ID, t.BusinessEntity_ID })
                .ForeignKey("dbo.PerformanceMetrics", t => t.PerformanceMetric_ID, cascadeDelete: true)
                .ForeignKey("dbo.BusinessEntities", t => t.BusinessEntity_ID, cascadeDelete: true)
                .Index(t => t.PerformanceMetric_ID)
                .Index(t => t.BusinessEntity_ID);
            
            CreateTable(
                "dbo.PerformanceMetricBusinessGoals",
                c => new
                    {
                        PerformanceMetric_ID = c.Int(nullable: false),
                        BusinessGoal_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PerformanceMetric_ID, t.BusinessGoal_ID })
                .ForeignKey("dbo.PerformanceMetrics", t => t.PerformanceMetric_ID, cascadeDelete: true)
                .ForeignKey("dbo.BusinessGoals", t => t.BusinessGoal_ID, cascadeDelete: true)
                .Index(t => t.PerformanceMetric_ID)
                .Index(t => t.BusinessGoal_ID);
            
            CreateTable(
                "dbo.BusinessQuestionBusinessEntities",
                c => new
                    {
                        BusinessQuestion_ID = c.Int(nullable: false),
                        BusinessEntity_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BusinessQuestion_ID, t.BusinessEntity_ID })
                .ForeignKey("dbo.BusinessQuestions", t => t.BusinessQuestion_ID, cascadeDelete: true)
                .ForeignKey("dbo.BusinessEntities", t => t.BusinessEntity_ID, cascadeDelete: true)
                .Index(t => t.BusinessQuestion_ID)
                .Index(t => t.BusinessEntity_ID);
            
            CreateTable(
                "dbo.BusinessQuestionBusinessFunctions",
                c => new
                    {
                        BusinessQuestion_ID = c.Int(nullable: false),
                        BusinessFunction_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BusinessQuestion_ID, t.BusinessFunction_ID })
                .ForeignKey("dbo.BusinessQuestions", t => t.BusinessQuestion_ID, cascadeDelete: true)
                .ForeignKey("dbo.BusinessFunctions", t => t.BusinessFunction_ID, cascadeDelete: true)
                .Index(t => t.BusinessQuestion_ID)
                .Index(t => t.BusinessFunction_ID);
            
            CreateTable(
                "dbo.BusinessQuestionBusinessGoals",
                c => new
                    {
                        BusinessQuestion_ID = c.Int(nullable: false),
                        BusinessGoal_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BusinessQuestion_ID, t.BusinessGoal_ID })
                .ForeignKey("dbo.BusinessQuestions", t => t.BusinessQuestion_ID, cascadeDelete: true)
                .ForeignKey("dbo.BusinessGoals", t => t.BusinessGoal_ID, cascadeDelete: true)
                .Index(t => t.BusinessQuestion_ID)
                .Index(t => t.BusinessGoal_ID);
            
            CreateTable(
                "dbo.BusinessQuestionPerformanceMetrics",
                c => new
                    {
                        BusinessQuestion_ID = c.Int(nullable: false),
                        PerformanceMetric_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BusinessQuestion_ID, t.PerformanceMetric_ID })
                .ForeignKey("dbo.BusinessQuestions", t => t.BusinessQuestion_ID, cascadeDelete: true)
                .ForeignKey("dbo.PerformanceMetrics", t => t.PerformanceMetric_ID, cascadeDelete: true)
                .Index(t => t.BusinessQuestion_ID)
                .Index(t => t.PerformanceMetric_ID);
            
            CreateTable(
                "dbo.SubjectAreaBusinessEntities",
                c => new
                    {
                        SubjectArea_ID = c.Int(nullable: false),
                        BusinessEntity_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SubjectArea_ID, t.BusinessEntity_ID })
                .ForeignKey("dbo.SubjectAreas", t => t.SubjectArea_ID, cascadeDelete: true)
                .ForeignKey("dbo.BusinessEntities", t => t.BusinessEntity_ID, cascadeDelete: true)
                .Index(t => t.SubjectArea_ID)
                .Index(t => t.BusinessEntity_ID);
            
            CreateTable(
                "dbo.SubjectAreaBusinessFunctions",
                c => new
                    {
                        SubjectArea_ID = c.Int(nullable: false),
                        BusinessFunction_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SubjectArea_ID, t.BusinessFunction_ID })
                .ForeignKey("dbo.SubjectAreas", t => t.SubjectArea_ID, cascadeDelete: true)
                .ForeignKey("dbo.BusinessFunctions", t => t.BusinessFunction_ID, cascadeDelete: true)
                .Index(t => t.SubjectArea_ID)
                .Index(t => t.BusinessFunction_ID);
            
            CreateTable(
                "dbo.SubjectAreaBusinessInitiatives",
                c => new
                    {
                        SubjectArea_ID = c.Int(nullable: false),
                        BusinessInitiative_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SubjectArea_ID, t.BusinessInitiative_ID })
                .ForeignKey("dbo.SubjectAreas", t => t.SubjectArea_ID, cascadeDelete: true)
                .ForeignKey("dbo.BusinessInitiatives", t => t.BusinessInitiative_ID, cascadeDelete: true)
                .Index(t => t.SubjectArea_ID)
                .Index(t => t.BusinessInitiative_ID);
            
            CreateTable(
                "dbo.SubjectAreaBusinessQuestions",
                c => new
                    {
                        SubjectArea_ID = c.Int(nullable: false),
                        BusinessQuestion_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SubjectArea_ID, t.BusinessQuestion_ID })
                .ForeignKey("dbo.SubjectAreas", t => t.SubjectArea_ID, cascadeDelete: true)
                .ForeignKey("dbo.BusinessQuestions", t => t.BusinessQuestion_ID, cascadeDelete: true)
                .Index(t => t.SubjectArea_ID)
                .Index(t => t.BusinessQuestion_ID);
            
            CreateTable(
                "dbo.SubjectAreaDataEntities",
                c => new
                    {
                        SubjectArea_ID = c.Int(nullable: false),
                        DataEntity_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SubjectArea_ID, t.DataEntity_ID })
                .ForeignKey("dbo.SubjectAreas", t => t.SubjectArea_ID, cascadeDelete: true)
                .ForeignKey("dbo.DataEntities", t => t.DataEntity_ID, cascadeDelete: true)
                .Index(t => t.SubjectArea_ID)
                .Index(t => t.DataEntity_ID);
            
            CreateTable(
                "dbo.GovernanceBusinessEntities",
                c => new
                    {
                        Governance_ID = c.Int(nullable: false),
                        BusinessEntity_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Governance_ID, t.BusinessEntity_ID })
                .ForeignKey("dbo.Governances", t => t.Governance_ID, cascadeDelete: true)
                .ForeignKey("dbo.BusinessEntities", t => t.BusinessEntity_ID, cascadeDelete: true)
                .Index(t => t.Governance_ID)
                .Index(t => t.BusinessEntity_ID);
            
            CreateTable(
                "dbo.GovernanceBusinessFunctions",
                c => new
                    {
                        Governance_ID = c.Int(nullable: false),
                        BusinessFunction_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Governance_ID, t.BusinessFunction_ID })
                .ForeignKey("dbo.Governances", t => t.Governance_ID, cascadeDelete: true)
                .ForeignKey("dbo.BusinessFunctions", t => t.BusinessFunction_ID, cascadeDelete: true)
                .Index(t => t.Governance_ID)
                .Index(t => t.BusinessFunction_ID);
            
            CreateTable(
                "dbo.GovernanceBusinessInitiatives",
                c => new
                    {
                        Governance_ID = c.Int(nullable: false),
                        BusinessInitiative_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Governance_ID, t.BusinessInitiative_ID })
                .ForeignKey("dbo.Governances", t => t.Governance_ID, cascadeDelete: true)
                .ForeignKey("dbo.BusinessInitiatives", t => t.BusinessInitiative_ID, cascadeDelete: true)
                .Index(t => t.Governance_ID)
                .Index(t => t.BusinessInitiative_ID);
            
            CreateTable(
                "dbo.GovernanceDataSources",
                c => new
                    {
                        Governance_ID = c.Int(nullable: false),
                        DataSource_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Governance_ID, t.DataSource_ID })
                .ForeignKey("dbo.Governances", t => t.Governance_ID, cascadeDelete: true)
                .ForeignKey("dbo.DataSources", t => t.DataSource_ID, cascadeDelete: true)
                .Index(t => t.Governance_ID)
                .Index(t => t.DataSource_ID);
            
            CreateTable(
                "dbo.GovernanceEmployees",
                c => new
                    {
                        Governance_ID = c.Int(nullable: false),
                        Employee_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Governance_ID, t.Employee_ID })
                .ForeignKey("dbo.Governances", t => t.Governance_ID, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_ID, cascadeDelete: true)
                .Index(t => t.Governance_ID)
                .Index(t => t.Employee_ID);
            
            CreateTable(
                "dbo.GovernanceSubjectAreas",
                c => new
                    {
                        Governance_ID = c.Int(nullable: false),
                        SubjectArea_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Governance_ID, t.SubjectArea_ID })
                .ForeignKey("dbo.Governances", t => t.Governance_ID, cascadeDelete: true)
                .ForeignKey("dbo.SubjectAreas", t => t.SubjectArea_ID, cascadeDelete: true)
                .Index(t => t.Governance_ID)
                .Index(t => t.SubjectArea_ID);
            
            CreateTable(
                "dbo.SubjectAreaPerformanceMetrics",
                c => new
                    {
                        SubjectArea_ID = c.Int(nullable: false),
                        PerformanceMetric_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SubjectArea_ID, t.PerformanceMetric_ID })
                .ForeignKey("dbo.SubjectAreas", t => t.SubjectArea_ID, cascadeDelete: true)
                .ForeignKey("dbo.PerformanceMetrics", t => t.PerformanceMetric_ID, cascadeDelete: true)
                .Index(t => t.SubjectArea_ID)
                .Index(t => t.PerformanceMetric_ID);
            
            CreateTable(
                "dbo.PerformanceMetricDataSources",
                c => new
                    {
                        PerformanceMetric_ID = c.Int(nullable: false),
                        DataSource_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PerformanceMetric_ID, t.DataSource_ID })
                .ForeignKey("dbo.PerformanceMetrics", t => t.PerformanceMetric_ID, cascadeDelete: true)
                .ForeignKey("dbo.DataSources", t => t.DataSource_ID, cascadeDelete: true)
                .Index(t => t.PerformanceMetric_ID)
                .Index(t => t.DataSource_ID);
            
            CreateTable(
                "dbo.DataDeliveryChannelDataSources",
                c => new
                    {
                        DataDeliveryChannel_ID = c.Int(nullable: false),
                        DataSource_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DataDeliveryChannel_ID, t.DataSource_ID })
                .ForeignKey("dbo.DataDeliveryChannels", t => t.DataDeliveryChannel_ID, cascadeDelete: true)
                .ForeignKey("dbo.DataSources", t => t.DataSource_ID, cascadeDelete: true)
                .Index(t => t.DataDeliveryChannel_ID)
                .Index(t => t.DataSource_ID);
            
            CreateTable(
                "dbo.DataSourceEmployees",
                c => new
                    {
                        DataSource_ID = c.Int(nullable: false),
                        Employee_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DataSource_ID, t.Employee_ID })
                .ForeignKey("dbo.DataSources", t => t.DataSource_ID, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_ID, cascadeDelete: true)
                .Index(t => t.DataSource_ID)
                .Index(t => t.Employee_ID);
            
            CreateTable(
                "dbo.BiFactBiDimensions",
                c => new
                    {
                        BiFact_ID = c.Int(nullable: false),
                        BiDimension_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BiFact_ID, t.BiDimension_ID })
                .ForeignKey("dbo.BiFacts", t => t.BiFact_ID, cascadeDelete: true)
                .ForeignKey("dbo.BiDimensions", t => t.BiDimension_ID, cascadeDelete: true)
                .Index(t => t.BiFact_ID)
                .Index(t => t.BiDimension_ID);
            
            CreateTable(
                "dbo.BiMeasureBiDimensions",
                c => new
                    {
                        BiMeasure_ID = c.Int(nullable: false),
                        BiDimension_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BiMeasure_ID, t.BiDimension_ID })
                .ForeignKey("dbo.BiMeasures", t => t.BiMeasure_ID, cascadeDelete: true)
                .ForeignKey("dbo.BiDimensions", t => t.BiDimension_ID, cascadeDelete: true)
                .Index(t => t.BiMeasure_ID)
                .Index(t => t.BiDimension_ID);
            
            CreateTable(
                "dbo.BiMeasureBiFacts",
                c => new
                    {
                        BiMeasure_ID = c.Int(nullable: false),
                        BiFact_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BiMeasure_ID, t.BiFact_ID })
                .ForeignKey("dbo.BiMeasures", t => t.BiMeasure_ID, cascadeDelete: true)
                .ForeignKey("dbo.BiFacts", t => t.BiFact_ID, cascadeDelete: true)
                .Index(t => t.BiMeasure_ID)
                .Index(t => t.BiFact_ID);
            
            CreateTable(
                "dbo.RoleRoles",
                c => new
                    {
                        Role_ID = c.Int(nullable: false),
                        Role_ID1 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_ID, t.Role_ID1 })
                .ForeignKey("dbo.Roles", t => t.Role_ID)
                .ForeignKey("dbo.Roles", t => t.Role_ID1)
                .Index(t => t.Role_ID)
                .Index(t => t.Role_ID1);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        User_ID = c.Int(nullable: false),
                        Role_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_ID, t.Role_ID })
                .ForeignKey("dbo.Users", t => t.User_ID, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.Role_ID, cascadeDelete: true)
                .Index(t => t.User_ID)
                .Index(t => t.Role_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "Role_ID", "dbo.Roles");
            DropForeignKey("dbo.UserRoles", "User_ID", "dbo.Users");
            DropForeignKey("dbo.TypePermissionObjects", "Role_ID", "dbo.Roles");
            DropForeignKey("dbo.SecuritySystemObjectPermissionsObjects", "Owner_ID", "dbo.TypePermissionObjects");
            DropForeignKey("dbo.SecuritySystemMemberPermissionsObjects", "Owner_ID", "dbo.TypePermissionObjects");
            DropForeignKey("dbo.RoleRoles", "Role_ID1", "dbo.Roles");
            DropForeignKey("dbo.RoleRoles", "Role_ID", "dbo.Roles");
            DropForeignKey("dbo.ModelDifferenceAspects", "Owner_ID", "dbo.ModelDifferences");
            DropForeignKey("dbo.HCategories", "Parent_ID", "dbo.HCategories");
            DropForeignKey("dbo.DataLoadMaps", "InputFile_ID", "dbo.FileDatas");
            DropForeignKey("dbo.DataLoadMaps", "FieldMapsImportFile_ID", "dbo.FileDatas");
            DropForeignKey("dbo.DataEntities", "BiDimension_ID", "dbo.BiDimensions");
            DropForeignKey("dbo.DataSources", "BiFact_ID", "dbo.BiFacts");
            DropForeignKey("dbo.DataEntities", "BiFact_ID", "dbo.BiFacts");
            DropForeignKey("dbo.DataAttributes", "BiFact_ID", "dbo.BiFacts");
            DropForeignKey("dbo.DataEntities", "BiMeasure_ID", "dbo.BiMeasures");
            DropForeignKey("dbo.BiMeasureBiFacts", "BiFact_ID", "dbo.BiFacts");
            DropForeignKey("dbo.BiMeasureBiFacts", "BiMeasure_ID", "dbo.BiMeasures");
            DropForeignKey("dbo.BiMeasureBiDimensions", "BiDimension_ID", "dbo.BiDimensions");
            DropForeignKey("dbo.BiMeasureBiDimensions", "BiMeasure_ID", "dbo.BiMeasures");
            DropForeignKey("dbo.BiFactBiDimensions", "BiDimension_ID", "dbo.BiDimensions");
            DropForeignKey("dbo.BiFactBiDimensions", "BiFact_ID", "dbo.BiFacts");
            DropForeignKey("dbo.BusinessQuestions", "AnalyticalMethod_ID", "dbo.AnalyticalMethods");
            DropForeignKey("dbo.SourceTools", "BusinessInitiative_ID", "dbo.BusinessInitiatives");
            DropForeignKey("dbo.PerformanceMetrics", "BusinessInitiative_ID", "dbo.BusinessInitiatives");
            DropForeignKey("dbo.DataSourceEmployees", "Employee_ID", "dbo.Employees");
            DropForeignKey("dbo.DataSourceEmployees", "DataSource_ID", "dbo.DataSources");
            DropForeignKey("dbo.DataDeliveryChannelDataSources", "DataSource_ID", "dbo.DataSources");
            DropForeignKey("dbo.DataDeliveryChannelDataSources", "DataDeliveryChannel_ID", "dbo.DataDeliveryChannels");
            DropForeignKey("dbo.PerformanceMetrics", "DataEntity_ID", "dbo.DataEntities");
            DropForeignKey("dbo.InformationProducts", "PerformanceMetric_ID", "dbo.PerformanceMetrics");
            DropForeignKey("dbo.PerformanceMetricDataSources", "DataSource_ID", "dbo.DataSources");
            DropForeignKey("dbo.PerformanceMetricDataSources", "PerformanceMetric_ID", "dbo.PerformanceMetrics");
            DropForeignKey("dbo.SubjectAreaPerformanceMetrics", "PerformanceMetric_ID", "dbo.PerformanceMetrics");
            DropForeignKey("dbo.SubjectAreaPerformanceMetrics", "SubjectArea_ID", "dbo.SubjectAreas");
            DropForeignKey("dbo.GovernanceSubjectAreas", "SubjectArea_ID", "dbo.SubjectAreas");
            DropForeignKey("dbo.GovernanceSubjectAreas", "Governance_ID", "dbo.Governances");
            DropForeignKey("dbo.SourceTools", "Governance_ID", "dbo.Governances");
            DropForeignKey("dbo.PerformanceMetrics", "Governance_ID", "dbo.Governances");
            DropForeignKey("dbo.InformationProducts", "Governance_ID", "dbo.Governances");
            DropForeignKey("dbo.GovernanceEmployees", "Employee_ID", "dbo.Employees");
            DropForeignKey("dbo.GovernanceEmployees", "Governance_ID", "dbo.Governances");
            DropForeignKey("dbo.GovernanceDataSources", "DataSource_ID", "dbo.DataSources");
            DropForeignKey("dbo.GovernanceDataSources", "Governance_ID", "dbo.Governances");
            DropForeignKey("dbo.GovernanceBusinessInitiatives", "BusinessInitiative_ID", "dbo.BusinessInitiatives");
            DropForeignKey("dbo.GovernanceBusinessInitiatives", "Governance_ID", "dbo.Governances");
            DropForeignKey("dbo.GovernanceBusinessFunctions", "BusinessFunction_ID", "dbo.BusinessFunctions");
            DropForeignKey("dbo.GovernanceBusinessFunctions", "Governance_ID", "dbo.Governances");
            DropForeignKey("dbo.GovernanceBusinessEntities", "BusinessEntity_ID", "dbo.BusinessEntities");
            DropForeignKey("dbo.GovernanceBusinessEntities", "Governance_ID", "dbo.Governances");
            DropForeignKey("dbo.SubjectAreaDataEntities", "DataEntity_ID", "dbo.DataEntities");
            DropForeignKey("dbo.SubjectAreaDataEntities", "SubjectArea_ID", "dbo.SubjectAreas");
            DropForeignKey("dbo.SubjectAreaBusinessQuestions", "BusinessQuestion_ID", "dbo.BusinessQuestions");
            DropForeignKey("dbo.SubjectAreaBusinessQuestions", "SubjectArea_ID", "dbo.SubjectAreas");
            DropForeignKey("dbo.SubjectAreaBusinessInitiatives", "BusinessInitiative_ID", "dbo.BusinessInitiatives");
            DropForeignKey("dbo.SubjectAreaBusinessInitiatives", "SubjectArea_ID", "dbo.SubjectAreas");
            DropForeignKey("dbo.SubjectAreaBusinessFunctions", "BusinessFunction_ID", "dbo.BusinessFunctions");
            DropForeignKey("dbo.SubjectAreaBusinessFunctions", "SubjectArea_ID", "dbo.SubjectAreas");
            DropForeignKey("dbo.SubjectAreaBusinessEntities", "BusinessEntity_ID", "dbo.BusinessEntities");
            DropForeignKey("dbo.SubjectAreaBusinessEntities", "SubjectArea_ID", "dbo.SubjectAreas");
            DropForeignKey("dbo.BusinessQuestionPerformanceMetrics", "PerformanceMetric_ID", "dbo.PerformanceMetrics");
            DropForeignKey("dbo.BusinessQuestionPerformanceMetrics", "BusinessQuestion_ID", "dbo.BusinessQuestions");
            DropForeignKey("dbo.BusinessQuestionBusinessGoals", "BusinessGoal_ID", "dbo.BusinessGoals");
            DropForeignKey("dbo.BusinessQuestionBusinessGoals", "BusinessQuestion_ID", "dbo.BusinessQuestions");
            DropForeignKey("dbo.BusinessQuestionBusinessFunctions", "BusinessFunction_ID", "dbo.BusinessFunctions");
            DropForeignKey("dbo.BusinessQuestionBusinessFunctions", "BusinessQuestion_ID", "dbo.BusinessQuestions");
            DropForeignKey("dbo.BusinessQuestionBusinessEntities", "BusinessEntity_ID", "dbo.BusinessEntities");
            DropForeignKey("dbo.BusinessQuestionBusinessEntities", "BusinessQuestion_ID", "dbo.BusinessQuestions");
            DropForeignKey("dbo.PerformanceMetricBusinessGoals", "BusinessGoal_ID", "dbo.BusinessGoals");
            DropForeignKey("dbo.PerformanceMetricBusinessGoals", "PerformanceMetric_ID", "dbo.PerformanceMetrics");
            DropForeignKey("dbo.PerformanceMetricBusinessEntities", "BusinessEntity_ID", "dbo.BusinessEntities");
            DropForeignKey("dbo.PerformanceMetricBusinessEntities", "PerformanceMetric_ID", "dbo.PerformanceMetrics");
            DropForeignKey("dbo.PerformanceMetricAnalyticalMethods", "AnalyticalMethod_ID", "dbo.AnalyticalMethods");
            DropForeignKey("dbo.PerformanceMetricAnalyticalMethods", "PerformanceMetric_ID", "dbo.PerformanceMetrics");
            DropForeignKey("dbo.DataEntityDataSources", "DataSource_ID", "dbo.DataSources");
            DropForeignKey("dbo.DataEntityDataSources", "DataEntity_ID", "dbo.DataEntities");
            DropForeignKey("dbo.DataEntityDataDeliveryChannels", "DataDeliveryChannel_ID", "dbo.DataDeliveryChannels");
            DropForeignKey("dbo.DataEntityDataDeliveryChannels", "DataEntity_ID", "dbo.DataEntities");
            DropForeignKey("dbo.SourceToolUdms", "Udm_ID", "dbo.Udms");
            DropForeignKey("dbo.SourceToolUdms", "SourceTool_ID", "dbo.SourceTools");
            DropForeignKey("dbo.MasterDataSourceTools", "SourceTool_ID", "dbo.SourceTools");
            DropForeignKey("dbo.MasterDataSourceTools", "MasterData_ID", "dbo.MasterDatas");
            DropForeignKey("dbo.MasterDataDataSources", "DataSource_ID", "dbo.DataSources");
            DropForeignKey("dbo.MasterDataDataSources", "MasterData_ID", "dbo.MasterDatas");
            DropForeignKey("dbo.MasterDataDataEntities", "DataEntity_ID", "dbo.DataEntities");
            DropForeignKey("dbo.MasterDataDataEntities", "MasterData_ID", "dbo.MasterDatas");
            DropForeignKey("dbo.MasterDataBusinessEntities", "BusinessEntity_ID", "dbo.BusinessEntities");
            DropForeignKey("dbo.MasterDataBusinessEntities", "MasterData_ID", "dbo.MasterDatas");
            DropForeignKey("dbo.InformationProductSourceTools", "SourceTool_ID", "dbo.SourceTools");
            DropForeignKey("dbo.InformationProductSourceTools", "InformationProduct_ID", "dbo.InformationProducts");
            DropForeignKey("dbo.DataEntities", "InformationProduct_ID", "dbo.InformationProducts");
            DropForeignKey("dbo.InformationProductBusinessEntities", "BusinessEntity_ID", "dbo.BusinessEntities");
            DropForeignKey("dbo.InformationProductBusinessEntities", "InformationProduct_ID", "dbo.InformationProducts");
            DropForeignKey("dbo.AnalyticalMethods", "InformationProduct_ID", "dbo.InformationProducts");
            DropForeignKey("dbo.SourceToolDataSources", "DataSource_ID", "dbo.DataSources");
            DropForeignKey("dbo.SourceToolDataSources", "SourceTool_ID", "dbo.SourceTools");
            DropForeignKey("dbo.SourceToolDataEntities", "DataEntity_ID", "dbo.DataEntities");
            DropForeignKey("dbo.SourceToolDataEntities", "SourceTool_ID", "dbo.SourceTools");
            DropForeignKey("dbo.SourceToolBusinessEntities", "BusinessEntity_ID", "dbo.BusinessEntities");
            DropForeignKey("dbo.SourceToolBusinessEntities", "SourceTool_ID", "dbo.SourceTools");
            DropForeignKey("dbo.UdmDataEntities", "DataEntity_ID", "dbo.DataEntities");
            DropForeignKey("dbo.UdmDataEntities", "Udm_ID", "dbo.Udms");
            DropForeignKey("dbo.UdmDataAttributes", "DataAttribute_ID", "dbo.DataAttributes");
            DropForeignKey("dbo.UdmDataAttributes", "Udm_ID", "dbo.Udms");
            DropForeignKey("dbo.DataAttributeDataEntities", "DataEntity_ID", "dbo.DataEntities");
            DropForeignKey("dbo.DataAttributeDataEntities", "DataAttribute_ID", "dbo.DataAttributes");
            DropForeignKey("dbo.DataAttributeBusinessEntities", "BusinessEntity_ID", "dbo.BusinessEntities");
            DropForeignKey("dbo.DataAttributeBusinessEntities", "DataAttribute_ID", "dbo.DataAttributes");
            DropForeignKey("dbo.DataEntityBusinessEntities", "BusinessEntity_ID", "dbo.BusinessEntities");
            DropForeignKey("dbo.DataEntityBusinessEntities", "DataEntity_ID", "dbo.DataEntities");
            DropForeignKey("dbo.DataSourceBusinessEntities", "BusinessEntity_ID", "dbo.BusinessEntities");
            DropForeignKey("dbo.DataSourceBusinessEntities", "DataSource_ID", "dbo.DataSources");
            DropForeignKey("dbo.EmployeeBusinessInitiatives", "BusinessInitiative_ID", "dbo.BusinessInitiatives");
            DropForeignKey("dbo.EmployeeBusinessInitiatives", "Employee_ID", "dbo.Employees");
            DropForeignKey("dbo.EmployeeBusinessFunctions", "BusinessFunction_ID", "dbo.BusinessFunctions");
            DropForeignKey("dbo.EmployeeBusinessFunctions", "Employee_ID", "dbo.Employees");
            DropForeignKey("dbo.BusinessInitiativeBusinessGoals", "BusinessGoal_ID", "dbo.BusinessGoals");
            DropForeignKey("dbo.BusinessInitiativeBusinessGoals", "BusinessInitiative_ID", "dbo.BusinessInitiatives");
            DropForeignKey("dbo.BusinessInitiativeBusinessFunctions", "BusinessFunction_ID", "dbo.BusinessFunctions");
            DropForeignKey("dbo.BusinessInitiativeBusinessFunctions", "BusinessInitiative_ID", "dbo.BusinessInitiatives");
            DropForeignKey("dbo.BusinessInitiativeBusinessEntities", "BusinessEntity_ID", "dbo.BusinessEntities");
            DropForeignKey("dbo.BusinessInitiativeBusinessEntities", "BusinessInitiative_ID", "dbo.BusinessInitiatives");
            DropForeignKey("dbo.BusinessFunctionBusinessGoals", "BusinessGoal_ID", "dbo.BusinessGoals");
            DropForeignKey("dbo.BusinessFunctionBusinessGoals", "BusinessFunction_ID", "dbo.BusinessFunctions");
            DropForeignKey("dbo.BusinessGoalBusinessEntities", "BusinessEntity_ID", "dbo.BusinessEntities");
            DropForeignKey("dbo.BusinessGoalBusinessEntities", "BusinessGoal_ID", "dbo.BusinessGoals");
            DropForeignKey("dbo.BusinessEntityAnalyticalMethods", "AnalyticalMethod_ID", "dbo.AnalyticalMethods");
            DropForeignKey("dbo.BusinessEntityAnalyticalMethods", "BusinessEntity_ID", "dbo.BusinessEntities");
            DropIndex("dbo.UserRoles", new[] { "Role_ID" });
            DropIndex("dbo.UserRoles", new[] { "User_ID" });
            DropIndex("dbo.RoleRoles", new[] { "Role_ID1" });
            DropIndex("dbo.RoleRoles", new[] { "Role_ID" });
            DropIndex("dbo.BiMeasureBiFacts", new[] { "BiFact_ID" });
            DropIndex("dbo.BiMeasureBiFacts", new[] { "BiMeasure_ID" });
            DropIndex("dbo.BiMeasureBiDimensions", new[] { "BiDimension_ID" });
            DropIndex("dbo.BiMeasureBiDimensions", new[] { "BiMeasure_ID" });
            DropIndex("dbo.BiFactBiDimensions", new[] { "BiDimension_ID" });
            DropIndex("dbo.BiFactBiDimensions", new[] { "BiFact_ID" });
            DropIndex("dbo.DataSourceEmployees", new[] { "Employee_ID" });
            DropIndex("dbo.DataSourceEmployees", new[] { "DataSource_ID" });
            DropIndex("dbo.DataDeliveryChannelDataSources", new[] { "DataSource_ID" });
            DropIndex("dbo.DataDeliveryChannelDataSources", new[] { "DataDeliveryChannel_ID" });
            DropIndex("dbo.PerformanceMetricDataSources", new[] { "DataSource_ID" });
            DropIndex("dbo.PerformanceMetricDataSources", new[] { "PerformanceMetric_ID" });
            DropIndex("dbo.SubjectAreaPerformanceMetrics", new[] { "PerformanceMetric_ID" });
            DropIndex("dbo.SubjectAreaPerformanceMetrics", new[] { "SubjectArea_ID" });
            DropIndex("dbo.GovernanceSubjectAreas", new[] { "SubjectArea_ID" });
            DropIndex("dbo.GovernanceSubjectAreas", new[] { "Governance_ID" });
            DropIndex("dbo.GovernanceEmployees", new[] { "Employee_ID" });
            DropIndex("dbo.GovernanceEmployees", new[] { "Governance_ID" });
            DropIndex("dbo.GovernanceDataSources", new[] { "DataSource_ID" });
            DropIndex("dbo.GovernanceDataSources", new[] { "Governance_ID" });
            DropIndex("dbo.GovernanceBusinessInitiatives", new[] { "BusinessInitiative_ID" });
            DropIndex("dbo.GovernanceBusinessInitiatives", new[] { "Governance_ID" });
            DropIndex("dbo.GovernanceBusinessFunctions", new[] { "BusinessFunction_ID" });
            DropIndex("dbo.GovernanceBusinessFunctions", new[] { "Governance_ID" });
            DropIndex("dbo.GovernanceBusinessEntities", new[] { "BusinessEntity_ID" });
            DropIndex("dbo.GovernanceBusinessEntities", new[] { "Governance_ID" });
            DropIndex("dbo.SubjectAreaDataEntities", new[] { "DataEntity_ID" });
            DropIndex("dbo.SubjectAreaDataEntities", new[] { "SubjectArea_ID" });
            DropIndex("dbo.SubjectAreaBusinessQuestions", new[] { "BusinessQuestion_ID" });
            DropIndex("dbo.SubjectAreaBusinessQuestions", new[] { "SubjectArea_ID" });
            DropIndex("dbo.SubjectAreaBusinessInitiatives", new[] { "BusinessInitiative_ID" });
            DropIndex("dbo.SubjectAreaBusinessInitiatives", new[] { "SubjectArea_ID" });
            DropIndex("dbo.SubjectAreaBusinessFunctions", new[] { "BusinessFunction_ID" });
            DropIndex("dbo.SubjectAreaBusinessFunctions", new[] { "SubjectArea_ID" });
            DropIndex("dbo.SubjectAreaBusinessEntities", new[] { "BusinessEntity_ID" });
            DropIndex("dbo.SubjectAreaBusinessEntities", new[] { "SubjectArea_ID" });
            DropIndex("dbo.BusinessQuestionPerformanceMetrics", new[] { "PerformanceMetric_ID" });
            DropIndex("dbo.BusinessQuestionPerformanceMetrics", new[] { "BusinessQuestion_ID" });
            DropIndex("dbo.BusinessQuestionBusinessGoals", new[] { "BusinessGoal_ID" });
            DropIndex("dbo.BusinessQuestionBusinessGoals", new[] { "BusinessQuestion_ID" });
            DropIndex("dbo.BusinessQuestionBusinessFunctions", new[] { "BusinessFunction_ID" });
            DropIndex("dbo.BusinessQuestionBusinessFunctions", new[] { "BusinessQuestion_ID" });
            DropIndex("dbo.BusinessQuestionBusinessEntities", new[] { "BusinessEntity_ID" });
            DropIndex("dbo.BusinessQuestionBusinessEntities", new[] { "BusinessQuestion_ID" });
            DropIndex("dbo.PerformanceMetricBusinessGoals", new[] { "BusinessGoal_ID" });
            DropIndex("dbo.PerformanceMetricBusinessGoals", new[] { "PerformanceMetric_ID" });
            DropIndex("dbo.PerformanceMetricBusinessEntities", new[] { "BusinessEntity_ID" });
            DropIndex("dbo.PerformanceMetricBusinessEntities", new[] { "PerformanceMetric_ID" });
            DropIndex("dbo.PerformanceMetricAnalyticalMethods", new[] { "AnalyticalMethod_ID" });
            DropIndex("dbo.PerformanceMetricAnalyticalMethods", new[] { "PerformanceMetric_ID" });
            DropIndex("dbo.DataEntityDataSources", new[] { "DataSource_ID" });
            DropIndex("dbo.DataEntityDataSources", new[] { "DataEntity_ID" });
            DropIndex("dbo.DataEntityDataDeliveryChannels", new[] { "DataDeliveryChannel_ID" });
            DropIndex("dbo.DataEntityDataDeliveryChannels", new[] { "DataEntity_ID" });
            DropIndex("dbo.SourceToolUdms", new[] { "Udm_ID" });
            DropIndex("dbo.SourceToolUdms", new[] { "SourceTool_ID" });
            DropIndex("dbo.MasterDataSourceTools", new[] { "SourceTool_ID" });
            DropIndex("dbo.MasterDataSourceTools", new[] { "MasterData_ID" });
            DropIndex("dbo.MasterDataDataSources", new[] { "DataSource_ID" });
            DropIndex("dbo.MasterDataDataSources", new[] { "MasterData_ID" });
            DropIndex("dbo.MasterDataDataEntities", new[] { "DataEntity_ID" });
            DropIndex("dbo.MasterDataDataEntities", new[] { "MasterData_ID" });
            DropIndex("dbo.MasterDataBusinessEntities", new[] { "BusinessEntity_ID" });
            DropIndex("dbo.MasterDataBusinessEntities", new[] { "MasterData_ID" });
            DropIndex("dbo.InformationProductSourceTools", new[] { "SourceTool_ID" });
            DropIndex("dbo.InformationProductSourceTools", new[] { "InformationProduct_ID" });
            DropIndex("dbo.InformationProductBusinessEntities", new[] { "BusinessEntity_ID" });
            DropIndex("dbo.InformationProductBusinessEntities", new[] { "InformationProduct_ID" });
            DropIndex("dbo.SourceToolDataSources", new[] { "DataSource_ID" });
            DropIndex("dbo.SourceToolDataSources", new[] { "SourceTool_ID" });
            DropIndex("dbo.SourceToolDataEntities", new[] { "DataEntity_ID" });
            DropIndex("dbo.SourceToolDataEntities", new[] { "SourceTool_ID" });
            DropIndex("dbo.SourceToolBusinessEntities", new[] { "BusinessEntity_ID" });
            DropIndex("dbo.SourceToolBusinessEntities", new[] { "SourceTool_ID" });
            DropIndex("dbo.UdmDataEntities", new[] { "DataEntity_ID" });
            DropIndex("dbo.UdmDataEntities", new[] { "Udm_ID" });
            DropIndex("dbo.UdmDataAttributes", new[] { "DataAttribute_ID" });
            DropIndex("dbo.UdmDataAttributes", new[] { "Udm_ID" });
            DropIndex("dbo.DataAttributeDataEntities", new[] { "DataEntity_ID" });
            DropIndex("dbo.DataAttributeDataEntities", new[] { "DataAttribute_ID" });
            DropIndex("dbo.DataAttributeBusinessEntities", new[] { "BusinessEntity_ID" });
            DropIndex("dbo.DataAttributeBusinessEntities", new[] { "DataAttribute_ID" });
            DropIndex("dbo.DataEntityBusinessEntities", new[] { "BusinessEntity_ID" });
            DropIndex("dbo.DataEntityBusinessEntities", new[] { "DataEntity_ID" });
            DropIndex("dbo.DataSourceBusinessEntities", new[] { "BusinessEntity_ID" });
            DropIndex("dbo.DataSourceBusinessEntities", new[] { "DataSource_ID" });
            DropIndex("dbo.EmployeeBusinessInitiatives", new[] { "BusinessInitiative_ID" });
            DropIndex("dbo.EmployeeBusinessInitiatives", new[] { "Employee_ID" });
            DropIndex("dbo.EmployeeBusinessFunctions", new[] { "BusinessFunction_ID" });
            DropIndex("dbo.EmployeeBusinessFunctions", new[] { "Employee_ID" });
            DropIndex("dbo.BusinessInitiativeBusinessGoals", new[] { "BusinessGoal_ID" });
            DropIndex("dbo.BusinessInitiativeBusinessGoals", new[] { "BusinessInitiative_ID" });
            DropIndex("dbo.BusinessInitiativeBusinessFunctions", new[] { "BusinessFunction_ID" });
            DropIndex("dbo.BusinessInitiativeBusinessFunctions", new[] { "BusinessInitiative_ID" });
            DropIndex("dbo.BusinessInitiativeBusinessEntities", new[] { "BusinessEntity_ID" });
            DropIndex("dbo.BusinessInitiativeBusinessEntities", new[] { "BusinessInitiative_ID" });
            DropIndex("dbo.BusinessFunctionBusinessGoals", new[] { "BusinessGoal_ID" });
            DropIndex("dbo.BusinessFunctionBusinessGoals", new[] { "BusinessFunction_ID" });
            DropIndex("dbo.BusinessGoalBusinessEntities", new[] { "BusinessEntity_ID" });
            DropIndex("dbo.BusinessGoalBusinessEntities", new[] { "BusinessGoal_ID" });
            DropIndex("dbo.BusinessEntityAnalyticalMethods", new[] { "AnalyticalMethod_ID" });
            DropIndex("dbo.BusinessEntityAnalyticalMethods", new[] { "BusinessEntity_ID" });
            DropIndex("dbo.SecuritySystemObjectPermissionsObjects", new[] { "Owner_ID" });
            DropIndex("dbo.SecuritySystemMemberPermissionsObjects", new[] { "Owner_ID" });
            DropIndex("dbo.TypePermissionObjects", new[] { "Role_ID" });
            DropIndex("dbo.ModelDifferenceAspects", new[] { "Owner_ID" });
            DropIndex("dbo.HCategories", new[] { "Parent_ID" });
            DropIndex("dbo.DataLoadMaps", new[] { "InputFile_ID" });
            DropIndex("dbo.DataLoadMaps", new[] { "FieldMapsImportFile_ID" });
            DropIndex("dbo.BusinessQuestions", new[] { "AnalyticalMethod_ID" });
            DropIndex("dbo.PerformanceMetrics", new[] { "BusinessInitiative_ID" });
            DropIndex("dbo.PerformanceMetrics", new[] { "DataEntity_ID" });
            DropIndex("dbo.PerformanceMetrics", new[] { "Governance_ID" });
            DropIndex("dbo.InformationProducts", new[] { "PerformanceMetric_ID" });
            DropIndex("dbo.InformationProducts", new[] { "Governance_ID" });
            DropIndex("dbo.SourceTools", new[] { "BusinessInitiative_ID" });
            DropIndex("dbo.SourceTools", new[] { "Governance_ID" });
            DropIndex("dbo.DataAttributes", new[] { "BiFact_ID" });
            DropIndex("dbo.DataEntities", new[] { "BiDimension_ID" });
            DropIndex("dbo.DataEntities", new[] { "BiFact_ID" });
            DropIndex("dbo.DataEntities", new[] { "BiMeasure_ID" });
            DropIndex("dbo.DataEntities", new[] { "InformationProduct_ID" });
            DropIndex("dbo.DataSources", new[] { "BiFact_ID" });
            DropIndex("dbo.AnalyticalMethods", new[] { "InformationProduct_ID" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.RoleRoles");
            DropTable("dbo.BiMeasureBiFacts");
            DropTable("dbo.BiMeasureBiDimensions");
            DropTable("dbo.BiFactBiDimensions");
            DropTable("dbo.DataSourceEmployees");
            DropTable("dbo.DataDeliveryChannelDataSources");
            DropTable("dbo.PerformanceMetricDataSources");
            DropTable("dbo.SubjectAreaPerformanceMetrics");
            DropTable("dbo.GovernanceSubjectAreas");
            DropTable("dbo.GovernanceEmployees");
            DropTable("dbo.GovernanceDataSources");
            DropTable("dbo.GovernanceBusinessInitiatives");
            DropTable("dbo.GovernanceBusinessFunctions");
            DropTable("dbo.GovernanceBusinessEntities");
            DropTable("dbo.SubjectAreaDataEntities");
            DropTable("dbo.SubjectAreaBusinessQuestions");
            DropTable("dbo.SubjectAreaBusinessInitiatives");
            DropTable("dbo.SubjectAreaBusinessFunctions");
            DropTable("dbo.SubjectAreaBusinessEntities");
            DropTable("dbo.BusinessQuestionPerformanceMetrics");
            DropTable("dbo.BusinessQuestionBusinessGoals");
            DropTable("dbo.BusinessQuestionBusinessFunctions");
            DropTable("dbo.BusinessQuestionBusinessEntities");
            DropTable("dbo.PerformanceMetricBusinessGoals");
            DropTable("dbo.PerformanceMetricBusinessEntities");
            DropTable("dbo.PerformanceMetricAnalyticalMethods");
            DropTable("dbo.DataEntityDataSources");
            DropTable("dbo.DataEntityDataDeliveryChannels");
            DropTable("dbo.SourceToolUdms");
            DropTable("dbo.MasterDataSourceTools");
            DropTable("dbo.MasterDataDataSources");
            DropTable("dbo.MasterDataDataEntities");
            DropTable("dbo.MasterDataBusinessEntities");
            DropTable("dbo.InformationProductSourceTools");
            DropTable("dbo.InformationProductBusinessEntities");
            DropTable("dbo.SourceToolDataSources");
            DropTable("dbo.SourceToolDataEntities");
            DropTable("dbo.SourceToolBusinessEntities");
            DropTable("dbo.UdmDataEntities");
            DropTable("dbo.UdmDataAttributes");
            DropTable("dbo.DataAttributeDataEntities");
            DropTable("dbo.DataAttributeBusinessEntities");
            DropTable("dbo.DataEntityBusinessEntities");
            DropTable("dbo.DataSourceBusinessEntities");
            DropTable("dbo.EmployeeBusinessInitiatives");
            DropTable("dbo.EmployeeBusinessFunctions");
            DropTable("dbo.BusinessInitiativeBusinessGoals");
            DropTable("dbo.BusinessInitiativeBusinessFunctions");
            DropTable("dbo.BusinessInitiativeBusinessEntities");
            DropTable("dbo.BusinessFunctionBusinessGoals");
            DropTable("dbo.BusinessGoalBusinessEntities");
            DropTable("dbo.BusinessEntityAnalyticalMethods");
            DropTable("dbo.Users");
            DropTable("dbo.SecuritySystemObjectPermissionsObjects");
            DropTable("dbo.SecuritySystemMemberPermissionsObjects");
            DropTable("dbo.TypePermissionObjects");
            DropTable("dbo.Roles");
            DropTable("dbo.ReportDataV2");
            DropTable("dbo.ModuleInfoes");
            DropTable("dbo.ModelDifferences");
            DropTable("dbo.ModelDifferenceAspects");
            DropTable("dbo.HCategories");
            DropTable("dbo.FileDatas");
            DropTable("dbo.DataLoadMaps");
            DropTable("dbo.ChangeRecords");
            DropTable("dbo.BiMeasures");
            DropTable("dbo.BiFacts");
            DropTable("dbo.BiDimensions");
            DropTable("dbo.Governances");
            DropTable("dbo.SubjectAreas");
            DropTable("dbo.BusinessQuestions");
            DropTable("dbo.PerformanceMetrics");
            DropTable("dbo.MasterDatas");
            DropTable("dbo.InformationProducts");
            DropTable("dbo.SourceTools");
            DropTable("dbo.Udms");
            DropTable("dbo.DataAttributes");
            DropTable("dbo.DataEntities");
            DropTable("dbo.DataDeliveryChannels");
            DropTable("dbo.DataSources");
            DropTable("dbo.Employees");
            DropTable("dbo.BusinessInitiatives");
            DropTable("dbo.BusinessFunctions");
            DropTable("dbo.BusinessGoals");
            DropTable("dbo.BusinessEntities");
            DropTable("dbo.AnalyticalMethods");
        }
    }
}
