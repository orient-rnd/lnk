using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LNK.Infrastructure.Commands;

namespace LNK.Commands.Users
{
    public class UpdateRoleCommand : CreateOrUpdateRoleCommandBase, IAuditableUpdateCommand
    {
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}