using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BomBiEn.Infrastructure.Domain;
using BomBiEn.Infrastructure.SEO;

namespace BomBiEn.Domain.Articles.Models
{
    public class Article : AuditableEntityBase, IAggregateRoot, SEOBase
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string LinkMedia { get; set; }

        public string CopyFrom { get; set; }

        public string Author { get; set; }

        public string CategoryId { get; set; }
    }
}