using System;
using System.Data;
using System.Linq;
using System.Data.Entity;
using System.Data.Common;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.ComponentModel;
using DevExpress.ExpressApp.EF.Updating;
using DevExpress.Persistent.BaseImpl.EF;

namespace  Gcim.Management.Module.BusinessObjects {
	public class ManagementDbContext : DbContext {
		public ManagementDbContext(String connectionString)
			: base(connectionString) {
		}
		public ManagementDbContext(DbConnection connection)
			: base(connection, false) {
		}
		public DbSet<ModuleInfo> ModulesInfo { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<TypePermissionObject> TypePermissionObjects { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<FileData> FileData { get; set; }
		public DbSet<HCategory> HCategories { get; set; }
		public DbSet<ReportDataV2> ReportDataV2 { get; set; }
		public DbSet<ModelDifference> ModelDifferences { get; set; }
		public DbSet<ModelDifferenceAspect> ModelDifferenceAspects { get; set; }
        public DbSet<SourceTool> SourceTools { get; set; }
        public DbSet<DataLoadMap> DataLoadMaps { get; set; }
        public DbSet<DataSource> DataSources { get; set; }
        public DbSet<AnalyticalMethod> AnalyticalMethods { get; set; }
        public DbSet<Udm> UdmInstances { get; set; }
        public DbSet<BusinessFunction> BusinessFunctions { get; set; }
        public DbSet<BusinessGoal> BusinessGoals { get; set; }
        public DbSet<BusinessInitiative> BusinessInitiatives { get; set; }
        public DbSet<BusinessQuestion> BusinessQuestions { get; set; }
        public DbSet<DataDeliveryChannel> DataDeliveryChannels { get; set; }
        public DbSet<DataEntity> DataEntities { get; set; }
        public DbSet<SubjectArea> SubjectAreas { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Governance> Governances { get; set; }
        public DbSet<MasterData> MasterDatas { get; set; }
        public DbSet<PerformanceMetric> PerformanceMetrics { get; set; }
        public DbSet<BusinessEntity> BusinessEntities { get; set; }
        public DbSet<ChangeRecord> ChangeRecords { get; set; }
        public DbSet<OdsDataAttribute> OdsDataAttributes { get; set; }
        public DbSet<UdmDataAttribute> UdmDataAttributes { get; set; }
        public DbSet<UdmDimension> UdmDimensions { get; set; }
        public DbSet<UdmFact> UdmFacts { get; set; }
        public DbSet<UdmMeasure> UdmMeasures { get; set; }

    }
}