using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket_to_ride.Commands
{
    public class FunctionCommand : CommandBase
    {
        private readonly Action function;

        public FunctionCommand(Action function)
        {
            this.function = function;
        }

        public override void Execute(object parameter)
        {
            function();
        }
    }
}
