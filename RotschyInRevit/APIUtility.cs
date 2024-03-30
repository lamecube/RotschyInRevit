using System;
using Autodesk.Revit.UI;

namespace RotschyInRevit
{
    /// <summary>
    /// A simple class to manage an interface into the Revit API.
    /// </summary>
    public partial class APIUtility
    {
        /// <summary>
        /// Store a reference to the application.
        /// </summary>
        public void Initialize(UIApplication uiApplication)
        {
            m_uiApplication = uiApplication;
        }

        /// <summary>
        /// Get the current Modeless command.
        /// </summary>
        public ModelessCommand ModelessCommand { get { return m_ModelessCommand; } }

        /// <summary>
        /// Return dockable pane inforamtion, given a dockable pane Guid.
        /// </summary>
        public string GetPaneSummary(string paneGuidString)
        {
            Guid paneGuid;
            try
            {
                paneGuid = new Guid(paneGuidString);
            }
            catch (Exception)
            {
                return "Invalid Guid";
            }
            DockablePaneId paneId = new DockablePaneId(paneGuid);
            return GetPaneSummary(paneId);
        }


        /// <summary>
        /// Return dockable pane inforamtion, given a DockablePaneId
        /// </summary>
        public string GetPaneSummary(DockablePaneId id)
        {
            DockablePane pane = null;
            try
            {
                pane = m_uiApplication.GetDockablePane(id);
                return GetPaneSummary(pane);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// Return dockable pane inforamtion, given a DockablePaneId
        /// </summary>
        public static string GetPaneSummary(DockablePane pane)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine("-RevitDockablePane- Title: " + pane.GetTitle() + ", Id-Guid: " + pane.Id.Guid.ToString());
            return sb.ToString();
        }

        /// <summary>
        /// Display docking state information as a string.
        /// </summary>
        public static string GetDockStateSummary(DockablePaneState paneState)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine(" -DockablePaneState-");
            sb.AppendLine(" Left: " + paneState.FloatingRectangle.Left.ToString());
            sb.AppendLine(" Right: " + paneState.FloatingRectangle.Right.ToString());
            sb.AppendLine(" Top: " + paneState.FloatingRectangle.Top.ToString());
            sb.AppendLine(" Bottom: " + paneState.FloatingRectangle.Bottom.ToString());
            sb.AppendLine(" Position: " + paneState.DockPosition.ToString());
            sb.AppendLine(" Tab target guid:" + paneState.TabBehind.Guid.ToString());
            return sb.ToString();
        }

        #region Data
        private Autodesk.Revit.UI.UIApplication m_uiApplication;
        private ModelessCommand m_ModelessCommand = new ModelessCommand();
        #endregion

    }
}
