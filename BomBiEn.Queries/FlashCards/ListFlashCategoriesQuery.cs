using BomBiEn.Infrastructure.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace BomBiEn.Queries.FlashCards
{
    public class ListFlashCategoriesQuery: ListQueryBase
    {
        public string UserEmail { get; set; }
    }
}
