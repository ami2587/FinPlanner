using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AshAnil.FinPlanner.DBInfrastructure
{
    public static class DBHelper
    {

        public static string GetUserAppDataFolderPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        }

    }
}
