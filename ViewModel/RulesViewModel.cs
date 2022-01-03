﻿using System;
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
        public ICommand MenuCommand { get; }

        public RulesViewModel()
        {
            MenuCommand = new NavigationCommand(Menu);
        }

        private MenuViewModel Menu()
        {
            return new MenuViewModel();
        }
    }
}