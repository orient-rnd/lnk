using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using BomBiEn.Infrastructure.Domain;
using BomBiEn.Infrastructure.Identity.MongoDb;

namespace BomBiEn.Domain.Users.Models
{
    [BsonIgnoreExtraElements]
    public class Role : IdentityRole<string>, IAggregateRoot
    {
        /// <summary>
        /// Permissions
        /// </summary>
        public IEnumerable<string> Permissions { get; set; }
    }
}