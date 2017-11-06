﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LNK.Infrastructure.Domain;
using LNK.Infrastructure.Queries;

namespace LNK.Queries.Emails
{
    public class EmailTemplateOverview : AuditableEntityOverviewBase
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string FromEmailAddress { get; set; }

        public string FromDisplayName { get; set; }

        public string ToEmailAddress { get; set; }

        public string ToDisplayName { get; set; }

        public string Subject { get; set; }

        public string EmailTemplateCategoryId { get; set; }

        public string LanguageCode { get; set; }
    }
}