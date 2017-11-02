using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BomBiEn.Domain.Users.Models;

namespace BomBiEn.Commands.Users
{
    public class SignInOrSignUpCommandResult
    {
        public User User { get; set; }

        public string Token { get; set; }
    }
}