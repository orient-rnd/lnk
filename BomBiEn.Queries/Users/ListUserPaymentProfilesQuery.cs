﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BomBiEn.Infrastructure.Queries;

namespace BomBiEn.Queries.Users
{
    public class ListUserPaymentProfilesQuery : ListQueryBase
    {
        public string UserId { get; set; }
    }
}
