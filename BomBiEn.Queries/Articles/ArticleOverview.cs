using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BomBiEn.Infrastructure.Queries;

namespace BomBiEn.Queries.Articles
{
    public class ArticleOverview : AuditableEntityOverviewBase
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string CopyFrom { get; set; }

        public string Author { get; set; }

        public string CategoryId { get; set; }
    }
}
