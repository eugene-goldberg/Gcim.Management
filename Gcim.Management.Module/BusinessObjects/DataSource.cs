using System;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.Generic;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;

namespace Gcim.Management.Module.BusinessObjects
{
    // Register this entity in the DbContext using the "public DbSet<DataSource> DataSources { get; set; }" syntax.
    [DefaultClassOptions]
    public class DataSource : IXafEntityObject, IObjectSpaceLink, INotifyPropertyChanged
    {
        public DataSource()
        {
            // In the constructor, initialize collection properties, e.g.: 
             this.AssociatedSourceTools = new List<SourceTool>();
            this.AssociateMasterData = new List<MasterData>();
            this.AssociatedBusinessEntities = new List<BusinessEntity>();
            this.AssociatedDataEntities = new List<DataEntity>();
            this.AssociatedDataDeliveryChannels = new List<DataDeliveryChannel>();
            this.AssociatedPerformanceMetrics = new List<PerformanceMetric>();
            this.AssociatedEmployees = new List<Employee>();
            this.AssociatedGovernance = new List<Governance>();
        }
        [Browsable(false)]  // Hide the entity identifier from UI.
        public Int32 ID { get; protected set; }

        #region IXafEntityObject members (see https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppIXafEntityObjecttopic.aspx)
        void IXafEntityObject.OnCreated()
        {
            // Place the entity initialization code here.
            // You can initialize reference properties using Object Space methods; e.g.:
            // this.Address = objectSpace.CreateObject<Address>();
        }
        void IXafEntityObject.OnLoaded()
        {
            // Place the code that is executed each time the entity is loaded here.
        }
        void IXafEntityObject.OnSaving()
        {
            // Place the code that is executed each time the entity is saved here.
        }
        #endregion

        #region IObjectSpaceLink members (see https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppIObjectSpaceLinktopic.aspx)
        // Use the Object Space to access other entities from IXafEntityObject methods (see https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113707.aspx).
        private IObjectSpace objectSpace;
        IObjectSpace IObjectSpaceLink.ObjectSpace
        {
            get { return objectSpace; }
            set { objectSpace = value; }
        }
        #endregion

        #region INotifyPropertyChanged members (see http://msdn.microsoft.com/en-us/library/system.componentmodel.inotifypropertychanged(v=vs.110).aspx)
        private void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion


        public string Category { get; set; }
        public string SourceSystemName { get; set; }
        public string SourceSystemOwner { get; set; }
        public string SourceSystemLocation { get; set; }
        public string SourceSystemTeam { get; set; }
        public string SourceSystemNetworkSegment { get; set; }
        public string SourceSystemOsType { get; set; }
        public string SourceDatabaseName { get; set; }
        public string SourceDatabaseType { get; set; }
        public string SourceDatabaseVersion { get; set; }

        public virtual IList<SourceTool> AssociatedSourceTools { get; set; }
        public virtual IList<MasterData> AssociateMasterData { get; set; }
        public virtual IList<BusinessEntity> AssociatedBusinessEntities { get; set; }
        public virtual IList<DataEntity> AssociatedDataEntities { get; set; }
        public virtual IList<DataDeliveryChannel> AssociatedDataDeliveryChannels { get; set; }
        public virtual IList<PerformanceMetric> AssociatedPerformanceMetrics { get; set; }
        public virtual IList<Employee> AssociatedEmployees { get; set; }
        public virtual IList<Governance> AssociatedGovernance { get; set; }
    }
}
