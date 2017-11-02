using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BomBiEn.Infrastructure.Queries;

namespace BomBiEn.Queries.Users
{
    public class GetRoleDetailsQuery : QueryBase
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}