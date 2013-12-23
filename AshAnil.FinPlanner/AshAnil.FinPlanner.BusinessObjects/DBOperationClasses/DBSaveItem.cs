using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AshAnil.FinPlanner.BusinessObjects
{
    internal class DBSaveItem
    {

        #region Fields

        #region Backing Fields

        Dictionary<string, string> propertyNameToDBNameMapping = new Dictionary<string, string>();

        SPInformation spInformation;

        #endregion

        #endregion

        #region Properties

        /// <summary>
        /// This dictionary contains the mapping of the properties to be saved in the database to the actual name 
        /// of the field in the database where they are actually being stored.
        /// </summary>
        public Dictionary<string, string> PropertyNameToDBNameMapping
        {
            get
            {
                return propertyNameToDBNameMapping;
            }
        }

        /// <summary>
        /// This contains all information related to the various stored procedures needed for saving, inserting
        /// updating, deleting business objects
        /// </summary>
        public SPInformation SPInformation
        {
            get
            {
                return spInformation;
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
        /// <param name="selecSPName"></param>
        public DBSaveItem(string insertSPName, string updateSPName, string deleteSPName, string selectSPName)
        {
            spInformation = new SPInformation(insertSPName, updateSPName, deleteSPName, selectSPName);
        }

        #endregion

    }
}
