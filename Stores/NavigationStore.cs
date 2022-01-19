using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket_to_ride.ViewModel;

namespace Ticket_to_ride.Stores
{
    /// <summary>
    /// Stores the current ViewModel used in MainWindow.xaml to update the views
    /// </summary>
    public class NavigationStore
    {
        private ViewModelBase currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => currentViewModel;
            set
            {
                currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }
        public event Action CurrentViewModelChanged;
        private static NavigationStore instance;

        /// <summary>
        /// Returns the only instance of it instanciated
        /// </summary>
        /// <returns>NavigationStore</returns>
        public static NavigationStore GetInstance()
        {
            if (instance == null)
            {
                instance = new NavigationStore();
            }
            return instance;
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
