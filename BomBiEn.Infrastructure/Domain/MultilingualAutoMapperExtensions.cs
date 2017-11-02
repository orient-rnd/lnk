using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace BomBiEn.Infrastructure.Domain
{
    public static class MultilingualAutoMapperExtensions
    {
        /// <summary>
        /// Gets the language code that is set by the <see cref="IMappingOperationOptions"/> options.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public static string GetLanguage(this ResolutionContext context)
        {
            return context.Items["Language"] as string;
        }

        /// <summary>
        /// Sets a language code to the <see cref="IMappingOperationOptions"/> options, this language code will be used to get the right translation entity back.
        /// </summary>
        /// <param name="opts">The opts.</param>
        /// <param name="languageCode">The language code.</param>
        /// <returns></returns>
        public static IMappingOperationOptions SetLanguage(this IMappingOperationOptions opts, string languageCode)
        {
            if (opts != null)
            {
                opts.Items["Language"] = languageCode;
            }

            return opts;
        }

        /// <summary>
        /// Creates the multilingual map.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TDestination">The type of the destination.</typeparam>
        /// <typeparam name="TTranlationEntity">The type of the tranlation entity.</typeparam>
        /// <param name="profile">The profile.</param>
        /// <returns></returns>
        public static IMappingExpression<TSource, TDestination> CreateMultilingualMap<TSource, TDestination, TTranlationEntity>(this Profile profile)
            where TSource : IMultilingual<TTranlationEntity>
            where TTranlationEntity : ITranslationEntity
        {
            return profile.CreateMap<TSource, TDestination>()
                .AfterCreateMultilingualMapCreateTranslationEntityMap<TSource, TDestination, TTranlationEntity>();
        }

        /// <summary>
        /// Creates the translation entity map.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TDestination">The type of the destination.</typeparam>
        /// <typeparam name="TTranlationEntity">The type of the tranlation entity.</typeparam>
        /// <param name="exp">The exp.</param>
        /// <returns></returns>
        public static IMappingExpression<TSource, TDestination> AfterCreateMultilingualMapCreateTranslationEntityMap<TSource, TDestination, TTranlationEntity>(this IMappingExpression<TSource, TDestination> exp)
            where TSource : IMultilingual<TTranlationEntity>
            where TTranlationEntity : ITranslationEntity
        {
            exp.AfterMap((src, dest, context) =>
            {
                string languageCode = context.GetLanguage();

                if (src.Translations != null)
                {
                    TTranlationEntity tranlationEntity = src.Translations.GetEnsureTranslation(languageCode);
                    Mapper.Map(tranlationEntity, dest);                    
                }
            });

            return exp;
        }

        /// <summary>
        /// Maps the source to the <see cref="TDesctionation"/> object that is a translation entity for the specific language.
        /// </summary>
        /// <typeparam name="TDesctionation">The type of the desctionation.</typeparam>
        /// <param name="mapper">The mapper.</param>
        /// <param name="source">The source.</param>
        /// <param name="languageCode">The language code.</param>
        /// <returns></returns>
        public static TDesctionation MapToTranslationEntity<TDesctionation>(this IMapper mapper, object source, string languageCode)
        {
            return mapper.Map<TDesctionation>(source, opts => opts.SetLanguage(languageCode));
        }
    }
}