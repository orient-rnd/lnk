using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace BomBiEn.Infrastructure.Commands
{
    public class InProcessCommandBus : ICommandBus
    {
        private readonly IComponentContext _componentContext;

        public InProcessCommandBus(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        public virtual void Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            ICommandHandler<TCommand> commandHandler = _componentContext.Resolve<ICommandHandler<TCommand>>();
            Contract.Assert(commandHandler != null);

            commandHandler.Handle(command);
        }

        public virtual Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            ICommandHandlerAsync<TCommand> commandHandler = _componentContext.Resolve<ICommandHandlerAsync<TCommand>>();
            Contract.Assert(commandHandler != null);

            return commandHandler.HandleAsync(command);
        }
    }
}