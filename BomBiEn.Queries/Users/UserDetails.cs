﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BomBiEn.Shared.Enums;

namespace BomBiEn.Queries.Users
{
    public class UserDetails
    {
        public string Id { get; set; }

        public UserType UserType { get; set; }

        public GenderType Gender { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Country { get; set; }

        public string PreferredLanguage { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Photo { get; set; }

        public string PhoneNumber { get; set; }

        public string AgencyId { get; set; }

        public UserStatus Status { get; set; }

        public IEnumerable<UserDetailsAppToken> AppTokens { get; set; }
    }
}