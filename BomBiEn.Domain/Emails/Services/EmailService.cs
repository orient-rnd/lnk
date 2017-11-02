using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Newtonsoft.Json;
using BomBiEn.Domain.Emails.Models;
using BomBiEn.Infrastructure.MongoDb;
using BomBiEn.Infrastructure.TemplateEngines;
using BomBiEn.Shared.Constants;

namespace BomBiEn.Domain.Emails.Services
{
    public class EmailService : IEmailService
    {
        private readonly IMongoDbWriteRepository _writeRepository;
        //private readonly ITemplateEngine _templateEngine;

        public EmailService(
            IMongoDbWriteRepository writeRepository)
        {
            _writeRepository = writeRepository;
            //_templateEngine = templateEngine;
        }

        public void SendForgotPasswordEmail(ForgotPasswordEmailTemplateModel emailTemplateModel, string emailTemplateCode = null)
        {
            if (String.IsNullOrWhiteSpace(emailTemplateCode))
            {
                emailTemplateCode = EmailTemplateCodes.ForgotPassword;
            }

            SendEmail(emailTemplateCode, emailTemplateModel);
        }

        private void SendEmail<TEmailTemplateModel>(string emailTemplateCode, TEmailTemplateModel emailTemplateModel)
            where TEmailTemplateModel : EmailTemplateModelBase
        {
            EmailTemplate emailTemplate = _writeRepository.Find<EmailTemplate>(Builders<EmailTemplate>.Filter.Where(it => it.Code == emailTemplateCode)).FirstOrDefault();
            Contract.Assert(emailTemplate != null);

            SendEmail(emailTemplate, emailTemplateModel);
        }

        public void SendEmail<TEmailTemplateModel>(EmailTemplate emailTemplate, TEmailTemplateModel emailTemplateModel)
            where TEmailTemplateModel : EmailTemplateModelBase
        {
            EmailTemplateTranslation emailTemplateTranslation = emailTemplate.Translations.GetEnsureTranslation(emailTemplateModel.LanguageCode);
            Contract.Assert(emailTemplateTranslation != null);

            QueuedEmail queuedEmail = new QueuedEmail();

            if (!String.IsNullOrWhiteSpace(emailTemplateModel.FromEmailAddress))
            {
                queuedEmail.FromEmailAddress = emailTemplateModel.FromEmailAddress;
            }
            else
            {
                queuedEmail.FromEmailAddress = emailTemplateTranslation.FromEmailAddress;
            }

            if (!String.IsNullOrWhiteSpace(emailTemplateModel.FromDisplayName))
            {
                queuedEmail.FromDisplayName = emailTemplateModel.FromDisplayName;
            }
            else
            {
                queuedEmail.FromDisplayName = emailTemplateTranslation.FromDisplayName;
            }

            if (!String.IsNullOrWhiteSpace(emailTemplateModel.ToEmailAddress))
            {
                queuedEmail.ToEmailAddress = emailTemplateModel.ToEmailAddress;
            }
            else
            {
                queuedEmail.ToEmailAddress = emailTemplateTranslation.ToEmailAddress;
            }

            if (!String.IsNullOrWhiteSpace(emailTemplateModel.ToDisplayName))
            {
                queuedEmail.ToDisplayName = emailTemplateModel.ToDisplayName;
            }
            else
            {
                queuedEmail.ToDisplayName = emailTemplateTranslation.ToDisplayName;
            }

            queuedEmail.EmailTemplateId = emailTemplate.Id;
            queuedEmail.EmailTemplateName = emailTemplateTranslation.Name;
            queuedEmail.EmailTemplateLanguage = emailTemplateTranslation.LanguageCode;
            queuedEmail.EmailTemplateModel = JsonConvert.SerializeObject(emailTemplateModel, Formatting.None, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

            if (!String.IsNullOrWhiteSpace(emailTemplateTranslation.Subject))
            {
                //queuedEmail.Subject = _templateEngine.Render(emailTemplateTranslation.Subject, emailTemplateModel);
            }

            if (!String.IsNullOrWhiteSpace(emailTemplateTranslation.Body))
            {
                //queuedEmail.Body = _templateEngine.Render(emailTemplateTranslation.Body, emailTemplateModel);
            }

            _writeRepository.Create(queuedEmail);
        }
    }
}