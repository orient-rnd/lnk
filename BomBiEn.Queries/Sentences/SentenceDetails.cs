using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BomBiEn.Shared.Enums;

namespace BomBiEn.Queries.Sentences
{
    public class SentenceDetails
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string EnglishContent { get; set; }

        public string VietnameseContent { get; set; }

        public List<string> LinkAudio { get; set; }

        public List<string> IPAs { get; set; }

        public List<string> RelatedWords { get; set; }

        public string CategoryId { get; set; }

        public string CategoryName { get; set; }

        public List<DictionaryQuery> MainWords { get; set; }

        public SentenceStatus Status { get; set; }

        public SentenceType Type { get; set; }

        public string SameWord { get; set; }

        public WordType WordType { get; set; }

        public string MainWordsTemp { get; set; }

        public string LinkAudioTemp { get; set; }

        public List<string> Tags { get; set; }
    }
}
