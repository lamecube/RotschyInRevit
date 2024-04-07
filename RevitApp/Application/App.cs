using System;
using System.Windows.Media.Imaging;
using Autodesk.Revit.UI;
using Autodesk.Revit;

namespace RevitApp
{
    /// <summary>
    /// Implements the Revit add-in interface IExternalApplication
    /// </summary>
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public class App : IExternalApplication
    {
       public App()
       {
       }

       public Result OnShutdown(UIControlledApplication application)
       {
          return Result.Succeeded;
       }

       /// <summary>
       /// Register a dockable Window
       /// </summary>
       public void RegisterDockableWindow(UIApplication  application, Guid mainPageGuid)
       {
          Globals.sm_UserDockablePaneId = new DockablePaneId(mainPageGuid);
          application.RegisterDockablePane(Globals.sm_UserDockablePaneId, Globals.ApplicationName, App.run.GetMainWindow() as IDockablePaneProvider);
       }

       /// <summary>
       /// Register a dockable Window
       /// </summary>
       public void RegisterDockableWindow(UIControlledApplication application, Guid mainPageGuid)
       {
          Globals.sm_UserDockablePaneId = new DockablePaneId(mainPageGuid);
          application.RegisterDockablePane(Globals.sm_UserDockablePaneId, Globals.ApplicationName, App.run.GetMainWindow() as IDockablePaneProvider);
       }

       /// <summary>
       /// Add UI for registering, showing, and hiding dockable panes.
       /// </summary>
       public Result OnStartup(UIControlledApplication application)
       {
          run = this;
          m_APIUtility = new APIUtility();

          application.CreateRibbonTab(Globals.DiagnosticsTabName);
          RibbonPanel panel = application.CreateRibbonPanel(Globals.DiagnosticsTabName, Globals.DiagnosticsPanelName);
          
          panel.AddSeparator();

          PushButtonData pushButtonRegisterPageData = new PushButtonData(Globals.RegisterPage, Globals.RegisterPage,
          FileUtility.GetAssemblyFullName(), typeof(ExternalCommandRegisterPage).FullName);
          pushButtonRegisterPageData.LargeImage = new BitmapImage(new Uri(FileUtility.GetApplicationResourcesPath() + "Register.png"));
          PushButton pushButtonRegisterPage = panel.AddItem(pushButtonRegisterPageData) as PushButton;
          pushButtonRegisterPage.AvailabilityClassName = typeof(ExternalCommandRegisterPage).FullName;


          PushButtonData pushButtonShowPageData = new PushButtonData(Globals.ShowPage, Globals.ShowPage,FileUtility.GetAssemblyFullName(), typeof(ExternalCommandShowPage).FullName);
          pushButtonShowPageData.LargeImage = new BitmapImage(new Uri(FileUtility.GetApplicationResourcesPath() + "Show.png"));
          PushButton pushButtonShowPage = panel.AddItem(pushButtonShowPageData) as PushButton;
          pushButtonShowPage.AvailabilityClassName = typeof(ExternalCommandShowPage).FullName;


          PushButtonData pushButtonHidePageData = new PushButtonData(Globals.HidePage, Globals.HidePage, FileUtility.GetAssemblyFullName(), typeof(ExternalCommandHidePage).FullName);
          pushButtonHidePageData.LargeImage = new BitmapImage(new Uri(FileUtility.GetApplicationResourcesPath() + "Hide.png"));
          PushButton pushButtonHidePage = panel.AddItem(pushButtonHidePageData) as PushButton;
          pushButtonHidePage.AvailabilityClassName = typeof(ExternalCommandHidePage).FullName;

          return Result.Succeeded;
       }

       /// <summary>
       /// Create the new WPF Page that Revit will dock.
       /// </summary>
       public void CreateWindow()
       {
          m_mainPage = new MainPage();
       }

       /// <summary>
       /// Show or hide a dockable pane.
       /// </summary>
       public void SetWindowVisibility(Autodesk.Revit.UI.UIApplication application, bool state) 
       {
          DockablePane pane = application.GetDockablePane(Globals.sm_UserDockablePaneId);
          if (pane != null)
          {
             if (state)
                pane.Show();
             else
                pane.Hide();
          }


       }


       public bool IsMainWindowAvailable()
       {

          if (m_mainPage == null)
             return false;

          bool isAvailable = true;
          try {  bool isVisible = m_mainPage.IsVisible; }
          catch (Exception)
          {
             isAvailable = false;
          }
          return isAvailable;

       }

       public MainPage GetMainWindow()
       {
          if (!IsMainWindowAvailable())
             throw new InvalidOperationException("Main window not constructed.");
          return m_mainPage;
       }
  
       public APIUtility GetDockableAPIUtility() { return m_APIUtility; }

   

       public Autodesk.Revit.UI.DockablePaneId MainPageDockablePaneId
       {

          get { return Globals.sm_UserDockablePaneId; }
       }

       #region Data

        MainPage m_mainPage;
        internal static App run = null;
        private APIUtility m_APIUtility;


       #endregion

    }
}

