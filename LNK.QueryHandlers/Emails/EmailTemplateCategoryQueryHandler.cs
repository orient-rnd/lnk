using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Driver;
using LNK.Domain.Emails.Models;
using LNK.Infrastructure.MongoDb;
using LNK.Infrastructure.Queries;
using LNK.Queries.Emails;

namespace LNK.QueryHandlers.Emails
{
    public class EmailTemplateCategoryQueryHandler :
        IQueryHandler<ListEmailTemplateCategoriesQuery, PagedQueryResult<EmailTemplateCategoryOverview>>,
        IQueryHandler<GetAllEmailTemplateCategoriesQuery, IEnumerable<EmailTemplateCategoryOverview>>,
        IQueryHandler<GetEmailTemplateCategoryDetailsQuery, EmailTemplateCategoryDetails>
    {
        private readonly IMapper _mapper;
        private readonly IMongoDbReadRepository _readRepository;

        public EmailTemplateCategoryQueryHandler(
            IMapper mapper,
            IMongoDbReadRepository readRepository)
        {
            _mapper = mapper;
            _readRepository = readRepository;
        }

        public PagedQueryResult<EmailTemplateCategoryOverview> Handle(ListEmailTemplateCategoriesQuery query)
        {
            var builder = Builders<EmailTemplateCategory>.Filter;
            var filter = builder.Empty;

            var emailTemplateCategories = _readRepository.Find(filter);
            var totalItemCount = emailTemplateCategories.Count();

            var emailTemplateCategoryOverviews = _mapper.Map<IEnumerable<EmailTemplateCategoryOverview>>(emailTemplateCategories
                .SortByDescending(it => it.CreatedDate)
                .Skip((query.Page - 1) * query.PageSize)
                .Limit(query.PageSize)
                .ToList());
            var pagedResult = new PagedQueryResult<EmailTemplateCategoryOverview>(emailTemplateCategoryOverviews, totalItemCount, query.Page, query.PageSize);
            return pagedResult;
        }

        public IEnumerable<EmailTemplateCategoryOverview> Handle(GetAllEmailTemplateCategoriesQuery query)
        {
            var builder = Builders<EmailTemplateCategory>.Filter;
            var filter = builder.Empty;

            var emailTemplateCategories = _readRepository.Find(filter);
            var totalItemCount = emailTemplateCategories.Count();

            var emailTemplateCategoryOverviews = _mapper.Map<IEnumerable<EmailTemplateCategoryOverview>>(emailTemplateCategories.ToList());
            return emailTemplateCategoryOverviews;
        }

        public EmailTemplateCategoryDetails Handle(GetEmailTemplateCategoryDetailsQuery query)
        {
            var builder = Builders<EmailTemplateCategory>.Filter;
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

            var emailTemplateCategory = _readRepository.Find(filter).FirstOrDefault();
            var emailTemplateCategoryDetails = _mapper.Map<EmailTemplateCategoryDetails>(emailTemplateCategory);
            return emailTemplateCategoryDetails;
        }
    }
}