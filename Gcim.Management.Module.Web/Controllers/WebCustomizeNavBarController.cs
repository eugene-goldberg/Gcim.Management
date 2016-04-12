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
using DevExpress.ExpressApp.Web.Templates.ActionContainers;
using DevExpress.Web;

namespace Gcim.Management.Module.Web.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppWindowControllertopic.aspx.
    public partial class WebCustomizeNavBarController : WindowController
    {
        public WebCustomizeNavBarController()
        {
            //InitializeComponent();
            TargetWindowType = WindowType.Main;
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            Frame.ProcessActionContainer += Frame_ProcessActionContainer;
        }
        private void Frame_ProcessActionContainer(object sender, ProcessActionContainerEventArgs e)
        {
            if (e.ActionContainer is NavigationActionContainer)
            {
                ASPxNavBar navBar = ((NavigationActionContainer)e.ActionContainer).NavigationControl as ASPxNavBar;
                if (navBar != null)
                {
                    // Customize the main ASPxNavBar control. 
                    navBar.EnableAnimation = true;
                    foreach (NavBarGroup group in navBar.Groups)
                    {
                        group.Expanded = false;
                        //foreach (NavBarItem item in group.Items)
                        //{
                        //    if (item is NavBarTreeViewItem)
                        //    {
                        //        ASPxTreeView innerTreeView = ((NavBarTreeViewItem)item).TreeViewNavigationControl.Control;
                        //        // Customize the inner ASPxTreeView control inside the navigation group. 
                        //        innerTreeView.ShowExpandButtons = false;
                        //    }
                        //}
                    }
                }
                else {
                    ASPxTreeView mainTreeView = ((NavigationActionContainer)e.ActionContainer).NavigationControl as ASPxTreeView;
                    if (mainTreeView != null)
                    {
                        // Customize the main ASPxTreeView control. 
                        mainTreeView.ShowExpandButtons = false;
                    }
                }
            }
        }
        protected override void OnDeactivated()
        {
            base.OnDeactivated();
            Frame.ProcessActionContainer -= Frame_ProcessActionContainer;
        }

    }
}
