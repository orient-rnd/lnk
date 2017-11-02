using BomBiEn.Infrastructure.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BomBiEn.Queries.FlashCards
{
    public class GetFlashCardCategoryDetailsQuery : QueryBase
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string UserId { get; set; }

        public bool IsFaceAShowFirst { get; set; }

        public bool IsRandom { get; set; }

        public int DisplayOrder { get; set; }
    }
}
