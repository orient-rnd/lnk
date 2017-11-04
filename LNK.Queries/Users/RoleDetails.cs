using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNK.Queries.Users
{
    public class RoleDetails
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<string> Permissions { get; set; }
    }
}