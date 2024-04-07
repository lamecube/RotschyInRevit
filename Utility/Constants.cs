using System;
using Autodesk.Revit.UI;

namespace RevitApp
{
    class Globals
    {

        public const string ApplicationName = "RevitApp";
        public const string DiagnosticsTabName = "RevitApp";
        public const string DiagnosticsPanelName = "RevitApp Panel";

        public const string RegisterPage = "Register Page";
        public const string ShowPage = "Show Page";
        public const string HidePage = "Hide Page";


        public static DockablePaneId sm_UserDockablePaneId = new DockablePaneId(new Guid("{3BAFCF52-AC5C-4CF8-B1CB-D0B1D0E90237}"));

    }
}
