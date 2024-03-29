﻿using System;

namespace Ticket_to_ride.Commands
{
    /// <summary>
    /// Call a method on click
    /// </summary>
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
