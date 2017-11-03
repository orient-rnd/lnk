﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LNK.Infrastructure.Queries;

namespace LNK.Queries.Users
{
    public class ImpersonationQuery : QueryBase
    {
        public string Id { get; set; }

        public int NumberOfExpirationDays { get; set; }
    }
}