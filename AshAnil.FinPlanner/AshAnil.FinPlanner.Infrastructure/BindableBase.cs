using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace AshAnil.FinPlanner.Infrastructure
{
    /// <summary>
    /// Base class to provide property change notification via INotifyPropertyChanged
    /// </summary>
    public abstract class BindableBase : INotifyPropertyChanged
    {
        protected void OnPropertyChanged<T>(Expression<Func<T>> expression)
        {
            if (PropertyChanged != null)
            {
                string propertyName = GetPropertyName(expression);
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Get the string name for the property
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        protected string GetPropertyName<T>(Expression<Func<T>> expression)
        {
            MemberExpression memberExpression = (MemberExpression)expression.Body;
            return memberExpression.Member.Name;
        }

        #region INotifyPropertyChanged members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
