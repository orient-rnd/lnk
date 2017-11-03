using LNK.Infrastructure.Domain;
using MongoDB.Bson.Serialization.Attributes;

namespace LNK.Domain.Sentences.Models
{
    [BsonIgnoreExtraElements]
    public class Speaker : AuditableEntityBase, IAggregateRoot
    {
        public string Name { get; set; }

        public string Country { get; set; }

        public string CountryFlatUrl { get; set; }
    }
}