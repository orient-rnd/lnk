using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LNK.Commands.Emails;
using LNK.Domain.Emails.Models;
using LNK.Infrastructure.Domain;
using LNK.Queries.Emails;

namespace LNK.QueryHandlers.Emails
{
    public class EmailsAutoMapperConfig : Profile
    {
        public EmailsAutoMapperConfig()
        {
            // Email templates
            this.CreateMultilingualMap<EmailTemplate, EmailTemplateOverview, EmailTemplateTranslation>();
            CreateMap<EmailTemplateTranslation, EmailTemplateOverview>();

            this.CreateMultilingualMap<EmailTemplate, EmailTemplateDetails, EmailTemplateTranslation>();
            CreateMap<EmailTemplateTranslation, EmailTemplateDetails>();

            CreateMap<EmailTemplateDetails, UpdateEmailTemplateCommand>();

            // Email template categories
            CreateMap<EmailTemplateCategory, EmailTemplateCategoryOverview>();
            CreateMap<EmailTemplateCategory, EmailTemplateCategoryDetails>();

            CreateMap<EmailTemplateCategoryDetails, UpdateEmailTemplateCategoryCommand>();

            // Queued emails
            CreateMap<QueuedEmail, QueuedEmailOverview>();
            CreateMap<QueuedEmail, QueuedEmailDetails>();
        }
    }
}