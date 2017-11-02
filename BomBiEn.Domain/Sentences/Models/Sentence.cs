using BomBiEn.Infrastructure.Domain;
using BomBiEn.Shared.Enums;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BomBiEn.Domain.Sentences.Models
{
    [BsonIgnoreExtraElements]
    public class Sentence : AuditableEntityBase, IAggregateRoot
    {
        public string Title { get; set; }

        public string EnglishContent { get; set; }

        public string VietnameseContent { get; set; }

        public List<string> LinkAudio { get; set; }

        public string CategoryId { get; set; }

        public string CategoryName { get; set; }

        public List<Dictionary> MainWords { get; set; }

        public List<string> IPAs { get; set; }        

        public SentenceType Type { get; set; }

        public SentenceStatus Status { get; set; }

        // code guid de xac dinh la cung tu, nhung o cac dang nghia khac nhau
        public string SameWord { get; set; }

        // code guid de xac dinh cac tu co nghia tuong tu nhau
        public string RelatedWords { get; set; }

        public WordType WordType { get; set; }

        public List<string> Tags { get; set; }
    }
}