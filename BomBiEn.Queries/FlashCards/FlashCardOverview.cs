using BomBiEn.Infrastructure.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BomBiEn.Queries.FlashCards
{
    public class FlashCardOverview : AuditableEntityOverviewBase
    {
        public string Id { get; set; }

        public string FaceA { get; set; }

        public string IpasFaceA { get; set; }

        public string FaceB { get; set; }

        public string FlashCardCategoryId { get; set; }

        public string FlashCardCategoryName { get; set; }

        public string UserEmail { get; set; }

        public int DisplayOrder { get; set; }

        public int ViewNumber { get; set; }
    }
}
