using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace AshAnil.DataAccessLayer
{
    public class DBManager : IDisposable
    {

        #region Private Fields

        private string connectionString;
        private IDbConnection connection;
        private IDbCommand command;
        private IDbTransaction transaction;

        #endregion

        #region Public Properties

        public IDbConnection Connection
        {
            get
            {
                return connection;
            }
        }

        public string ConnectionString
        {
            get
            {
                return connectionString;
            }
        }

        public IDbCommand Command
        {
            get
            {
                return command;
            }
        }

        public IDbTransaction Transaction
        {
            get
            {
                return transaction;
            }
        }

        #endregion

        #region Constructor

        private DBManager()
        { }

        public DBManager(string connectionString)
        {
            this.connectionString = connectionString;
        }

        #endregion

        #region Public Methods

        public void Open()
        {
            connection = DBHelper.GetSQLConnection();
            connection.ConnectionString = ConnectionString;
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            command = DBHelper.GetSQLCommand();
        }

        public void Close()
        {
            if (connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Close();
            command = null;
            connection = null;
        }

        public DataSet ExecuteDataSet(CommandType commandType, string commandText, IDbDataParameter[] parameters)
        {
            command = DBHelper.GetSQLCommand();
            PrepareCommand(command, Connection, Transaction, commandType, commandText, parameters);
            IDbDataAdapter dataAdapter = DBHelper.GetSQLDataAdapter();
            dataAdapter.SelectCommand = command;
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            command.Parameters.Clear();
            return dataSet;
        }

        #endregion

        private void PrepareCommand(IDbCommand command, IDbConnection connection, IDbTransaction transaction, 
            CommandType commandType, string commandText, IDbDataParameter[] commandParameters)
        {
            command.Connection = connection;
            command.CommandText = commandText;
            command.CommandType = commandType;

            if (transaction != null)
            {
                command.Transaction = transaction;
            }

            if (commandParameters != null)
            {
                AttachParameters(command, commandParameters);
            }
        }

        private void AttachParameters(IDbCommand command, IDbDataParameter[] commandParameters)
        {
            foreach (IDbDataParameter idbParameter in commandParameters)
            {
                if ((idbParameter.Direction == ParameterDirection.InputOutput) && (idbParameter.Value == null))
                {
                    idbParameter.Value = DBNull.Value;
                }
                command.Parameters.Add(idbParameter);
            }
        }
    }

}
