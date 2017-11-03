﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LNK.Infrastructure.Commands;
using LNK.Shared.Enums;

namespace LNK.Commands.Users
{
    public class UpdateUserCommand : AuditableUpdateCommandBase
    {
        public string Id { get; set; }

        public UserType UserType { get; set; }

        public GenderType Gender { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        [MinLength(8, ErrorMessage = "Password requires minimum 8 characters")]
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Country { get; set; }

        public string PreferredLanguage { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Photo { get; set; }

        public string PhoneNumber { get; set; }

        public string AgencyId { get; set; }

        public UserStatus Status { get; set; }
    }
}