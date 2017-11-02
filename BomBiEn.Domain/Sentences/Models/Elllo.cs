using BomBiEn.Infrastructure.Domain;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace BomBiEn.Domain.Sentences.Models
{
    [BsonIgnoreExtraElements]
    public class Elllo : AuditableEntityBase, IAggregateRoot
    {
        public string Title { get; set; }

        public string EnglishContent { get; set; }

        public string VideoUrl { get; set; }

        public string VideoUrlBackUp { get; set; }

        public string Mp3Url { get; set; }

        public string Mp3UrlBackUp { get; set; }

        public IEnumerable<Speaker> Speakers { get; set; }

        /// <summary>
        /// save the original url from elllo.org
        /// </summary>
        public string OriginUrl { get; set; }
    }
}