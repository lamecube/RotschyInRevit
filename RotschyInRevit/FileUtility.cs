using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.Configuration;
using System.Diagnostics;
using System.Xml.Linq;
namespace RotschyInRevit
{
    public class FileUtility
    {


        public static String GetAssemblyPath()
        {
            if (string.IsNullOrEmpty(sm_assemblyPath))
                sm_assemblyPath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return sm_assemblyPath;
        }
        public static String GetAssemblyFullName()
        {
            if (string.IsNullOrEmpty(sm_assemblyFullName))
                sm_assemblyFullName = Assembly.GetExecutingAssembly().Location;
            return sm_assemblyFullName;
        }
        public static string GetApplicationResourcesPath()
        {
            if (string.IsNullOrEmpty(sm_appResourcePath))
                sm_appResourcePath = GetAssemblyPath() + "\\Resources\\";
            return sm_appResourcePath;
        }


        #region Data
        private static string sm_assemblyPath = null;
        private static string sm_assemblyFullName = null;
        private static string sm_appResourcePath = null;
        #endregion
    }
}
