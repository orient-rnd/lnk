using LNK.Infrastructure.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNK.Queries.FlashCards
{
    public class ListFlashCardCategoriesQuery : ListQueryBase
    {
        public string UserId { get; set; }
    }
}
