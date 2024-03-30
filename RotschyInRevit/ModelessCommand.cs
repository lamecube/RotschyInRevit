namespace RotschyInRevit
{

    /// <summary>
    /// A thread-safe class for getting and setting modeless-command data.
    /// </summary>
    public class ModelessCommand
    {

        /// <summary>
        /// Set data into the command.
        /// </summary>
        public void Make(ModelessCommandData commandData)
        {
            lock (this)
            {
                m_data = commandData;
            }
        }

        /// <summary>
        /// Get data from the command.
        /// </summary>
        public ModelessCommandData Take()
        {
            lock (this)
            {
                return m_data;
            }

        }
        private ModelessCommandData m_data = new ModelessCommandData();

    }
    public enum ModelessCommandType : int
    {
        PrintMainPageStatistics,
        PrintSelectedPageStatistics,
        Return
    }

    public class ModelessCommandData
    {
        public ModelessCommandData() { }
        public ModelessCommandType CommandType;
        public string WindowSummaryData;
        public string SelectedPaneId;
    }
}