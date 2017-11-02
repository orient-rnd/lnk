using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BomBiEn.Infrastructure.Commands;

namespace BomBiEn.Commands.Users
{
    public class UpdateRoleCommand : CreateOrUpdateRoleCommandBase, IAuditableUpdateCommand
    {
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}