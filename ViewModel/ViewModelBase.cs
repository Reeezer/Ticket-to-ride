using System.ComponentModel;

/// <summary>
/// Toutes les vueModels héritent de cette vuemodel.
/// Permet de faire le binding avec INotifyPropertyChanged
/// </summary>
namespace Ticket_to_ride.ViewModel
{
    /// <summary>
    /// All the View Models inherit from this class to help to handle properties changements
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
