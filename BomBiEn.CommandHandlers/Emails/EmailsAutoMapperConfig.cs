using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BomBiEn.Commands.Emails;
using BomBiEn.Domain.Emails.Models;

namespace BomBiEn.CommandHandlers.Emails
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