
using Autodesk.Revit.UI;


namespace RotschyInRevit
{
    class MacroAPIExternalEventHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            ModelessCommandData data = RIR.thisApp.GetDockableAPIUtility().ModelessCommand.Take();
            RIR.thisApp.GetDockableAPIUtility().RunModelessCommand(data);
            RIR.thisApp.GetMainWindow().UpdateUI(RIR.thisApp.GetDockableAPIUtility().ModelessCommand.Take());
            RIR.thisApp.GetMainWindow().WakeUp();
        }

        public string GetName()
        {
            return "MacroAPIExternalEventHandler";
        }
    }
}
