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
    /// <summary>
    /// View Model used for the rules
    /// </summary>
    public class RulesViewModel : ViewModelBase
    {
        private GameViewModel parent;

        public ICommand MenuCommand { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        public RulesViewModel()
        {
            parent = null;
            MenuCommand = new NavigationCommand(Menu);
        }

        /// <summary>
        /// Stores where we come from
        /// </summary>
        /// <param name="parent">Parent</param>
        public RulesViewModel(GameViewModel parent) : this()
        {
            this.parent = parent;
        }

        /// <summary>
        /// Navigate: Rules View -> Menu View | Parent
        /// </summary>
        /// <returns>ViewModelBase</returns>
        private ViewModelBase Menu()
        {
            return parent ?? (ViewModelBase)new MenuViewModel();
        }
    }
}
