﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LNK.Infrastructure.Queries;

namespace LNK.Queries.Users
{
    public class ListRolesQuery : ListQueryBase
    {
        public string Name { get; set; }
    }
}
