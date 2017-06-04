using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bing_Image.helper
{
    class RelayCommand : ICommand
    {

        #region Fields
        readonly Action<object> execute;
        readonly Predicate<object> canExecute;
        #endregion //Fields

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null ? true : canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { if (this.canExecute != null) CommandManager.RequerySuggested += value; }
            remove { if (this.canExecute != null) CommandManager.RequerySuggested -= value; }
        }
        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
        #endregion //ICommand Members

        #region Constructor

        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public RelayCommand()
        {
            // TODO: Complete member initialization
        }
        #endregion //Constructor

    }
}
