﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BomBiEn.Infrastructure.Commands
{
    public interface IAuditableCreateCommand
    {
        DateTime CreatedDate { get; set; }

        string CreatedBy { get; set; }
    }
}