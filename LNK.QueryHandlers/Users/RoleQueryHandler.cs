using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Driver;
using LNK.Domain.Users.Models;
using LNK.Infrastructure.MongoDb;
using LNK.Infrastructure.Queries;
using LNK.Queries.Users;

namespace LNK.QueryHandlers.Users
{
    /// <summary>
    /// Role query handler
    /// </summary>
    public class RoleQueryHandler :
        IQueryHandler<ListRolesQuery, PagedQueryResult<RoleOverview>>,
        IQueryHandler<GetRoleDetailsQuery, RoleDetails>
    {
        private readonly IMapper _mapper;
        private readonly IMongoDbReadRepository _readRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        public RoleQueryHandler(
            IMapper mapper,
            IMongoDbReadRepository readRepository)
        {
            _mapper = mapper;
            _readRepository = readRepository;
        }

        /// <summary>
        /// List roles
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public PagedQueryResult<RoleOverview> Handle(ListRolesQuery query)
        {
            var builder = Builders<Role>.Filter;
            var filter = builder.Empty;

            if (!String.IsNullOrEmpty(query.Name))
            {
                filter = filter & builder.Where(it => it.Name.ToLower().Contains(query.Name.ToLower()));
            }

            var roles = _readRepository.Find(filter);
            var totalItemCount = roles.Count();

            var roleOverviews = _mapper.Map<IEnumerable<RoleOverview>>(roles
                .SortByDescending(it => it.Name)
                .Skip((query.Page - 1) * query.PageSize)
                .Limit(query.PageSize)
                .ToList());
            return new PagedQueryResult<RoleOverview>(roleOverviews, totalItemCount, query.Page, query.PageSize);
        }

        /// <summary>
        /// Get role details query
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public RoleDetails Handle(GetRoleDetailsQuery query)
        {
            var builder = Builders<Role>.Filter;
            var filter = builder.Empty;

            if (!String.IsNullOrEmpty(query.Id))
            {
                filter = filter & builder.Eq(it => it.Id, query.Id);
            }

            if (!String.IsNullOrEmpty(query.Name))
            {
                filter = filter & builder.Eq(it => it.Name, query.Name);
            }

            if (filter == builder.Empty)
            {
                return null;
            }

            var role = _readRepository.Find(filter).FirstOrDefault();
            var roleDetails = _mapper.Map<RoleDetails>(role);
            return roleDetails;
        }
    }
}