using System;
using Autodesk.Revit.UI;

namespace RotschyInRevit
{
    class Globals
    {

        public const string ApplicationName = "RotschyInRevit";
        public const string DiagnosticsTabName = "RotschyInRevit";
        public const string DiagnosticsPanelName = "Rotschy Inc Utils";

        public const string RegisterPage = "Register Page";
        public const string ShowPage = "Show Page";
        public const string HidePage = "Hide Page";


        public static DockablePaneId sm_UserDockablePaneId = new DockablePaneId(new Guid("{3BAFCF52-AC5C-4CF8-B1CB-D0B1D0E90237}"));

    }
}
