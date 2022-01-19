using System;
using Ticket_to_ride.Stores;
using Ticket_to_ride.ViewModel;

namespace Ticket_to_ride.Commands
{
    /// <summary>
    /// Call a method that returns a ViewModel to change to displayed View
    /// </summary>
    public class NavigationCommand : CommandBase
    {
        private readonly Func<ViewModelBase> targetedViewModel;

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
