using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LNK.Infrastructure.Queries;

namespace LNK.Queries.Users
{
    public class GetUserDetailsQuery : QueryBase
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }
    }
}