using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LNK.Domain.Emails.Models;

namespace LNK.Domain.Emails.Services
{
    public interface IEmailService
    {
        void SendForgotPasswordEmail(ForgotPasswordEmailTemplateModel emailTemplateModel, string emailTemplateCode = null);
    }
}