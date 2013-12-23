using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AshAnil.FinPlanner.BusinessObjects
{
    /// <summary>
    /// This class denotes the information related to the different stored procedures
    /// related to a business object.
    /// </summary>
    internal class SPInformation
    {

        #region Fields

        #region Backing Fields

        string insertSPName;

        string updateSPName;

        string deleteSPName;

        string selectSPName;

        #endregion

        #endregion

        #region Properties

        /// <summary>
        /// Stored Procedure called upon when creating a new instance of the business object 
        /// and inserting the same in the database.
        /// </summary>
        public string InsertSPName
        {
            get
            {
                return insertSPName;
            }
        }

        /// <summary>
        /// Stored Procedure called upon when some values related to an already existing business object instance
        /// are updated and they need to be saved in the database.
        /// </summary>
        public string UpdateSPName
        {
            get
            {
                return updateSPName;
            }
        }

        /// <summary>
        /// Stored procedure called upon when an already existing instance of a business object is deleted.
        /// </summary>
        public string DeleteSPName
        {
            get
            {
                return deleteSPName;
            }
        }

        /// <summary>
        /// Stored procedure called upon when a particular instance of a business object needs to be
        /// fetched from the database.
        /// </summary>
        public string SelectSPName
        {
            get
            {
                return selectSPName;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="insertSPName"></param>
        /// <param name="updateSPName"></param>
        /// <param name="deleteSPName"></param>
        /// <param name="selectSPName"></param>
        public SPInformation(string insertSPName, string updateSPName, string deleteSPName, string selectSPName)
        {
            this.insertSPName = insertSPName;
            this.updateSPName = updateSPName;
            this.deleteSPName = deleteSPName;
            this.selectSPName = selectSPName;
        }

        #endregion

    }
}
