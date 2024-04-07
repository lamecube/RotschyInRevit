using System;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace RevitApp
{

    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
   [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
   public class ExternalCommandHidePage : IExternalCommand, IExternalCommandAvailability
   {
      public virtual Result Execute(ExternalCommandData commandData
          , ref string message, ElementSet elements)
      {
         try
         {
            App.run.GetDockableAPIUtility().Initialize(commandData.Application);
            App.run.SetWindowVisibility(commandData.Application, false);
         }
         catch (Exception)
         {
            TaskDialog.Show("Dockable Dialogs", "Dialog not registered.");
         }
         return Result.Succeeded;
      }

      /// <summary>
      /// Onlys show the dialog when a document is  not open, as Dockable dialogs should only be registered when
      /// no documents are open.
      /// </summary>
      public bool IsCommandAvailable(UIApplication applicationData, CategorySet selectedCategories)
      {
         if (applicationData.ActiveUIDocument == null)
            return false;
         else
            return true;
      }
   }
}
