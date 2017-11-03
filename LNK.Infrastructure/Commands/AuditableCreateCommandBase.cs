using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNK.Infrastructure.Commands
{
    public abstract class AuditableCreateCommandBase : CommandBase, IAuditableCreateCommand
    {
        public AuditableCreateCommandBase()
        {
            CreatedDate = DateTime.UtcNow;
        }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }
    }
}