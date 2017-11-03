using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LNK.Infrastructure.Queries;

namespace LNK.Queries.Users
{
    public class ListUserEmailsQuery : ListQueryBase
    {
        public string Email { get; set; }
    }
}