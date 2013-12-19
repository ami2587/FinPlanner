using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AshAnil.FinPlanner.DBResources
{
    public static class DBResourcesHelper
    {
        public static Stream GetResourceStream(String resourcePath)
        {
            return Assembly.GetExecutingAssembly().GetManifestResourceStream(resourcePath);
        }
        
    }
}
