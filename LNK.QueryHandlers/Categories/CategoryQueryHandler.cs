using AutoMapper;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using LNK.Domain.Categories.Models;
using LNK.Infrastructure.MongoDb;
using LNK.Infrastructure.Queries;
using LNK.Queries.Categories;
using LNK.Domain.FlashCards.Models;

namespace LNK.QueryHandlers.Package
{
    public class CategoryQueryHandler :
        IQueryHandler<ListCategoriesQuery, PagedQueryResult<CategoryOverview>>,
        IQueryHandler<GetAllCategoriesQuery, IEnumerable<CategoryOverview>>,
        IQueryHandler<GetCategoryDetailsQuery, CategoryDetails>
    {
        private readonly IMapper _mapper;
        private readonly IMongoDbReadRepository _readRepository;

        public CategoryQueryHandler(
            IMapper mapper,
            IMongoDbReadRepository readRepository)
        {
            _mapper = mapper;
            _readRepository = readRepository;
        }

        public PagedQueryResult<CategoryOverview> Handle(ListCategoriesQuery query)
        {
            var builder = Builders<Category>.Filter;
            var filter = builder.Empty;

            if (!String.IsNullOrEmpty(query.CategoryName))
            {
                filter = filter & builder.Where(it => it.NameEn.ToLower().Contains(query.CategoryName.ToLower()) || it.NameVn.ToLower().Contains(query.CategoryName.ToLower()));
            }

            if (!String.IsNullOrEmpty(query.CategoryParent))
            {
                filter = filter & builder.Eq(it => it.IdCategoryParent, query.CategoryParent);
            }

            var packageCategories = _readRepository.Find(filter);
            var totalItemCount = packageCategories.Count();

            var CategoryOverviews = _mapper.Map<IEnumerable<CategoryOverview>>(packageCategories
                .SortByDescending(it => it.CreatedDate)
                .Skip((query.Page - 1) * query.PageSize)
                .Limit(query.PageSize)
                .ToList());
            var pagedResult = new PagedQueryResult<CategoryOverview>(CategoryOverviews, totalItemCount, query.Page, query.PageSize);
            return pagedResult;
        }

        public CategoryDetails Handle(GetCategoryDetailsQuery query)
        {
            var builder = Builders<Category>.Filter;
            var filter = builder.Empty;

            if (!String.IsNullOrEmpty(query.Id))
            {
                filter = filter & builder.Eq(it => it.Id, query.Id);
            }

            if (filter == builder.Empty)
            {
                return null;
            }

            var Category = _readRepository.Find(filter).FirstOrDefault();
            var CategoryDetails = _mapper.Map<CategoryDetails>(Category);
            return CategoryDetails;
        }

        public IEnumerable<CategoryOverview> Handle(GetAllCategoriesQuery query)
        {
            var builder = Builders<Category>.Filter;
            var filter = builder.Empty;

            var packageCategories = _readRepository.Find(filter);
            var totalItemCount = packageCategories.Count();

            var CategoryOverviews = _mapper.Map<IEnumerable<CategoryOverview>>(packageCategories.ToList());
            return CategoryOverviews;
        }

      
    }
}