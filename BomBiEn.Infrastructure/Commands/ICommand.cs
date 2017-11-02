﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomBiEn.Infrastructure.Commands
{
    public interface ICommand
    {
    }

    public interface ICommand<TCommandResult> : ICommand
    {
        TCommandResult CommandResult { get; set; }
    }
}