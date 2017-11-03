using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LNK.Infrastructure.Commands;

namespace LNK.Commands.Users
{
    public class ChangePasswordCommand : AuditableUpdateCommandBase
    {
        public string Id { get; set; }

        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }
    }
}