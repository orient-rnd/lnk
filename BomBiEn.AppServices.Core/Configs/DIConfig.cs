using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using BomBiEn.AppServices.Core.Services;
using BomBiEn.CommandHandlers.Agencies;
using BomBiEn.CommandHandlers.Emails;
using BomBiEn.CommandHandlers.Users;
using BomBiEn.Commands.Agencies;
using BomBiEn.Commands.Emails;
using BomBiEn.Commands.Users;
using BomBiEn.Domain.Emails.Services;
using BomBiEn.Domain.Users.Models;
using BomBiEn.Domain.Users.Services;
using BomBiEn.Infrastructure.Commands;
using BomBiEn.Infrastructure.Connectors;
using BomBiEn.Infrastructure.Events;
using BomBiEn.Infrastructure.Identity.MongoDb;
using BomBiEn.Infrastructure.MongoDb;
using BomBiEn.Infrastructure.Queries;
using BomBiEn.Infrastructure.TemplateEngines;
using BomBiEn.Queries.Agencies;
using BomBiEn.Queries.Emails;
using BomBiEn.Queries.Users;
using BomBiEn.QueryHandlers.Agencies;
using BomBiEn.QueryHandlers.Emails;
using BomBiEn.QueryHandlers.Package;
using BomBiEn.QueryHandlers.Users;
using BomBiEn.Shared.Configs;
using BomBiEn.CommandHandlers.Categories;
using BomBiEn.Commands.Categories;
using BomBiEn.Queries.Categories;
using BomBiEn.CommandHandlers.Articles;
using BomBiEn.QueryHandlers.Articles;
using BomBiEn.Commands.Articles;
using BomBiEn.Queries.Articles;
using BomBiEn.CommandHandlers.Sentences;
using BomBiEn.Commands.Sentences;
using BomBiEn.Queries.Sentences;
using BomBiEn.QueryHandlers.Sentences;
using BomBiEn.QueryHandlers.FlashCards;
using BomBiEn.Queries.FlashCards;

namespace BomBiEn.AppServices.Core.Configs
{
    public static class DIConfig
    {
        public static IServiceProvider ConfigureServices(IServiceCollection services, IConfigurationRoot configuration, Action<ContainerBuilder> diSetupAction = null, Action<IMapperConfigurationExpression, IAssetUrlResolver, IQueryBus> autoMapperSetupAction = null)
        {
            services.Configure<MongoDbConfig>(configuration.GetSection("MongoDb"));
            services.Configure<DashboardConfig>(configuration.GetSection("Dashboard"));

            services.AddIdentity<User, Role>(
                identityOptions =>
                {
                    identityOptions.User.RequireUniqueEmail = true;
                })
                .AddDefaultTokenProviders();

            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(services);

            //containerBuilder.RegisterType<WorkContextProvider>().As<IWorkContextProvider>();

            ConfigureMongoDbServices(containerBuilder);
            ConfigureIdentityServices(containerBuilder);
            ConfigureMediaServices(containerBuilder);
            ConfigureCommandsServices(containerBuilder);
            ConfigureQueriesServices(containerBuilder);
            ConfigureEventsServices(containerBuilder);
            ConfigureUsersServices(containerBuilder);
            ConfigureEmailsServices(containerBuilder);
            ConfigureRestConnectorServices(containerBuilder);
            ConfigureAgenciesServices(containerBuilder);
            CategoriesAutoMapperConfig(containerBuilder);
            ArticlesAutoMapperConfig(containerBuilder);
            SentencesAutoMapperConfig(containerBuilder);
            FlashCardsAutoMapperConfig(containerBuilder);

            if (diSetupAction != null)
            {
                diSetupAction(containerBuilder);
            }

            var container = containerBuilder.Build();

            var assetUrlResolver = container.Resolve<IAssetUrlResolver>();
            var queryBus = container.Resolve<IQueryBus>();
            AutoMapperConfig.Configure(autoMapperSetupAction, assetUrlResolver, queryBus);

            // Build() or Update() method can only be called once on a ContainerBuilder.
            containerBuilder = new ContainerBuilder();
            ConfigureAutoMapperServices(containerBuilder);
            containerBuilder.Update(container);

            var provider = new AutofacServiceProvider(container);
            return provider;
        }

        private static void ConfigureMongoDbServices(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<MongoDbReadRepository>()
                .WithParameters(new[]
                {
                    new ResolvedParameter(
                        (p, c) => p.Name == "mongoDbConnectionString",
                        (p, c) => c.Resolve<IOptions<MongoDbConfig>>().Value.DefaultReadConnectionString)
                })
                .As<IMongoDbReadRepository>();

            containerBuilder.RegisterType<MongoDbWriteRepository>()
                .WithParameters(new[]
                {
                    new ResolvedParameter(
                        (p, c) => p.Name == "mongoDbConnectionString",
                        (p, c) => c.Resolve<IOptions<MongoDbConfig>>().Value.DefaultWriteConnectionString)
                })
                .As<IMongoDbWriteRepository>();

            containerBuilder.RegisterType<MongoDbLogsRepository>()
                .WithParameters(new[]
                {
                    new ResolvedParameter(
                        (p, c) => p.Name == "mongoDbConnectionString",
                        (p, c) => c.Resolve<IOptions<MongoDbConfig>>().Value.DefaultLogsConnectionString)
                })
                .As<IMongoDbLogsRepository>();
        }

        private static void ConfigureMediaServices(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<AssetUrlResolver>().As<IAssetUrlResolver>();
        }

        private static void ConfigureIdentityServices(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<UserStore<User, Role>>()
                .WithParameters(new[]
                {
                    new ResolvedParameter(
                        (p, c) => p.Name == "users",
                        (p, c) => c.Resolve<IMongoDbWriteRepository>().GetCollection<User>()),
                    new ResolvedParameter(
                        (p, c) => p.Name == "roles",
                        (p, c) => c.Resolve<IMongoDbWriteRepository>().GetCollection<Role>())
                })
                .As<IUserStore<User>>();

            containerBuilder.RegisterType<RoleStore<Role>>()
                .WithParameters(new[]
                {
                    new ResolvedParameter(
                        (p, c) => p.Name == "roles",
                        (p, c) => c.Resolve<IMongoDbWriteRepository>().GetCollection<Role>())
                })
                .As<IRoleStore<Role>>();
        }

        private static void ConfigureCommandsServices(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<InProcessCommandBus>().As<ICommandBus>();
        }

        private static void ConfigureQueriesServices(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<InProcessQueryBus>().As<IQueryBus>();
        }

        private static void ConfigureEventsServices(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<EventSerializer>().As<IEventSerializer>();
            containerBuilder.RegisterType<InProcessEventBus>().As<IEventBus>();
        }

        private static void ConfigureAutoMapperServices(ContainerBuilder containerBuilder)
        {
            IMapper mapper = Mapper.Instance;
            containerBuilder.RegisterInstance(mapper).As<IMapper>().SingleInstance();
        }

        private static void ConfigureRestConnectorServices(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<RestConnector>().As<IRestConnector>();
        }

        private static void ConfigureUsersServices(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<UserService>().As<IUserService>();

            containerBuilder.RegisterType<UserCommandHandler>().As<ICommandHandler<SignUpCommand>>();
            containerBuilder.RegisterType<UserCommandHandler>().As<ICommandHandler<SignInCommand>>();
            containerBuilder.RegisterType<UserCommandHandler>().As<ICommandHandler<CreateUserCommand>>();
            containerBuilder.RegisterType<UserCommandHandler>().As<ICommandHandler<UpdateUserCommand>>();
            containerBuilder.RegisterType<UserCommandHandler>().As<ICommandHandler<DeleteUserCommand>>();
            containerBuilder.RegisterType<UserCommandHandler>().As<ICommandHandler<CreateUserTokenCommand>>();

            containerBuilder.RegisterType<RoleCommandHandler>().As<ICommandHandler<CreateRoleCommand>>();
            containerBuilder.RegisterType<RoleCommandHandler>().As<ICommandHandler<UpdateRoleCommand>>();
            containerBuilder.RegisterType<RoleCommandHandler>().As<ICommandHandler<DeleteRoleCommand>>();

            containerBuilder.RegisterType<UserQueryHandler>().As<IQueryHandler<ListUsersQuery, PagedQueryResult<UserOverview>>>();
            containerBuilder.RegisterType<UserQueryHandler>().As<IQueryHandler<GetUserDetailsQuery, UserDetails>>();
            containerBuilder.RegisterType<UserQueryHandler>().As<IQueryHandler<ListUserEmailsQuery, PagedQueryResult<UserEmailOverview>>>();
            containerBuilder.RegisterType<UserQueryHandler>().As<IQueryHandler<GetAllUsersQuery, IEnumerable<UserOverview>>>();
            containerBuilder.RegisterType<UserQueryHandler>().As<IQueryHandler<ImpersonationQuery, ImpersonationQueryResult>>();

            containerBuilder.RegisterType<RoleQueryHandler>().As<IQueryHandler<ListRolesQuery, PagedQueryResult<RoleOverview>>>();
            containerBuilder.RegisterType<RoleQueryHandler>().As<IQueryHandler<GetRoleDetailsQuery, RoleDetails>>();
        }

        private static void ConfigureEmailsServices(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<EmailService>().As<IEmailService>();

            // Email templates
            containerBuilder.RegisterType<EmailTemplateCommandHandler>().As<ICommandHandler<CreateEmailTemplateCommand>>();
            containerBuilder.RegisterType<EmailTemplateCommandHandler>().As<ICommandHandler<UpdateEmailTemplateCommand>>();
            containerBuilder.RegisterType<EmailTemplateCommandHandler>().As<ICommandHandler<DeleteEmailTemplateCommand>>();

            containerBuilder.RegisterType<EmailTemplateQueryHandler>().As<IQueryHandler<ListEmailTemplatesQuery, PagedQueryResult<EmailTemplateOverview>>>();
            containerBuilder.RegisterType<EmailTemplateQueryHandler>().As<IQueryHandler<GetEmailTemplateDetailsQuery, EmailTemplateDetails>>();

            // Email template categories
            containerBuilder.RegisterType<EmailTemplateCategoryQueryHandler>().As<IQueryHandler<GetAllEmailTemplateCategoriesQuery, IEnumerable<EmailTemplateCategoryOverview>>>();
            containerBuilder.RegisterType<EmailTemplateCategoryQueryHandler>().As<IQueryHandler<ListEmailTemplateCategoriesQuery, PagedQueryResult<EmailTemplateCategoryOverview>>>();
            containerBuilder.RegisterType<EmailTemplateCategoryQueryHandler>().As<IQueryHandler<GetEmailTemplateCategoryDetailsQuery, EmailTemplateCategoryDetails>>();

            containerBuilder.RegisterType<EmailTemplateCategoryCommandHandler>().As<ICommandHandler<CreateEmailTemplateCategoryCommand>>();
            containerBuilder.RegisterType<EmailTemplateCategoryCommandHandler>().As<ICommandHandler<UpdateEmailTemplateCategoryCommand>>();
            containerBuilder.RegisterType<EmailTemplateCategoryCommandHandler>().As<ICommandHandler<DeleteEmailTemplateCategoryCommand>>();

            // Emails
            containerBuilder.RegisterType<QueuedEmailQueryHandler>().As<IQueryHandler<ListQueuedEmailsQuery, PagedQueryResult<QueuedEmailOverview>>>();
            containerBuilder.RegisterType<QueuedEmailQueryHandler>().As<IQueryHandler<GetQueuedEmailDetailsQuery, QueuedEmailDetails>>();
        }

        private static void ConfigureAgenciesServices(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<AgencyQueryHandler>().As<IQueryHandler<ListAgenciesQuery, PagedQueryResult<AgencyOverview>>>();
            containerBuilder.RegisterType<AgencyQueryHandler>().As<IQueryHandler<GetAllAgenciesQuery, IEnumerable<AgencyOverview>>>();
            containerBuilder.RegisterType<AgencyQueryHandler>().As<IQueryHandler<GetAgencyDetailsQuery, AgencyDetails>>();

            containerBuilder.RegisterType<AgencyCommandHandler>().As<ICommandHandler<CreateAgencyCommand>>();
            containerBuilder.RegisterType<AgencyCommandHandler>().As<ICommandHandler<UpdateAgencyCommand>>();
            containerBuilder.RegisterType<AgencyCommandHandler>().As<ICommandHandler<DeleteAgencyCommand>>();
        }

        private static void CategoriesAutoMapperConfig(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<CategoryCommandHandler>().As<ICommandHandler<CreateCategoryCommand>>();
            containerBuilder.RegisterType<CategoryCommandHandler>().As<ICommandHandler<UpdateCategoryCommand>>();
            containerBuilder.RegisterType<CategoryCommandHandler>().As<ICommandHandler<DeleteCategoryCommand>>();

            containerBuilder.RegisterType<CategoryQueryHandler>().As<IQueryHandler<ListCategoriesQuery, PagedQueryResult<CategoryOverview>>>();
            containerBuilder.RegisterType<CategoryQueryHandler>().As<IQueryHandler<GetCategoryDetailsQuery, CategoryDetails>>();
            containerBuilder.RegisterType<CategoryQueryHandler>().As<IQueryHandler<GetAllCategoriesQuery, IEnumerable<CategoryOverview>>>();
        }

        private static void ArticlesAutoMapperConfig(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<ArticleCommandHandler>().As<ICommandHandler<CreateArticleCommand>>();
            containerBuilder.RegisterType<ArticleCommandHandler>().As<ICommandHandler<UpdateArticleCommand>>();
            containerBuilder.RegisterType<ArticleCommandHandler>().As<ICommandHandler<DeleteArticleCommand>>();

            containerBuilder.RegisterType<ArticleQueryHandler>().As<IQueryHandler<ListArticlesQuery, PagedQueryResult<ArticleOverview>>>();
            containerBuilder.RegisterType<ArticleQueryHandler>().As<IQueryHandler<GetArticleDetailsQuery, ArticleDetails>>();
            containerBuilder.RegisterType<ArticleQueryHandler>().As<IQueryHandler<GetAllArticlesQuery, IEnumerable<ArticleOverview>>>();
        }

        private static void SentencesAutoMapperConfig(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<SentencesCommandHandler>().As<ICommandHandler<CreateSentenceCommand>>();
            containerBuilder.RegisterType<SentencesCommandHandler>().As<ICommandHandler<UpdateSentenceCommand>>();
            containerBuilder.RegisterType<SentencesCommandHandler>().As<ICommandHandler<DeleteSentenceCommand>>();

            containerBuilder.RegisterType<SentencesQueryHandler>().As<IQueryHandler<ListSentencesQuery, PagedQueryResult<SentenceOverview>>>();
            containerBuilder.RegisterType<SentencesQueryHandler>().As<IQueryHandler<GetSentenceDetailsQuery, SentenceDetails>>();
            containerBuilder.RegisterType<SentencesQueryHandler>().As<IQueryHandler<GetAllSentencesQuery, IEnumerable<SentenceOverview>>>();
            containerBuilder.RegisterType<SentencesQueryHandler>().As<IQueryHandler<GetListSentencesBasicQuery, IEnumerable<SentenceBasic>>>();
            containerBuilder.RegisterType<SentencesQueryHandler>().As<IQueryHandler<ListTagsQuery, IEnumerable<string>>>();
            containerBuilder.RegisterType<SentencesQueryHandler>().As<IQueryHandler<ListSentencesPronounceQuery, IEnumerable<SentencePronounceOverview>>>();
        }

        private static void FlashCardsAutoMapperConfig(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<FlashCardCategoryQueryHandler>().As<IQueryHandler<ListFlashCategoriesQuery, PagedQueryResult<FlashcardCategoryOverview>>>();
        }
    }
}