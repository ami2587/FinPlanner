using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AshAnil.FinPlanner.DBInfrastructure;

namespace AshAnil.FinPlanner
{
    public static class ProjectHelper
    {
        public static bool CreateNewProject()
        {
            bool isNewProjectCreated = false;
            ProjectFileManagerDAO.ProjectFileManager.CreateNewDatabase();
            return isNewProjectCreated;
        }
    }
}
