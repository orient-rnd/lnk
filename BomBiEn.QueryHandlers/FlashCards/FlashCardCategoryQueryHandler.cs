﻿using AutoMapper;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using BomBiEn.Domain.FlashCards.Models;
using BomBiEn.Infrastructure.MongoDb;
using BomBiEn.Infrastructure.Queries;
using BomBiEn.Queries.FlashCards;

namespace BomBiEn.QueryHandlers.FlashCards
{
    public class FlashCardCategoryQueryHandler :
        IQueryHandler<ListFlashCardCategoriesQuery, PagedQueryResult<FlashCardCategoryOverview>>,
        IQueryHandler<GetAllFlashCardCategoriesQuery, IEnumerable<FlashCardCategoryOverview>>,
        IQueryHandler<GetFlashCardCategoryDetailsQuery, FlashCardCategoryDetails>
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

        public PagedQueryResult<FlashCardCategoryOverview> Handle(ListFlashCardCategoriesQuery query)
        {
            var builder = Builders<FlashCardCategory>.Filter;
            var filter = builder.Empty;

            if (!String.IsNullOrEmpty(query.UserId))
            {
                filter = filter & builder.Eq(it => it.UserId, query.UserId);
            }

            var FlashCardCategories = _readRepository.Find(filter);
            var totalItemCount = FlashCardCategories.Count();

            var FlashCardCategoryOverviews = _mapper.Map<IEnumerable<FlashCardCategoryOverview>>(FlashCardCategories
                .SortByDescending(it => it.CreatedDate)
                .Skip((query.Page - 1) * query.PageSize)
                .Limit(query.PageSize)
                .ToList());
            var pagedResult = new PagedQueryResult<FlashCardCategoryOverview>(FlashCardCategoryOverviews, totalItemCount, query.Page, query.PageSize);
            return pagedResult;
        }

        public FlashCardCategoryDetails Handle(GetFlashCardCategoryDetailsQuery query)
        {
            var builder = Builders<FlashCardCategory>.Filter;
            var filter = builder.Empty;

            if (!String.IsNullOrEmpty(query.Id))
            {
                filter = filter & builder.Eq(it => it.Id, query.Id);
            }
            
            if (filter == builder.Empty)
            {
                return null;
            }

            var FlashCardCategory = _readRepository.Find(filter).FirstOrDefault();
            var FlashCardCategoryDetails = _mapper.Map<FlashCardCategoryDetails>(FlashCardCategory);
            return FlashCardCategoryDetails;
        }

        public IEnumerable<FlashCardCategoryOverview> Handle(GetAllFlashCardCategoriesQuery query)
        {
            var builder = Builders<FlashCardCategory>.Filter;
            var filter = builder.Empty;

            var FlashCardCategories = _readRepository.Find(filter);
            var totalItemCount = FlashCardCategories.Count();

            var FlashCardCategoryOverviews = _mapper.Map<IEnumerable<FlashCardCategoryOverview>>(FlashCardCategories.ToList());
            return FlashCardCategoryOverviews;
        }
    }
}