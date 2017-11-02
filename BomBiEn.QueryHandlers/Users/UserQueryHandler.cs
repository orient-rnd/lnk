using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Driver;
using BomBiEn.Domain.Users.Models;
using BomBiEn.Infrastructure.MongoDb;
using BomBiEn.Infrastructure.Queries;
using BomBiEn.Queries.Users;

namespace BomBiEn.QueryHandlers.Users
{
    public class UserQueryHandler :
        IQueryHandler<ListUsersQuery, PagedQueryResult<UserOverview>>,
        IQueryHandler<GetAllUsersQuery, IEnumerable<UserOverview>>,
        IQueryHandler<ListUserEmailsQuery, PagedQueryResult<UserEmailOverview>>,
        IQueryHandler<GetUserDetailsQuery, UserDetails>,
        IQueryHandler<ImpersonationQuery, ImpersonationQueryResult>
    {
        private readonly IMapper _mapper;
        private readonly IMongoDbReadRepository _readRepository;

        public UserQueryHandler(
            IMapper mapper,
            IMongoDbReadRepository readRepository)
        {
            _mapper = mapper;
            _readRepository = readRepository;
        }

        public PagedQueryResult<UserOverview> Handle(ListUsersQuery query)
        {
            var builder = Builders<User>.Filter;
            var filter = builder.Empty;

            if (!String.IsNullOrEmpty(query.Email))
            {
                filter = filter & builder.Where(it => it.Email == query.Email);
            }

            if (!String.IsNullOrEmpty(query.FirstName))
            {
                filter = filter & builder.Where(it => it.FirstName == query.FirstName);
            }

            if (!String.IsNullOrEmpty(query.LastName))
            {
                filter = filter & builder.Where(it => it.LastName == query.LastName);
            }

            var users = _readRepository.Find<User>(filter);
            var totalItemCount = users.Count();

            var userOverviews = _mapper.Map<IEnumerable<UserOverview>>(users
                .SortByDescending(it => it.CreatedDate)
                .Skip((query.Page - 1) * query.PageSize)
                .Limit(query.PageSize)
                .ToList());
            var pagedResult = new PagedQueryResult<UserOverview>(userOverviews, totalItemCount, query.Page, query.PageSize);
            return pagedResult;
        }

        // CR ZP: We should not retrieve all users at once
        public IEnumerable<UserOverview> Handle(GetAllUsersQuery query)
        {
            var users = _readRepository.Find<User>();
            return _mapper.Map<IEnumerable<UserOverview>>(users.ToList());
        }

        public PagedQueryResult<UserEmailOverview> Handle(ListUserEmailsQuery query)
        {
            var builder = Builders<User>.Filter;
            var filter = builder.Empty;

            if (!String.IsNullOrEmpty(query.Email))
            {
                filter = filter & builder.Where(it => it.Email.Contains(query.Email));
            }

            var users = _readRepository.Find<User>(filter);
            var totalItemCount = users.Count();
            var userEmails = _mapper.Map<IEnumerable<UserEmailOverview>>(users
                .SortByDescending(it => it.CreatedDate)
                .Skip((query.Page - 1) * query.PageSize)
                .Limit(query.PageSize)
                .ToList());

            var pagedResult = new PagedQueryResult<UserEmailOverview>(userEmails, totalItemCount, query.Page, query.PageSize);
            return pagedResult;
        }

        public UserDetails Handle(GetUserDetailsQuery query)
        {
            var builder = Builders<User>.Filter;
            var filter = builder.Empty;

            if (!String.IsNullOrEmpty(query.Id))
            {
                filter = filter & builder.Eq(it => it.Id, query.Id);
            }

            if (!String.IsNullOrEmpty(query.Email))
            {
                filter = filter & builder.Eq(it => it.NormalizedEmail, query.Email.ToUpperInvariant());
            }

            if (!String.IsNullOrEmpty(query.Token))
            {
                filter = filter & builder.ElemMatch(it => it.AppTokens, appToken => appToken.Token == query.Token && appToken.ExpiryDate >= DateTime.UtcNow);
            }

            if (filter == builder.Empty)
            {
                return null;
            }

            var user = _readRepository.Find(filter).FirstOrDefault();
            var userDetails = _mapper.Map<UserDetails>(user);

            return userDetails;
        }

        public ImpersonationQueryResult Handle(ImpersonationQuery query)
        {
            var user = _readRepository.Get<User>(query.Id);
            Contract.Assert(user != null);

            var validAppToken = user.AppTokens?.Where(it => it.ExpiryDate >= DateTime.UtcNow).FirstOrDefault();
            if (validAppToken == null)
            {
                return null;
            }

            return new ImpersonationQueryResult()
            {
                Token = validAppToken.Token
            };
        }
    }
}