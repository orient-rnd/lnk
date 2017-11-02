using BomBiEn.Infrastructure.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace BomBiEn.Queries.Sentences
{
    public class ListSentencesPronounceQuery : QueryBase
    {
        public string Word { get; set; }
    }
}
