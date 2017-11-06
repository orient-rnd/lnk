﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNK.Infrastructure.Queries
{
    public interface IQueryHandler<in TQuery, out TResult> where TQuery : IQuery
    {
        TResult Handle(TQuery query);
    }
}