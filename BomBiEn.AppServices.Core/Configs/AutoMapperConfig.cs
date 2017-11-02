using System;
using AutoMapper;
using BomBiEn.AppServices.Core.Services;
using BomBiEn.Infrastructure.Queries;

namespace BomBiEn.AppServices.Core.Configs
{
    public static class AutoMapperConfig
    {
        public static void Configure(Action<IMapperConfigurationExpression, IAssetUrlResolver, IQueryBus> setupAction, IAssetUrlResolver assetUrlResolver, IQueryBus queryBus)
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile<CommandHandlers.Users.UsersAutoMapperConfig>();
                config.AddProfile<QueryHandlers.Users.UsersAutoMapperConfig>();
                config.AddProfile<CommandHandlers.Emails.EmailsAutoMapperConfig>();
                config.AddProfile<QueryHandlers.Emails.EmailsAutoMapperConfig>();
                config.AddProfile<QueryHandlers.Agencies.AgenciesAutoMapperConfig>();
                config.AddProfile<CommandHandlers.Agencies.AgenciesAutoMapperConfig>();
                config.AddProfile<QueryHandlers.Categories.CategoriesAutoMapperConfig>();
                config.AddProfile<CommandHandlers.Categories.CategoriesAutoMapperConfig>();
                config.AddProfile<QueryHandlers.Articles.ArticlesAutoMapperConfig>();
                config.AddProfile<CommandHandlers.Articles.ArticlesAutoMapperConfig>();
                config.AddProfile<QueryHandlers.Sentences.SentencesAutoMapperConfig>();
                config.AddProfile<CommandHandlers.Sentences.SentencesAutoMapperConfig>();
                config.AddProfile<QueryHandlers.FlashCards.FlashCardsAutoMapperConfig>();
                config.AddProfile<CommandHandlers.FlashCards.FlashCardsAutoMapperConfig>();

                if (setupAction != null)
                {
                    setupAction(config, assetUrlResolver, queryBus);
                }
            });
        }
    }
}