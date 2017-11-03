using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LNK.Infrastructure.Queries;
using LNK.Shared.Enums;

namespace LNK.Queries.Users
{
    public class UserEmailOverview
    {
        public string Id { get; set; }

        public string Email { get; set; }
    }
}