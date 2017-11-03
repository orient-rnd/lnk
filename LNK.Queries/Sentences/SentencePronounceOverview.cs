using LNK.Infrastructure.Queries;
using System.Collections.Generic;

namespace LNK.Queries.Sentences
{
    public class SentencePronounceOverview : AuditableEntityOverviewBase
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string EnglishContent { get; set; }

        public string VietnameseContent { get; set; }

        public string IPAs { get; set; }

        public List<string> Tags { get; set; } = new List<string>();

        public string Position { get; set; }

        public string LinkListen { get; set; }
    }
}
