using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BomBiEn.Infrastructure.Domain
{
    public interface ITranslationEntity
    {
        string LanguageCode { get; set; }
    }
}