using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BomBiEn.Infrastructure.Domain
{
    public class TranslationCollection<T> : List<T> where T : ITranslationEntity
    {
        private const string DefaultLanguageCode = "en-US";

        public virtual T this[string languageCode]
        {
            get
            {
                return GetTranslation(languageCode);
            }
            set
            {
                AddTranslation(languageCode, value);
            }
        }

        public virtual T GetTranslation(string languageCode)
        {
            return this.FirstOrDefault(it => it.LanguageCode == languageCode);
        }

        public virtual T GetEnsureTranslation(string languageCode)
        {
            var translation = this.FirstOrDefault(it => it.LanguageCode == languageCode);
            if (translation == null)
            {
                translation = this.FirstOrDefault(it => it.LanguageCode == DefaultLanguageCode);
            }

            return translation;
        }

        public virtual void AddTranslation(string languageCode, T translation)
        {
            if (translation != null)
            {
                if (translation.LanguageCode != languageCode)
                {
                    throw new ArgumentException($"The translation language code '{translation.LanguageCode}' doesn't match the language code '{languageCode}'.");
                }

                RemoveAll(it => it.LanguageCode == languageCode);
                Add(translation);
            }
        }
    }
}