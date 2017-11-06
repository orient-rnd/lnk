using BomBiEn.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BomBiEn.Queries.FlashCards
{
    public class FlashCardCategoryOverview : AuditableEntityBase, IAggregateRoot
    {
        public string Name { get; set; }

        public string UserId { get; set; }

        public string UserEmail { get; set; }

        public bool IsFaceAShowFirst { get; set; }

        public bool IsRandom { get; set; }

        public int DisplayOrder { get; set; }
    }
}
