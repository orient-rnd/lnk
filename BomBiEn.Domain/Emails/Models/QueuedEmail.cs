using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using BomBiEn.Infrastructure.Domain;

namespace BomBiEn.Domain.Emails.Models
{
    [BsonIgnoreExtraElements]
    public class QueuedEmail : AuditableEntityBase, IAggregateRoot
    {
        public string FromEmailAddress { get; set; }

        public string FromDisplayName { get; set; }

        public string ToEmailAddress { get; set; }

        public string ToDisplayName { get; set; }

        public string EmailTemplateId { get; set; }

        public string EmailTemplateName { get; set; }

        public string EmailTemplateLanguage { get; set; }

        public string EmailTemplateModel { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public DateTime? TriggerDate { get; set; }

        public DateTime? SentDate { get; set; }

        public int NumberOfFailedAttempts { get; set; }

        public string FailedErrorMessage { get; set; }
    }
}