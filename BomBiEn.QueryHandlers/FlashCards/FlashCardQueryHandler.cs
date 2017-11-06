using AutoMapper;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using BomBiEn.Domain.FlashCards.Models;
using BomBiEn.Infrastructure.MongoDb;
using BomBiEn.Infrastructure.Queries;
using BomBiEn.Domain.Sentences.Models;
using BomBiEn.Domain.Users.Models;
using BomBiEn.Queries.Categories;

namespace BomBiEn.QueryHandlers.FlashCards
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