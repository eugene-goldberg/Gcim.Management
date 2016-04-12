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
    // Register this entity in the DbContext using the "public DbSet<UdmMeasure> UdmMeasures { get; set; }" syntax.
    [DefaultClassOptions]
   
    public class UdmMeasure : IXafEntityObject, IObjectSpaceLink, INotifyPropertyChanged
    {
        public UdmMeasure()
        {
            // In the constructor, initialize collection properties, e.g.: 
            this.AssociatedUdmFacts = new List<UdmFact>();
            this.AssociatedUdmDimensions = new List<UdmDimension>();
            this.AssociatedDataEntities = new List<DataEntity>();
        }
        [Browsable(false)]  // Hide the entity identifier from UI.
        public Int32 ID { get; protected set; }
        public string Measure { get; set; }
        public string EtlOrSsas { get; set; }
        public string SsasCalculation { get; set; }
        public string DataMartDatabaseName { get; set; }
        public string FactTableName { get; set; }
        public string DetailTableName { get; set; }

        public virtual IList<UdmFact> AssociatedUdmFacts { get; set; }
        public virtual IList<UdmDimension> AssociatedUdmDimensions { get; set; }
        public virtual IList<DataEntity> AssociatedDataEntities { get; set; }

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
    }
}
