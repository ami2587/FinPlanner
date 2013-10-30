using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AshAnil.FinPlanner.DBInfrastructure
{
    public static class ProjectFileManagerDAO
    {

        #region Private Fields

        static ProjectFileManager projectFileManager;

        #endregion

        #region Public Properties

        public static ProjectFileManager ProjectFileManager
        {
            get
            {
                if (projectFileManager == null)
                {
                    projectFileManager = new ProjectFileManager();
                }
                return projectFileManager;
            }
        }

        #endregion

        #region Public Methods

        public static void CreateNewDatabase()
        {
            ProjectFileManager.CreateNewDatabase();
        }

        #endregion
    }
}
