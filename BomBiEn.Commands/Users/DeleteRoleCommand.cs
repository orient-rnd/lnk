﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BomBiEn.Infrastructure.Commands;

namespace BomBiEn.Commands.Users
{
    public class DeleteRoleCommand : AuditableDeleteCommandBase
    {
        public string Id { get; set; }
    }
}
