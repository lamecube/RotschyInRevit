
using Autodesk.Revit.UI;


namespace RotschyInRevit
{
   /// <summary>
   /// A class to manage the safe execution of events in a modeless dialog.
   /// </summary>
   class APIExternalEventHandler : IExternalEventHandler 
   {
      /// <summary>
      /// Called to execute an API command and update the UI after the command is finished.
      /// </summary>
      public void Execute(UIApplication app)
      {
         ModelessCommandData data = RIR.thisApp.GetDockableAPIUtility().ModelessCommand.Take();
         RIR.thisApp.GetDockableAPIUtility().RunModelessCommand(data);
         RIR.thisApp.GetMainWindow().UpdateUI(RIR.thisApp.GetDockableAPIUtility().ModelessCommand.Take());
         RIR.thisApp.GetMainWindow().WakeUp();
      }

      public string GetName()
      {
         return "APIExternalEventHandler";
      }
   }
}
