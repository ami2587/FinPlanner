
namespace AshAnil.FinPlanner.Infrastructure
{
    /// <summary>
    /// Class to represent money along with the currency
    /// </summary>
    public class Money : BindableBase
    {
        #region Private Fields

        CurrencyCode currencyCode;
        decimal amount;

        #endregion

        #region Constructor

        public Money(CurrencyCode currencyCode, decimal amount)
        {
            this.currencyCode = currencyCode;
            this.amount = amount;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Represnts the currency of the current amount
        /// Note - Changing currency is not the same as performing a conversion of the amount so as to retain the same monetary value, 
        ///         it just represents the currency being used
        /// </summary>
        public CurrencyCode CurrencyCode
        {
            get
            {
                return currencyCode;
            }
            set
            {
                if (currencyCode != value)
                {
                    currencyCode = value;
                    OnPropertyChanged("CurrencyCode");
                }
            }
        }

        public decimal Amount
        {
            get
            {
                return amount;
            }
            set
            {
                if (amount != value)
                {
                    amount = value;
                    OnPropertyChanged("Amount");
                }
            }
        }

        #endregion
    }
}
