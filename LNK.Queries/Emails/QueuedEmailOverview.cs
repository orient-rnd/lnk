using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LNK.Infrastructure.Queries;

namespace LNK.Queries.Emails
{
    public class QueuedEmailOverview : AuditableEntityOverviewBase
    {
        public string Id { get; set; }

        public string FromEmailAddress { get; set; }

        public string ToEmailAddress { get; set; }

        public string EmailTemplateName { get; set; }

        public string EmailTemplateLanguage { get; set; }

        public string Subject { get; set; }

        public DateTime? TriggerDate { get; set; }

        public DateTime? SentDate { get; set; }

        public int NumberOfFailedAttempts { get; set; }

        public string FailedErrorMessage { get; set; }
    }
}