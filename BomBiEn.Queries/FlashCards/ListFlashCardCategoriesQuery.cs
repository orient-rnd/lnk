using BomBiEn.Infrastructure.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BomBiEn.Queries.FlashCards
{
    public class ListFlashCardCategoriesQuery : ListQueryBase
    {
        public string UserId { get; set; }
    }
}
