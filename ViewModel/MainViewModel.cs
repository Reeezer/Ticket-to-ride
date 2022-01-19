using Ticket_to_ride.Stores;

namespace Ticket_to_ride.ViewModel
{
    /// <summary>
    /// View Model used for the MainWindow.xaml
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        public ViewModelBase CurrentViewModel => NavigationStore.GetInstance().CurrentViewModel;

        /// <summary>
        /// Constructor
        /// </summary>
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
