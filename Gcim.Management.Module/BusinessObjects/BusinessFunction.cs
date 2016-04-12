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
    // Register this entity in the DbContext using the "public DbSet<BusinessFcuntion> BusinessFcuntions { get; set; }" syntax.
    [DefaultClassOptions]
   
    public class BusinessFunction : IXafEntityObject, IObjectSpaceLink, INotifyPropertyChanged
    {
        public BusinessFunction()
        {
            // In the constructor, initialize collection properties, e.g.: 
            this.AssociatedSubjectAreas = new List<SubjectArea>();

            this.AssociatedBusinessInitiatives = new List<BusinessInitiative>();
            this.AssociatedBusinessGoals = new List<BusinessGoal>();
            this.AssociatedBusinessQuestions = new List<BusinessQuestion>();
            this.AssociatedGovernances = new List<Governance>();
            this.AssociatedEmployees = new List<Employee>();
        }
        [Browsable(false)]  // Hide the entity identifier from UI.
        public Int32 ID { get; protected set; }

       

        // Collection property:
        //public virtual IList<AssociatedEntityObject> AssociatedEntities { get; set; }

       

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

        public string Name { get; set; }
        public string Description { get; set; }
        public virtual IList<SubjectArea> AssociatedSubjectAreas { get; set; }
        public virtual IList<BusinessInitiative> AssociatedBusinessInitiatives { get; set; }
        public virtual IList<BusinessGoal> AssociatedBusinessGoals { get; set; }
        public virtual IList<BusinessQuestion> AssociatedBusinessQuestions { get; set; }
        public virtual IList<Governance> AssociatedGovernances { get; set; }
        public virtual IList<Employee> AssociatedEmployees { get; set; }
    }
}
