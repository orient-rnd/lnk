using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
using LNK.Infrastructure.Commands;

namespace LNK.Commands.Emails
{
    public abstract class CreateOrUpdateEmailTemplateCommand : CommandBase
    {
        public string Id { get; set; }

        public string Name { get; set; }

        //[Remote("IsCodeAvailable", "EmailTemplates", ErrorMessage = "The code is aleady exists", AdditionalFields = "Id")]
        public string Code { get; set; }

        public string FromEmailAddress { get; set; }

        public string FromDisplayName { get; set; }

        public string ToEmailAddress { get; set; }

        public string ToDisplayName { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public string EmailTemplateCategoryId { get; set; }

        public string LanguageCode { get; set; }
    }
}