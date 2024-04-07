using Autodesk.Revit.UI;

namespace RevitApp
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
         ModelessCommandData data = App.run.GetDockableAPIUtility().ModelessCommand.Take();
         App.run.GetDockableAPIUtility().RunModelessCommand(data);
         App.run.GetMainWindow().UpdateUI(App.run.GetDockableAPIUtility().ModelessCommand.Take());
         App.run.GetMainWindow().WakeUp();
      }

      public string GetName()
      {
         return "APIExternalEventHandler";
      }
   }
}
