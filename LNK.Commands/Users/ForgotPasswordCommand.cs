using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LNK.Infrastructure.Commands;

namespace LNK.Commands.Users
{
    public class ForgotPasswordCommand : CommandBase
    {
        public string Email { get; set; }

        public string LanguageCode { get; set; }
    }
}