using AutoMapper;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using BomBiEn.Domain.FlashCards.Models;
using BomBiEn.Infrastructure.MongoDb;
using BomBiEn.Infrastructure.Queries;
using BomBiEn.Queries.Categories;
using BomBiEn.Queries.FlashCards;

namespace BomBiEn.QueryHandlers.FlashCards
{
    public class FlashCardCategoryQueryHandler :
        IQueryHandler<ListFlashCategoriesQuery, PagedQueryResult<FlashcardCategoryOverview>>
    {
        private readonly IMapper _mapper;
        private readonly IMongoDbReadRepository _readRepository;

        public FlashCardCategoryQueryHandler(
            IMapper mapper,
            IMongoDbReadRepository readRepository)
        {
            _mapper = mapper;
            _readRepository = readRepository;
        }

        public PagedQueryResult<FlashcardCategoryOverview> Handle(ListFlashCategoriesQuery query)
        {
            var builder = Builders<FlashCardCategory>.Filter;
            var filter = builder.Empty;

            var packageSentences = _readRepository.Find(filter);
            var totalItemCount = packageSentences.Count();

            var flashcardCategoryOverview = _mapper.Map<IEnumerable<FlashcardCategoryOverview>>(packageSentences
                .SortByDescending(it => it.CreatedDate)
                .Skip((query.Page - 1) * query.PageSize)
                .Limit(query.PageSize)
                .ToList());
            var pagedResult = new PagedQueryResult<FlashcardCategoryOverview>(flashcardCategoryOverview, totalItemCount, query.Page, query.PageSize);
            return pagedResult;
        }
    }
}