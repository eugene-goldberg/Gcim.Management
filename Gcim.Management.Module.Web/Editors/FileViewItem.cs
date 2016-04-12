using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Web;
using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gcim.Management.Module.Web.Editors
{
    public interface IModelMyViewItem : IModelViewItem { }

    public interface IWebUserControl1
    {
        bool Enabled { get; set; }
    }

    [ViewItem(typeof(IModelMyViewItem))]
    public class MyViewItem : ViewItem
    {

        protected override object CreateControlCore()
        {
            ASPxFileManager result = new ASPxFileManager();
            result.Settings.RootFolder = "Obj";
            result.ClientSideEvents.CurrentFolderChanged = "function(s, e) { FileManagerCurrentFolderChanged(s, e); }";
            result.FilesUploaded += Result_FilesUploaded;
            result.SelectedFileOpened += Result_SelectedFileOpened;
            return result;
        }

        private void Result_SelectedFileOpened(object source, FileManagerFileOpenedEventArgs e)
        {
            var s = source;
            var ev = e;
            var p = "";
        }

        private void Result_FilesUploaded(object source, FileManagerFilesUploadedEventArgs e)
        {
            var s = source;
            var ev = e;
            var p = "";
        }

        public MyViewItem(IModelViewItem modelNode, Type objectType) : base(objectType, modelNode.Id) { }
    }
}
