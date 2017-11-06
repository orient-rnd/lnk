using LNK.Infrastructure.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNK.Queries.FlashCards
{
    public class ListFlashCardsQuery : ListQueryBase
    {
        public string CategoryId { get; set; }

        public string UserId { get; set; }

        public bool? NotSupportYet { get; set; }
    }
}