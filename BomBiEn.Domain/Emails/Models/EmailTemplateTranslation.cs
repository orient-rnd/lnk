using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using BomBiEn.Infrastructure.Domain;

namespace BomBiEn.Domain.Emails.Models
{
    [BsonIgnoreExtraElements]
    public class EmailTemplateTranslation : TranslationEntityBase
    {
        public string Name { get; set; }

        public string FromEmailAddress { get; set; }

        public string FromDisplayName { get; set; }

        public string ToEmailAddress { get; set; }

        public string ToDisplayName { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }
    }
}