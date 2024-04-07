using System;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace RevitApp
{

    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
   [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
   public class ExternalCommandRegisterPage : IExternalCommand, IExternalCommandAvailability
   {
      public virtual Result Execute(ExternalCommandData commandData
          , ref string message, ElementSet elements)
      {
         App.run.GetDockableAPIUtility().Initialize(commandData.Application);
        App.run.CreateWindow();

         DockingSetupDialog dlg = new DockingSetupDialog();
         Nullable<bool> dlgResult = dlg.ShowDialog();
         if (dlgResult == false)
            return Result.Succeeded;
       
         App.run.GetMainWindow().SetInitialDockingParameters(dlg.FloatLeft, dlg.FloatRight, dlg.FloatTop, dlg.FloatBottom, dlg.DockPosition, dlg.TargetGuid);
         try
         {
           App.run.RegisterDockableWindow(commandData.Application, dlg.MainPageGuid);
         }
         catch (Exception ex)
         {
            TaskDialog.Show(Globals.ApplicationName, ex.Message);
         }
         return Result.Succeeded;
      }

      /// <summary>
      /// Onlys show the dialog when a document is open, as Dockable dialogs are only available
      /// when a document is open.
      /// </summary>
      public bool IsCommandAvailable(UIApplication applicationData, CategorySet selectedCategories)
      {
         if (applicationData.ActiveUIDocument == null)
            return true;
         else
            return false;
      }
   }
}
