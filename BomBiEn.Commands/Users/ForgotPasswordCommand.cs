using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BomBiEn.Infrastructure.Commands;

namespace BomBiEn.Commands.Users
{
    public class ForgotPasswordCommand : CommandBase
    {
        public string Email { get; set; }

        public string LanguageCode { get; set; }
    }
}