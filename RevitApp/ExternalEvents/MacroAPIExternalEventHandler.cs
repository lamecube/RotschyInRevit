using System.Linq;
using Autodesk.Revit.UI;

namespace RevitApp
{
    class MacroAPIExternalEventHandler : IExternalEventHandler 
   {
      public void Execute(UIApplication app)
      {
         ModelessCommandData data = App.run.GetDockableAPIUtility().ModelessCommand.Take();
         App.run.GetDockableAPIUtility().RunModelessCommand(data);
         App.run.GetMainWindow().UpdateUI(App.run.GetDockableAPIUtility().ModelessCommand.Take());
         App.run.GetMainWindow().WakeUp();
      }

      public string GetName()
      {
         return "MacroAPIExternalEventHandler";
      }
   }
}
