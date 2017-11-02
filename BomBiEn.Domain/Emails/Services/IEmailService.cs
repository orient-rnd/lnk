using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BomBiEn.Domain.Emails.Models;

namespace BomBiEn.Domain.Emails.Services
{
    public interface IEmailService
    {
        void SendForgotPasswordEmail(ForgotPasswordEmailTemplateModel emailTemplateModel, string emailTemplateCode = null);
    }
}