using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BomBiEn.Infrastructure.Commands;

namespace BomBiEn.Commands.Users
{
    public class SignInCommand : CommandBase<SignInOrSignUpCommandResult>
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}