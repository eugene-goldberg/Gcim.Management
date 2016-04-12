using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using Gcim.Management.Module.BusinessObjects;
using DevExpress.Persistent.BaseImpl.EF;
using Syncfusion.XlsIO;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using DevExpress.ExpressApp.DC;
using System.Web;

namespace Gcim.Management.Module.Web.Controllers
{
    public partial class ViewController_DataLoadMap : ViewController
    {
        string workingDirectory = HttpContext.Current.Server.MapPath("~/obj");

        DataLoadMap dlm = null;

        static ITypeInfo targetBoType;
        public ViewController_DataLoadMap()
        {
            InitializeComponent();
            TargetViewId = "DataLoadMap_ListView";
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private void simpleActionLoadData_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var selectedObjects = View.SelectedObjects;
            dlm = (DataLoadMap)selectedObjects[0];
            var fieldMapsFile = dlm.FieldMapsImportFile;
            var fieldMapFileContents = fieldMapsFile.Content;
            var dataFile = dlm.InputFile;
            var dataFileContents = dataFile.Content;
            var fileType = dataFile.GetType();
            LoadData(dataFile, fieldMapsFile);
        }

        private void LoadData(FileData dataFile, FileData fieldMapsFile )
        {            
            using (FileStream fieldMapsFileStream = new FileStream(workingDirectory + @"\fieldMapsFile.xlsx", FileMode.Create))
            {                
                try
                {
                    fieldMapsFile.SaveToStream(fieldMapsFileStream);                   
                    fieldMapsFileStream.Write(fieldMapsFile.Content, 0, fieldMapsFile.Content.Length);
                    fieldMapsFileStream.Close();
                }
                catch (IOException ex)
                {

                }
            }

            using (FileStream dataFileStream = new FileStream(workingDirectory + @"\dataFile.xlsx", FileMode.Create))
            {
                try
                {
                    dataFile.SaveToStream(dataFileStream);
                    dataFileStream.Write(dataFile.Content, 0, dataFile.Content.Length);
                    dataFileStream.Close();
                }
                catch (IOException ex)
                {

                }
            }

            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IWorkbook fieldMapsWorkbook = excelEngine.Excel.Workbooks.Open(workingDirectory + @"\fieldMapsFile.xlsx");
                IWorksheet fieldMapsSheet = fieldMapsWorkbook.Worksheets[0];
                IRange fieldMapsRange = fieldMapsSheet.UsedRange;
                int numberOfFieldMapsRows = fieldMapsRange.Rows.Length;

                IWorkbook dataWorkbook = excelEngine.Excel.Workbooks.Open(workingDirectory + @"\dataFile.xlsx");
                IWorksheet dataSheet = dataWorkbook.Worksheets[0];
                IRange dataRange = dataSheet.UsedRange;
                int numberODatafRows = dataRange.Rows.Length;
                string dataFileTabName = dataSheet.Name;

                List<FieldMap> fieldMapList = new List<FieldMap>();

                for (int i = 1; i < numberOfFieldMapsRows; i++) //build a list of Field Maps
                {
                    FieldMap fieldMap = new FieldMap();

                    if (fieldMapsSheet.Rows[i].Cells[0].Value != "")
                    {
                        fieldMap.ExcelTabName = fieldMapsSheet.Rows[i].Cells[0].Value;
                    }

                    if (fieldMapsSheet.Rows[i].Cells[1].Value != "")
                    {
                        fieldMap.ExcelColumnName = fieldMapsSheet.Rows[i].Cells[1].Value;
                    }
                    if (fieldMapsSheet.Rows[i].Cells[2].Value != "")
                    {
                        fieldMap.ExcelColumnPosition = Convert.ToInt32(fieldMapsSheet.Rows[i].Cells[2].Value);
                    }

                    if (fieldMapsSheet.Rows[i].Cells[4].Value != "")
                    {
                        fieldMap.FieldName = fieldMapsSheet.Rows[i].Cells[4].Value;
                    }

                    fieldMapList.Add(fieldMap);
                }

                DoLoad(fieldMapList, numberODatafRows, dataSheet);
            }
        }

        private void DoLoad(List<FieldMap> fieldMaps, int numberOfDataRows, IWorksheet sheet)
        {
            for (int i = 1; i < numberOfDataRows; i++) //For each row of the input document
            {
                object targetObject = null;

                targetBoType = null;

                switch (sheet.Name)
                {
                    case "DataSource":
                            targetObject = ObjectSpace.CreateObject<DataSource>();
                            targetBoType = XafTypesInfo.Instance.FindTypeInfo(targetObject.GetType());
                            break;

                    case "DataDeliveryChannel":
                        targetObject = ObjectSpace.CreateObject<DataDeliveryChannel>();
                        targetBoType = XafTypesInfo.Instance.FindTypeInfo(targetObject.GetType());
                        break;

                    case "UdmDataAttribute":
                        targetObject = ObjectSpace.CreateObject<UdmDataAttribute>();
                        targetBoType = XafTypesInfo.Instance.FindTypeInfo(targetObject.GetType());
                        break;

                    case "SourceTool":
                        targetObject = ObjectSpace.CreateObject<SourceTool>();
                        targetBoType = XafTypesInfo.Instance.FindTypeInfo(targetObject.GetType());
                        break;

                    case "UdmFact":
                        targetObject = ObjectSpace.CreateObject<UdmFact>();
                        targetBoType = XafTypesInfo.Instance.FindTypeInfo(targetObject.GetType());
                        break;

                    case "UdmDimension":
                        targetObject = ObjectSpace.CreateObject<UdmDimension>();
                        targetBoType = XafTypesInfo.Instance.FindTypeInfo(targetObject.GetType());
                        break;

                    case "UdmMeasure":
                        targetObject = ObjectSpace.CreateObject<UdmMeasure>();
                        targetBoType = XafTypesInfo.Instance.FindTypeInfo(targetObject.GetType());
                        break;

                    case "BusinessEntity":
                        targetObject = ObjectSpace.CreateObject<BusinessEntity>();
                        targetBoType = XafTypesInfo.Instance.FindTypeInfo(targetObject.GetType());
                        break;

                    case "BusinessFunction":
                        targetObject = ObjectSpace.CreateObject<BusinessFunction>();
                        targetBoType = XafTypesInfo.Instance.FindTypeInfo(targetObject.GetType());
                        break;

                    case "BusinessGoal":
                        targetObject = ObjectSpace.CreateObject<BusinessGoal>();
                        targetBoType = XafTypesInfo.Instance.FindTypeInfo(targetObject.GetType());
                        break;

                    case "BusinessInitiative":
                        targetObject = ObjectSpace.CreateObject<BusinessInitiative>();
                        targetBoType = XafTypesInfo.Instance.FindTypeInfo(targetObject.GetType());
                        break;

                    case "BusinessQuestion":
                        targetObject = ObjectSpace.CreateObject<BusinessQuestion>();
                        targetBoType = XafTypesInfo.Instance.FindTypeInfo(targetObject.GetType());
                        break;

                    case "DataEntity":
                        targetObject = ObjectSpace.CreateObject<DataEntity>();
                        targetBoType = XafTypesInfo.Instance.FindTypeInfo(targetObject.GetType());
                        break;

                    case "Employee":
                        targetObject = ObjectSpace.CreateObject<Employee>();
                        targetBoType = XafTypesInfo.Instance.FindTypeInfo(targetObject.GetType());
                        break;

                    case "Governance":
                        targetObject = ObjectSpace.CreateObject<Governance>();
                        targetBoType = XafTypesInfo.Instance.FindTypeInfo(targetObject.GetType());
                        break;

                    case "InformationProduct":
                        targetObject = ObjectSpace.CreateObject<InformationProduct>();
                        targetBoType = XafTypesInfo.Instance.FindTypeInfo(targetObject.GetType());
                        break;

                    case "MasterData":
                        targetObject = ObjectSpace.CreateObject<MasterData>();
                        targetBoType = XafTypesInfo.Instance.FindTypeInfo(targetObject.GetType());
                        break;

                    case "PerformanceMetric":
                        targetObject = ObjectSpace.CreateObject<PerformanceMetric>();
                        targetBoType = XafTypesInfo.Instance.FindTypeInfo(targetObject.GetType());
                        break;

                    case "SubjectArea":
                        targetObject = ObjectSpace.CreateObject<SubjectArea>();
                        targetBoType = XafTypesInfo.Instance.FindTypeInfo(targetObject.GetType());
                        break;

                    case "Udm":
                        targetObject = ObjectSpace.CreateObject<Udm>();
                        targetBoType = XafTypesInfo.Instance.FindTypeInfo(targetObject.GetType());
                        break;

                    default:
                        break;
                }

                foreach (FieldMap curentFieldMap in fieldMaps) 
                {
                    foreach (var member in targetBoType.Members) 
                    {
                        if (member.IsPublic && member.Name == curentFieldMap.FieldName) 
                        {
                            if (member.MemberTypeInfo.ToString() == "System.Int32")
                            {
                                if (!string.IsNullOrEmpty(sheet.Rows[i].Cells[curentFieldMap.ExcelColumnPosition].Value) && sheet.Rows[i].Cells[curentFieldMap.ExcelColumnPosition].Value != "NULL")
                                {
                                    object cellvalue = sheet.Rows[i].Cells[curentFieldMap.ExcelColumnPosition].Value;
                                    object value = null;
                                    try
                                    {
                                        value = Convert.ToInt32(cellvalue);
                                    }
                                    catch (Exception ex) { }

                                    if (value != null)
                                    {
                                        member.SetValue(targetObject, (int)Math.Round(Convert.ToDouble(sheet.Rows[i].Cells[curentFieldMap.ExcelColumnPosition].Value)));
                                    }
                                }
                            }

                            if (member.MemberTypeInfo.ToString() == "System.Double")
                            {
                                if (!string.IsNullOrEmpty(sheet.Rows[i].Cells[curentFieldMap.ExcelColumnPosition].Value))
                                {
                                    if (i > 1)
                                    {
                                        object cellvalue = sheet.Rows[i].Cells[curentFieldMap.ExcelColumnPosition].Value;
                                        object value = null;
                                        //try
                                        //{
                                        value = Convert.ToDouble(cellvalue);
                                        //}
                                        //catch (Exception ex) { }
                                        if (value != null)
                                        {
                                            member.SetValue(targetObject, Convert.ToDouble((sheet.Rows[i].Cells[curentFieldMap.ExcelColumnPosition].Value).Trim()));
                                        }
                                    }
                                }
                            }

                            if (member.MemberTypeInfo.ToString() == "System.Decimal")
                            {
                                if (!string.IsNullOrEmpty(sheet.Rows[i].Cells[curentFieldMap.ExcelColumnPosition].Value))
                                {
                                    if (i > 1)
                                    {
                                        object cellvalue = sheet.Rows[i].Cells[curentFieldMap.ExcelColumnPosition].Value;
                                        object value = null;
                                        try
                                        {
                                            value = Convert.ToDecimal(cellvalue);
                                        }
                                        catch (Exception ex) { }
                                        if (value != null)
                                        {
                                            member.SetValue(targetObject, Convert.ToDecimal((sheet.Rows[i].Cells[curentFieldMap.ExcelColumnPosition].Value).Trim()));
                                        }
                                    }
                                }
                            }

                            if (member.MemberTypeInfo.ToString() == "System.String")
                            {
                                if (!string.IsNullOrEmpty(sheet.Rows[i].Cells[curentFieldMap.ExcelColumnPosition].Value))
                                {
                                    member.SetValue(targetObject, sheet.Rows[i].Cells[curentFieldMap.ExcelColumnPosition].Value);
                                }
                            }

                            if (member.MemberTypeInfo.ToString() == "System.DateTime")
                            {
                                if (!string.IsNullOrEmpty(sheet.Rows[i].Cells[curentFieldMap.ExcelColumnPosition].Value))
                                {
                                    try
                                    {
                                        member.SetValue(targetObject, Convert.ToDateTime(sheet.Rows[i].Cells[curentFieldMap.ExcelColumnPosition].Value));
                                    }
                                    catch (Exception exc) { }
                                }
                            }

                            if (member.Name == "IsNewRecord")
                            {
                                member.SetValue(targetObject, "Y");
                            }
                        }
                    }

                }
                ObjectSpace.CommitChanges();
            }
        }
    }
}
