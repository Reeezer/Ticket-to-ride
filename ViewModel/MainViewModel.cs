using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket_to_ride.Stores;

/// <summary>
/// VueModel pour la mainWindow
/// </summary>
namespace Ticket_to_ride.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ViewModelBase CurrentViewModel => NavigationStore.GetInstance().CurrentViewModel;

        public MainViewModel()
        {
            NavigationStore.GetInstance().CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
