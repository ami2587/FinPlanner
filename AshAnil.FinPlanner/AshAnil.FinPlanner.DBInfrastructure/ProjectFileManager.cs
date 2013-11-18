using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace AshAnil.FinPlanner.DBInfrastructure
{
    public class ProjectFileManager
    {

        #region Constants and Variables

        private const string LOGFILENAMESUFFIX = "_log";

        #endregion

        #region Constructor

        public ProjectFileManager()
        {

        }

        #endregion

        #region Public Methods

        public void CreateNewDatabase()
        {
            CreateNewDatabaseInternal();
        }

        #endregion

        #region Private methods

        private void CreateNewDatabaseInternal()
        {

            using (SqlConnection sqlConnectionStringToLocalServer =
                new SqlConnection(ConfigurationManager.ConnectionStrings[Constants.MASTERDBCONNECTIONSTRING].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand(GetSQLQueryToCreateNewDatabase(), sqlConnectionStringToLocalServer))
                {
                    sqlConnectionStringToLocalServer.Open();
                    myCommand.ExecuteNonQuery();
                }
            }

            //SqlConnection sqlConnectionStringToLocalServer = new SqlConnection(ConfigurationManager.ConnectionStrings[Constants.MASTERDBCONNECTIONSTRING].ConnectionString);
            //SqlCommand myCommand = new SqlCommand(GetSQLQueryToCreateNewDatabase(), sqlConnectionStringToLocalServer);
            //try
            //{
            //    sqlConnectionStringToLocalServer.Open();
            //    myCommand.ExecuteNonQuery();
            //}
            //catch (Exception ex)
            //{

            //}
            //finally
            //{
            //    if (sqlConnectionStringToLocalServer.State == ConnectionState.Open)
            //    {
            //        sqlConnectionStringToLocalServer.Close();
            //    }
            //}
        }

        private string GetSQLQueryToCreateNewDatabase()
        {
            string sqlCommandCreateNewProject = string.Empty;
            string mdfFilePath = Path.Combine(DBHelper.GetUserAppDataFolderPath(), Constants.DATABASENAME + Constants.MDFFILEEXTENSION); //Master data file path
            string ldfFilePath = Path.Combine(DBHelper.GetUserAppDataFolderPath(), Constants.DATABASENAME + Constants.LDFFILEEXTENSION); //Log data file path
            string ldfFileName = Constants.DATABASENAME + LOGFILENAMESUFFIX; //Log data file name
            sqlCommandCreateNewProject = "CREATE DATABASE " + Constants.DATABASENAME + " ON PRIMARY " +
                "(NAME = " + Constants.DATABASENAME + ", FILENAME = '" + mdfFilePath + "', " +
                "SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%) " +
                "LOG ON (NAME = " + ldfFileName + ", FILENAME = '" + ldfFilePath + "', " +
                "SIZE = 1MB, MAXSIZE = 5MB, FILEGROWTH = 10%)";
            return sqlCommandCreateNewProject;
        }

        private void ExportDatabase(string filePath)
        {
            Backup sqlBackup = new Backup();
            sqlBackup.Action = BackupActionType.Database;
            sqlBackup.Database = Constants.DATABASENAME;

            BackupDeviceItem backupDeviceItem = new BackupDeviceItem(Path.Combine(filePath, "FullBackUp.bak"), DeviceType.File);
            ServerConnection serverConnection = new ServerConnection(new SqlConnection
                                    (ConfigurationManager.ConnectionStrings[Constants.SERVERCONNECTIONSTRING].ConnectionString));
            Server sqlServer = new Server(serverConnection);
            sqlServer.ConnectionContext.StatementTimeout = 60 * 60;
            Database database = sqlServer.Databases[Constants.DATABASENAME];

            sqlBackup.Initialize = true;
            sqlBackup.Checksum = true;
            sqlBackup.ContinueAfterError = true;

            //Add the device to the Backup object.
            sqlBackup.Devices.Add(backupDeviceItem);
            //Set the Incremental property to False to specify that this is a full database backup.
            sqlBackup.Incremental = false;

            sqlBackup.ExpirationDate = DateTime.Now.AddDays(3);
            //Specify that the log must be truncated after the backup is complete.
            sqlBackup.LogTruncation = BackupTruncateLogType.Truncate;

            sqlBackup.FormatMedia = false;
            //Run SqlBackup to perform the full database backup on the instance of SQL Server.
            sqlBackup.SqlBackup(sqlServer);
            //Remove the backup device from the Backup object.
            sqlBackup.Devices.Remove(backupDeviceItem);
        }

        #endregion

    }
}
