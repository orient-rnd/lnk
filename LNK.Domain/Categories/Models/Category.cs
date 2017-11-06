using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LNK.Infrastructure.Domain;

namespace LNK.Domain.Categories.Models
{
    [BsonIgnoreExtraElements]
    public class Category : AuditableEntityBase, IAggregateRoot
    {
        public string NameEn { get; set; }

        public string NameVn { get; set; }

        public string Description { get; set; }

        public string IdCategoryParent { get; set; }

        public int? DisplayOrder { get; set; }

        public int? Level { get; set; }
    }
}