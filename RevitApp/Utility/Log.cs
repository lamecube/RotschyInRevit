
using System;
using System.Diagnostics;

using Autodesk.Revit.UI;

namespace RevitApp
{
    public class Log
    {
        public static void Message(string message, int level = 0)
        {
            Console.WriteLine(message);
            Debug.WriteLine(message);
            if (level > 0)
                TaskDialog.Show("Revit", message);
        }
    }
}
