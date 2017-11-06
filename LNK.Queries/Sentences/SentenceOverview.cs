using LNK.Infrastructure.Queries;
using LNK.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNK.Queries.Sentences
{
    public class SentenceOverview : AuditableEntityOverviewBase
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string EnglishContent { get; set; }

        public string VietnameseContent { get; set; }

        public List<string> LinkAudio { get; set; }

        public string CategoryId { get; set; }

        public string CategoryName { get; set; }

        public List<DictionaryQuery> MainWords { get; set; }

        public SentenceType Type { get; set; }

        public SentenceStatus Status { get; set; }

        public string SameWord { get; set; }

        public List<string> Tags { get; set; }

        public string StringTags { get; set; }
    }
}
