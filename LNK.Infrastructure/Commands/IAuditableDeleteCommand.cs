using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNK.Infrastructure.Commands
{
    public interface IAuditableDeleteCommand : ICommand
    {
        DateTime? DeletedDate { get; set; }

        string DeletedBy { get; set; }
    }
}