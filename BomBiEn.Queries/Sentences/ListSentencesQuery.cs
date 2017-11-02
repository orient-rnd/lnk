using BomBiEn.Infrastructure.Queries;
using BomBiEn.Shared.Enums;
using System.Collections.Generic;

namespace BomBiEn.Queries.Sentences
{
    public class ListSentencesQuery : ListQueryBase
    {
        public SentenceStatus? Status { get; set; }

        public SentenceType? Type { get; set; }

        public string Category { get; set; }

        public string Title { get; set; }

        public string MainWords { get; set; }

        public string ContentWord { get; set; }

        public List<string> Tags { get; set; } = new List<string>();
    }
}
