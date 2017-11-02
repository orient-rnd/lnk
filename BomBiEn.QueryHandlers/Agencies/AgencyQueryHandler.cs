using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Driver;
using BomBiEn.Domain.Agencies.Models;
using BomBiEn.Infrastructure.MongoDb;
using BomBiEn.Infrastructure.Queries;
using BomBiEn.Queries.Agencies;

namespace BomBiEn.QueryHandlers.Agencies
{
    public class AgencyQueryHandler :
        IQueryHandler<ListAgenciesQuery, PagedQueryResult<AgencyOverview>>,
        IQueryHandler<GetAllAgenciesQuery, IEnumerable<AgencyOverview>>,
        IQueryHandler<GetAgencyDetailsQuery, AgencyDetails>
    {
        private readonly IMapper _mapper;
        private readonly IMongoDbReadRepository _readRepository;

        public AgencyQueryHandler(
            IMapper mapper,
            IMongoDbReadRepository readRepository)
        {
            _mapper = mapper;
            _readRepository = readRepository;
        }

        public PagedQueryResult<AgencyOverview> Handle(ListAgenciesQuery query)
        {
            var items = _readRepository.Find<Agency>();
            var totalItemCount = items.Count();

            var itemOverviews = _mapper.Map<IEnumerable<AgencyOverview>>(items
                .SortByDescending(it => it.CreatedDate)
                .Skip((query.Page - 1) * query.PageSize)
                .Limit(query.PageSize)
                .ToList());

            var pagedResult = new PagedQueryResult<AgencyOverview>(itemOverviews, totalItemCount, query.Page, query.PageSize);
            return pagedResult;
        }

        public IEnumerable<AgencyOverview> Handle(GetAllAgenciesQuery query)
        {
            var items = _readRepository.Find<Agency>().ToList();
            return _mapper.Map<IEnumerable<AgencyOverview>>(items);
        }

        public AgencyDetails Handle(GetAgencyDetailsQuery query)
        {
            var builder = Builders<Agency>.Filter;

            var filter = builder.Empty;

            if (!String.IsNullOrEmpty(query.Id))
            {
                filter = filter & builder.Where(it => it.Id == query.Id);
            }            

            if (filter == builder.Empty)
            {
                return null;
            }

            var item = _readRepository.Find<Agency>(filter).FirstOrDefault();
            return _mapper.Map<AgencyDetails>(item);
        }
    }
}