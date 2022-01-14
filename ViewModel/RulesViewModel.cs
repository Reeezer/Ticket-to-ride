using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Ticket_to_ride.Commands;
using Ticket_to_ride.Enums;
using Ticket_to_ride.Model;

namespace Ticket_to_ride.ViewModel
{
    public class RulesViewModel : ViewModelBase
    {
        private GameViewModel parent;

        public ICommand MenuCommand { get; }

        public RulesViewModel()
        {
            parent = null;
            Console.WriteLine("In Costructor");
            MenuCommand = new NavigationCommand(Menu);
        }

        public RulesViewModel(GameViewModel parent) : this()
        {
            Console.WriteLine("In second constructor");
            this.parent = parent;
        }

        private ViewModelBase Menu()
        {
            Console.WriteLine("aeflhgvaczubigbrjf");
            Console.WriteLine(parent);
            if (this.parent != null)
            {
                Console.WriteLine("I'm in !");
                return this.parent;
            }
            return new MenuViewModel();
        }
    }
}
