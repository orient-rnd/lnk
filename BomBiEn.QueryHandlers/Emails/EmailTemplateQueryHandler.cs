using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Driver;
using BomBiEn.Domain.Emails.Models;
using BomBiEn.Infrastructure.Domain;
using BomBiEn.Infrastructure.MongoDb;
using BomBiEn.Infrastructure.Queries;
using BomBiEn.Queries.Emails;

namespace BomBiEn.QueryHandlers.Emails
{
    public class EmailTemplateQueryHandler :
        IQueryHandler<ListEmailTemplatesQuery, PagedQueryResult<EmailTemplateOverview>>,
        IQueryHandler<GetEmailTemplateDetailsQuery, EmailTemplateDetails>
    {
        private readonly IMapper _mapper;
        private readonly IMongoDbReadRepository _readRepository;

        public EmailTemplateQueryHandler(
            IMapper mapper,
            IMongoDbReadRepository readRepository)
        {
            _mapper = mapper;
            _readRepository = readRepository;
        }

        public PagedQueryResult<EmailTemplateOverview> Handle(ListEmailTemplatesQuery query)
        {
            var builder = Builders<EmailTemplate>.Filter;
            var filter = builder.Empty;

            if (query.EmailTemplateCategoryIds != null && query.EmailTemplateCategoryIds.Any())
            {
                filter = builder.Where(it => query.EmailTemplateCategoryIds.Contains(it.EmailTemplateCategoryId));
            }

            if (!String.IsNullOrWhiteSpace(query.Name))
            {
                filter = filter & builder.Where(it => it.Translations.Any(t => t.Name.ToLower().Contains(query.Name.ToLower())));
            }

            if (!String.IsNullOrWhiteSpace(query.Code))
            {
                filter = filter & builder.Where(it => it.Code.ToLower().Contains(query.Code.ToLower()));
            }

            var emailTemplates = _readRepository.Find(filter);
            var totalItemCount = emailTemplates.Count();

            var emailTemplateOverviews = _mapper.MapToTranslationEntity<IEnumerable<EmailTemplateOverview>>(emailTemplates
                .SortByDescending(it => it.CreatedDate)
                .Skip((query.Page - 1) * query.PageSize)
                .Limit(query.PageSize)
                .ToList(), query.LanguageCode);
            var pagedResult = new PagedQueryResult<EmailTemplateOverview>(emailTemplateOverviews, totalItemCount, query.Page, query.PageSize);
            return pagedResult;
        }

        public EmailTemplateDetails Handle(GetEmailTemplateDetailsQuery query)
        {
            var builder = Builders<EmailTemplate>.Filter;
            var filter = builder.Empty;

            if (!String.IsNullOrEmpty(query.Id))
            {
                filter = filter & builder.Eq(it => it.Id, query.Id);
            }

            if (!String.IsNullOrEmpty(query.Code))
            {
                filter = filter & builder.Eq(it => it.Code, query.Code);
            }

            if (filter == builder.Empty)
            {
                return null;
            }

            var emailTemplate = _readRepository.Find(filter).FirstOrDefault();
            var emailTemplateDetails = _mapper.MapToTranslationEntity<EmailTemplateDetails>(emailTemplate, query.LanguageCode);
            return emailTemplateDetails;
        }
    }
}