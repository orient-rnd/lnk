using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LNK.Commands.Emails;
using LNK.Domain.Emails.Models;

namespace LNK.CommandHandlers.Emails
{
    public class EmailsAutoMapperConfig : Profile
    {
        public EmailsAutoMapperConfig()
        {
            // Email templates
            CreateMap<CreateEmailTemplateCommand, EmailTemplate>();
            CreateMap<UpdateEmailTemplateCommand, EmailTemplate>();
            CreateMap<CreateEmailTemplateCommand, EmailTemplateTranslation>();
            CreateMap<UpdateEmailTemplateCommand, EmailTemplateTranslation>();

            // Email template categories
            CreateMap<CreateEmailTemplateCategoryCommand, EmailTemplateCategory>();
            CreateMap<UpdateEmailTemplateCategoryCommand, EmailTemplateCategory>();
        }
    }
}