﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using BomBiEn.Infrastructure.Domain;

namespace BomBiEn.Domain.Emails.Models
{
    [BsonIgnoreExtraElements]
    public class EmailTemplateCategory : AuditableEntityBase, IAggregateRoot
    {
        public string Name { get; set; }

        public string Code { get; set; }
    }
}