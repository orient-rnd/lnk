using BomBiEn.Infrastructure.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BomBiEn.Queries.FlashCards
{
    public class GetFlashCardDetailsQuery : QueryBase
    {
        public string Id { get; set; }

        public string FaceA { get; set; }

        public string FaceB { get; set; }

        public string FlashCardCategoryId { get; set; }

        public string FlashCardCategoryName { get; set; }

        public int DisplayOrder { get; set; }
    }
}
