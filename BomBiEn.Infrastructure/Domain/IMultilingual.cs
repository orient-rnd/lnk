using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BomBiEn.Infrastructure.Domain
{
    public interface IMultilingual<T> where T : ITranslationEntity
    {
        TranslationCollection<T> Translations { get; }
    }
}