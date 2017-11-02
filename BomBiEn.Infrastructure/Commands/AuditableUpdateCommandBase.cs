using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomBiEn.Infrastructure.Commands
{
    public abstract class AuditableUpdateCommandBase : CommandBase, IAuditableUpdateCommand
    {
        public AuditableUpdateCommandBase()
        {
            ModifiedDate = DateTime.UtcNow;
        }

        public DateTime? ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }
    }
}