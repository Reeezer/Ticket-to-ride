using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket_to_ride.ViewModel;

namespace Ticket_to_ride.Commands
{
    public class StartGameCommand : CommandBase
    {
        private readonly CreateGameViewModel createPlayersViewModel;

        public StartGameCommand(CreateGameViewModel createPlayersViewModel)
        {
            this.createPlayersViewModel = createPlayersViewModel;
        }

        public override void Execute(object parameter)
        {
            
        }
    }
}
