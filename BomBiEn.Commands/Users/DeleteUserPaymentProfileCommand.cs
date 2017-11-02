using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BomBiEn.Infrastructure.Commands;

namespace BomBiEn.Commands.Users
{
    public class DeleteUserPaymentProfileCommand : AuditableUpdateCommandBase
    {
        public string Id { get; set; }

        public string UserId { get; set; }
    }
}
