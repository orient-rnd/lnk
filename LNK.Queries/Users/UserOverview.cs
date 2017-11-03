using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LNK.Infrastructure.Queries;
using LNK.Shared.Enums;

namespace LNK.Queries.Users
{
    public class UserOverview : AuditableEntityOverviewBase
    {
        public string Id { get; set; }

        public UserType UserType { get; set; }

        public GenderType Gender { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public DateTime? DateOfBirth { get; set; }
    }
}