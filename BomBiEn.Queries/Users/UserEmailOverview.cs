using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BomBiEn.Infrastructure.Queries;
using BomBiEn.Shared.Enums;

namespace BomBiEn.Queries.Users
{
    public class UserEmailOverview
    {
        public string Id { get; set; }

        public string Email { get; set; }
    }
}