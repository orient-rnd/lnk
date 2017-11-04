using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNK.Infrastructure.Domain
{
    public abstract class TranslationEntityBase : ITranslationEntity
    {
        public string LanguageCode { get; set; }
    }
}