﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LNK.Infrastructure.Commands;

namespace LNK.Commands.Users
{
    public class DeleteUserPaymentProfileCommand : AuditableUpdateCommandBase
    {
        public string Id { get; set; }

        public string UserId { get; set; }
    }
}
