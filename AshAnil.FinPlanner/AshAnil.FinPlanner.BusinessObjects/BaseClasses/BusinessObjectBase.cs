using AshAnil.FinPlanner.DBInfrastructure;
using AshAnil.FinPlanner.Infrastructure;

namespace AshAnil.FinPlanner.BusinessObjects
{
    /// <summary>
    /// Base class for all business objects
    /// </summary>
    public abstract class BusinessObjectBase : BindableBase
    {
        #region Private Fields

        uint id;
        BusinessObjectBase parent;

        #endregion

        #region Constructor

        public BusinessObjectBase(BusinessObjectBase parent)
        {
            this.id = IdFetcher.GetNextId();
            this.parent = parent;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Unsigned integer to uniquely identify a business object in a project ---------------------- comfirm this part
        /// </summary>
        public uint Id
        {
            get
            {
                return this.id;
            }
        }

        /// <summary>
        /// Parent business object
        /// </summary>
        public virtual BusinessObjectBase Parent
        {
            get
            {
                return parent;
            }
            set
            {
                if (parent != value)
                {
                    parent = value;
                    OnPropertyChanged("Parent");
                }
            }
        }

        #endregion
    }
}
