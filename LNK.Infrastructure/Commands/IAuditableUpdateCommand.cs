using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNK.Infrastructure.Commands
{
    public interface IAuditableUpdateCommand
    {
        DateTime? ModifiedDate { get; set; }

        string ModifiedBy { get; set; }
    }
}