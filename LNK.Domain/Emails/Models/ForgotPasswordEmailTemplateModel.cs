using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNK.Domain.Emails.Models
{
    public class ForgotPasswordEmailTemplateModel : EmailTemplateModelBase
    {
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public string Token { get; set; }
    }
}