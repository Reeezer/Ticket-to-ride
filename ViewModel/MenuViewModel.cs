using System.Windows.Input;
using Ticket_to_ride.Commands;

namespace Ticket_to_ride.ViewModel
{
    /// <summary>
    /// View Model used for the menu
    /// </summary>
    public class MenuViewModel : ViewModelBase
    {
        public ICommand NewGameCommand { get; }
        public ICommand ExitCommand { get; }

        public ICommand RulesCommand { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        public MenuViewModel()
        {
            NewGameCommand = new NavigationCommand(NewGame);
            ExitCommand = new ExitCommand();
            RulesCommand = new NavigationCommand(OpenRules);
        }

        /// <summary>
        /// Navigate: Menu View -> Game Create View
        /// </summary>
        /// <returns>MenuCreateGameViewModel</returns>
        private MenuCreateGameViewModel NewGame()
        {
            return new MenuCreateGameViewModel();
        }

        /// <summary>
        /// Navigate: Menu View -> Rules View
        /// </summary>
        /// <returns>RulesViewModel</returns>
        private RulesViewModel OpenRules()
        {
            return new RulesViewModel();
        }
    }
}
