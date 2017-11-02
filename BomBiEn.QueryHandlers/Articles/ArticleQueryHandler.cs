using AutoMapper;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using BomBiEn.Domain.Articles.Models;
using BomBiEn.Infrastructure.MongoDb;
using BomBiEn.Infrastructure.Queries;
using BomBiEn.Queries.Articles;

namespace BomBiEn.QueryHandlers.Articles
{
    public class ArticleQueryHandler :
        IQueryHandler<ListArticlesQuery, PagedQueryResult<ArticleOverview>>,
        IQueryHandler<GetAllArticlesQuery, IEnumerable<ArticleOverview>>,
        IQueryHandler<GetArticleDetailsQuery, ArticleDetails>
    {
        private readonly IMapper _mapper;
        private readonly IMongoDbReadRepository _readRepository;

        public ArticleQueryHandler(
            IMapper mapper,
            IMongoDbReadRepository readRepository)
        {
            _mapper = mapper;
            _readRepository = readRepository;
        }

        public PagedQueryResult<ArticleOverview> Handle(ListArticlesQuery query)
        {
            var builder = Builders<Article>.Filter;
            var filter = builder.Empty;

            var packageArticles = _readRepository.Find(filter);
            var totalItemCount = packageArticles.Count();

            var ArticleOverviews = _mapper.Map<IEnumerable<ArticleOverview>>(packageArticles
                .SortByDescending(it => it.CreatedDate)
                .Skip((query.Page - 1) * query.PageSize)
                .Limit(query.PageSize)
                .ToList());
            var pagedResult = new PagedQueryResult<ArticleOverview>(ArticleOverviews, totalItemCount, query.Page, query.PageSize);
            return pagedResult;
        }

        public ArticleDetails Handle(GetArticleDetailsQuery query)
        {
            var builder = Builders<Article>.Filter;
            var filter = builder.Empty;

            if (!String.IsNullOrEmpty(query.Id))
            {
                filter = filter & builder.Eq(it => it.Id, query.Id);
            }
            
            if (filter == builder.Empty)
            {
                return null;
            }

            var Article = _readRepository.Find(filter).FirstOrDefault();
            var ArticleDetails = _mapper.Map<ArticleDetails>(Article);
            return ArticleDetails;
        }

        public IEnumerable<ArticleOverview> Handle(GetAllArticlesQuery query)
        {
            var builder = Builders<Article>.Filter;
            var filter = builder.Empty;

            var packageArticles = _readRepository.Find(filter);
            var totalItemCount = packageArticles.Count();

            var ArticleOverviews = _mapper.Map<IEnumerable<ArticleOverview>>(packageArticles.ToList());
            return ArticleOverviews;
        }
    }
}