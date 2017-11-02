using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BomBiEn.Infrastructure.Domain;

namespace BomBiEn.Queries.Emails
{
    public class EmailTemplateDetails
    {
        public string Id { get; set; }

        public string Name { get; set; }

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