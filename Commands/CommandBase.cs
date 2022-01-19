using System;
using System.Windows.Input;

namespace Ticket_to_ride.Commands
{
    /// <summary>
    /// All the buttons inherit from this class to help to handle the click event
    /// </summary>
    public abstract class CommandBase : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public abstract void Execute(object parameter);

        protected void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
