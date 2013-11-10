
namespace AshAnil.FinPlanner.Infrastructure
{
    /// <summary>
    /// To hold first name, middle name and last name
    /// </summary>
    public class Name : BindableBase
    {
        #region Private Fields

        private string firstName;
        private string lastName;
        private string middleName;

        #endregion

        #region Constructor

        public Name(string firstName, string lastName = null, string middleName = null)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.middleName = middleName;
        }

        #endregion

        #region Public Properties

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                    OnPropertyChanged(() => FirstName);
                }
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (lastName != value)
                {
                    lastName = value;
                    OnPropertyChanged(() => LastName);
                }
            }
        }

        public string MiddleName
        {
            get
            {
                return middleName;
            }
            set
            {
                if (middleName != value)
                {
                    middleName = value;
                    OnPropertyChanged(() => MiddleName);
                }
            }
        }

        #endregion
    }
}
