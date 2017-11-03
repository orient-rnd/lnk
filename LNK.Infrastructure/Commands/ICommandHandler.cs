using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNK.Infrastructure.Commands
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        void Handle(TCommand command);        
    }

    public interface ICommandHandlerAsync<in TCommand> where TCommand : ICommand
    {        
        Task HandleAsync(TCommand command);
    }
}