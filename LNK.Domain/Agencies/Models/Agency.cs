using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using LNK.Infrastructure.Domain;

namespace LNK.Domain.Agencies.Models
{
    [BsonIgnoreExtraElements]
    public class Agency : AuditableEntityBase, IAggregateRoot
    {
        public string Name { get; set; }

        public string Description { get; set; }        

        public string LogoUrl { get; set; }
    }
}