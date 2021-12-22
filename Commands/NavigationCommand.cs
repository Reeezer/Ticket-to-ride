using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket_to_ride.Stores;
using Ticket_to_ride.ViewModel;

namespace Ticket_to_ride.Commands
{
    public class NavigationCommand : CommandBase
    {
        private readonly Func<ViewModelBase> targetedViewModel;

        /// <summary>
        /// On lui passe une fonction qui lui permet de changer la vue. (faire des appels ou cherger des données avant de changer la vue.)
        /// </summary>
        /// <param name="targetedViewModel"></param>
        public NavigationCommand(Func<ViewModelBase> targetedViewModel)
        {
            this.targetedViewModel = targetedViewModel;
        }

        public override void Execute(object parameter)
        {
            NavigationStore.GetInstance().CurrentViewModel = targetedViewModel();
        }
    }
}
