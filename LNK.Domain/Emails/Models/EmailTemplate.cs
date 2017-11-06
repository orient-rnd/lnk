using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using LNK.Infrastructure.Domain;

namespace LNK.Domain.Emails.Models
{
    [BsonIgnoreExtraElements]
    public class EmailTemplate : AuditableEntityBase, IAggregateRoot, IMultilingual<EmailTemplateTranslation>
    {
        public EmailTemplate()
        {
            Translations = new TranslationCollection<EmailTemplateTranslation>();
        }

        public string Code { get; set; }

        public string EmailTemplateCategoryId { get; set; }

        public TranslationCollection<EmailTemplateTranslation> Translations { get; set; }
    }
}