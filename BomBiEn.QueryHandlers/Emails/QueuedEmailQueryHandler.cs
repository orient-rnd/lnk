using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Driver;
using BomBiEn.Domain.Emails.Models;
using BomBiEn.Infrastructure.MongoDb;
using BomBiEn.Infrastructure.Queries;
using BomBiEn.Queries.Emails;

namespace BomBiEn.QueryHandlers.Emails
{
    public class QueuedEmailQueryHandler :
        IQueryHandler<ListQueuedEmailsQuery, PagedQueryResult<QueuedEmailOverview>>,
        IQueryHandler<GetQueuedEmailDetailsQuery, QueuedEmailDetails>
    {
        private readonly IMapper _mapper;
        private readonly IMongoDbReadRepository _readRepository;

        public QueuedEmailQueryHandler(
            IMapper mapper,
            IMongoDbReadRepository readRepository)
        {
            _mapper = mapper;
            _readRepository = readRepository;
        }

        public PagedQueryResult<QueuedEmailOverview> Handle(ListQueuedEmailsQuery query)
        {
            var builder = Builders<QueuedEmail>.Filter;
            var filter = builder.Empty;

            var queuedEmails = _readRepository.Find(filter);
            var totalItemCount = queuedEmails.Count();

            var queuedEmailOverviews = _mapper.Map<IEnumerable<QueuedEmailOverview>>(queuedEmails
                .SortByDescending(it => it.CreatedDate)
                .Skip((query.Page - 1) * query.PageSize)
                .Limit(query.PageSize)
                .ToList());
            var pagedResult = new PagedQueryResult<QueuedEmailOverview>(queuedEmailOverviews, totalItemCount, query.Page, query.PageSize);
            return pagedResult;
        }

        public QueuedEmailDetails Handle(GetQueuedEmailDetailsQuery query)
        {
            var builder = Builders<QueuedEmail>.Filter;
            var filter = builder.Eq(it => it.Id, query.Id);

            var queuedEmail = _readRepository.Find(filter).FirstOrDefault();
            var queuedEmailDetails = _mapper.Map<QueuedEmailDetails>(queuedEmail);
            return queuedEmailDetails;
        }
    }
}