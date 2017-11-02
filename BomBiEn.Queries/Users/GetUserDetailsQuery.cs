using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BomBiEn.Infrastructure.Queries;

namespace BomBiEn.Queries.Users
{
    public class GetUserDetailsQuery : QueryBase
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }
    }
}