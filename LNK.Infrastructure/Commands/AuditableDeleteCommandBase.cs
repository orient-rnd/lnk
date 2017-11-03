using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNK.Infrastructure.Commands
{
    public abstract class AuditableDeleteCommandBase : CommandBase, IAuditableDeleteCommand
    {
        public AuditableDeleteCommandBase()
        {
            IsDeleted = true;
            DeletedDate = DateTime.UtcNow;
        }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedDate { get; set; }

        public string DeletedBy { get; set; }
    }
}