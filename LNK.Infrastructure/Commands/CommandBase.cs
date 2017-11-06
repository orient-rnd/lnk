using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNK.Infrastructure.Commands
{
    public abstract class CommandBase : ICommand
    {
    }

    public abstract class CommandBase<TCommandResult> : ICommand<TCommandResult>
    {
        public TCommandResult CommandResult { get; set; }
    }
}