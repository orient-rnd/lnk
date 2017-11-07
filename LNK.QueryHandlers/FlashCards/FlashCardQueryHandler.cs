using AutoMapper;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using LNK.Domain.FlashCards.Models;
using LNK.Infrastructure.MongoDb;
using LNK.Infrastructure.Queries;
using LNK.Queries.FlashCards;
using LNK.Domain.Sentences.Models;
using LNK.Domain.Users.Models;

namespace LNK.QueryHandlers.FlashCards
{
    public class FlashCardQueryHandler:
        IQueryHandler<GetFlashCardDetails, FlashCardDetails>

    {
        private readonly IMapper _mapper;
        private readonly IMongoDbReadRepository _readRepository;

        public FlashCardQueryHandler(
            IMapper mapper,
            IMongoDbReadRepository readRepository)
        {
            _mapper = mapper;
            _readRepository = readRepository;
        }

        public FlashCardDetails Handle(GetFlashCardDetails query)
        {
            var builder = Builders<FlashCard>.Filter;
            var filter = builder.Empty;

            if (!String.IsNullOrEmpty(query.Id))
            {
                filter = filter & builder.Eq(it => it.Id, query.Id);
            }

            if (filter == builder.Empty)
            {
                return null;
            }

            var flashCard = _readRepository.Find(filter).FirstOrDefault();
            var flashCardDetails = _mapper.Map<FlashCardDetails>(flashCard);
            return flashCardDetails;
        }
    }
}