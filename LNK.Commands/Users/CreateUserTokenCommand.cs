using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LNK.Infrastructure.Commands;

namespace LNK.Commands.Users
{
    public class CreateUserTokenCommand : CommandBase
    {
        public string UserId { get; set; }

        public string Token { get; set; }

        public int NumberOfExpirationDays { get; set; }
    }
}