using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BomBiEn.Infrastructure.Commands;

namespace BomBiEn.Commands.Users
{
    public class CreateUserTokenCommand : CommandBase
    {
        public string UserId { get; set; }

        public string Token { get; set; }

        public int NumberOfExpirationDays { get; set; }
    }
}