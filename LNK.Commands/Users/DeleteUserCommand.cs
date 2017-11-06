﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LNK.Infrastructure.Commands;

namespace LNK.Commands.Users
{
    public class DeleteUserCommand : AuditableDeleteCommandBase
    {
        public string Id { get; set; }
    }
}