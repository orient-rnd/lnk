using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BomBiEn.Infrastructure.Queries;
using BomBiEn.Shared.Enums;

namespace BomBiEn.Queries.Users
{
    public class ListUsersQuery : ListQueryBase
    {
        /// <summary>
        /// User type
        /// </summary>
        public UserType? UserType { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        public string LastName { get; set; }
    }
}