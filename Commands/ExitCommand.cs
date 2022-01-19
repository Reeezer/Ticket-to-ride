using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Ticket_to_ride.Commands
{
    /// <summary>
    /// Exit app on click
    /// </summary>
    public class ExitCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            Application.Current.MainWindow.Close();
        }
    }
}
