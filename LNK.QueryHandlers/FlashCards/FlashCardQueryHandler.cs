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
    public class FlashCardQueryHandler

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

    }
}