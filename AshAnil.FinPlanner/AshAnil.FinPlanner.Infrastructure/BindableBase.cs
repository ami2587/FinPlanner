using System.ComponentModel;

namespace AshAnil.FinPlanner.Infrastructure
{
    /// <summary>
    /// Base class to provide property change notification via INotifyPropertyChanged
    /// </summary>
    public abstract class BindableBase : INotifyPropertyChanged
    {
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #region INotifyPropertyChanged members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
