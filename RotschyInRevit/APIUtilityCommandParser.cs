namespace RotschyInRevit
{
    public partial class APIUtility
    {
        /// <summary>
        /// A method to examine an incoming command and start the process of executing
        /// safely in the Idle() or ExternalEvent() loop.
        /// </summary>
        public void RunModelessCommand(ModelessCommandData command)
        {
            switch (command.CommandType)
            {
                case ModelessCommandType.PrintMainPageStatistics:
                    {
                        command.WindowSummaryData = GetPaneSummary(RIR.thisApp.MainPageDockablePaneId);
                        ModelessCommand.Make(command);
                        break;
                    }

                case ModelessCommandType.PrintSelectedPageStatistics:
                    {
                        command.WindowSummaryData = GetPaneSummary(command.SelectedPaneId);
                        ModelessCommand.Make(command);
                        break;
                    }


                default:
                    break;
            }
        }
    }
}