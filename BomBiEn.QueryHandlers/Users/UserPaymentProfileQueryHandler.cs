using System;
using System.Collections.Generic;
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
    public class UserPaymentProfileQueryHandler :
        IQueryHandler<ListUserPaymentProfilesQuery, PagedQueryResult<UserPaymentProfileOverview>>,
        IQueryHandler<GetUserPaymentProfileDetailsQuery, UserPaymentProfileDetails>
    {
        private readonly IMapper _mapper;
        private readonly IMongoDbReadRepository _readRepository;

        public UserPaymentProfileQueryHandler(
            IMapper mapper,
            IMongoDbReadRepository readRepository)
        {
            _mapper = mapper;
            _readRepository = readRepository;
        }

        public PagedQueryResult<UserPaymentProfileOverview> Handle(ListUserPaymentProfilesQuery query)
        {
            var builder = Builders<User>.Filter;
            var filter = builder.Empty;

            if (!String.IsNullOrEmpty(query.UserId))
            {
                filter = builder.Where(it => it.Id == query.UserId);
            }

            var user = _readRepository.Find<User>(filter).FirstOrDefault();
            if (user != null)
            {
                var userPaymentProfiles = user.PaymentProfiles;
                if (userPaymentProfiles != null)
                {
                    var userPaymentProfileOverviews = _mapper.Map<IEnumerable<UserPaymentProfileOverview>>(userPaymentProfiles
                        .OrderByDescending(it => it.CreatedDate)
                        .ToList());
                    var pagedResult = new PagedQueryResult<UserPaymentProfileOverview>(userPaymentProfileOverviews, userPaymentProfileOverviews.Count(), query.Page, query.PageSize);
                    return pagedResult;
                }
            }

            return new PagedQueryResult<UserPaymentProfileOverview>(Enumerable.Empty<UserPaymentProfileOverview>(), 0, query.Page, query.PageSize);
        }

        public UserPaymentProfileDetails Handle(GetUserPaymentProfileDetailsQuery query)
        {
            var builder = Builders<User>.Filter;
            var filter = builder.Eq(it => it.Id, query.UserId);

            var user = _readRepository.Find(filter).FirstOrDefault();
            if (user == null)
            {
                return null;
            }

            var userPaymentProfile = user.PaymentProfiles.Where(it => it.Id == query.Id).FirstOrDefault();
            var userPaymentProfileDetails = _mapper.Map<UserPaymentProfileDetails>(userPaymentProfile);
            return userPaymentProfileDetails;
        }
    }
}