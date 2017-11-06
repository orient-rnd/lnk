using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LNK.Domain.Users.Models;

namespace LNK.Commands.Users
{
    public class SignInOrSignUpCommandResult
    {
        public User User { get; set; }

        public string Token { get; set; }
    }
}