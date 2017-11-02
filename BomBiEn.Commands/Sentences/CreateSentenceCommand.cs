using BomBiEn.Infrastructure.Commands;
using BomBiEn.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BomBiEn.Commands.Sentences
{
    public class CreateSentenceCommand : AuditableCreateCommandBase
    {
        public string Title { get; set; }

        public string EnglishContent { get; set; }

        public string VietnameseContent { get; set; }

        public List<string> LinkAudio { get; set; }

        public List<string> IPAs { get; set; }
        
        public string CategoryId { get; set; }

        public string CategoryName { get; set; }

        public List<DictionaryCommand> MainWords { get; set; }

        public SentenceType Type { get; set; }

        public SentenceStatus Status { get; set; }

        public string SameWord { get; set; }

        public string RelatedWords { get; set; }

        public WordType WordType { get; set; }

        public string MainWordsTemp { get; set; }

        public string LinkAudioTemp { get; set; }

        public List<string> Tags { get; set; }

        public string StringTags { get; set; }
    }
}
