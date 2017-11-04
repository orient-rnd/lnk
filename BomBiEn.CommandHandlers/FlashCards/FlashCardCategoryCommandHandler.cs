using AutoMapper;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using BomBiEn.Domain.FlashCards.Models;
using BomBiEn.Infrastructure.Commands;
using BomBiEn.Infrastructure.MongoDb;
using BomBiEn.Domain.Users.Models;
using BomBiEn.Commands.FlashCards;
using MongoDB.Driver;

namespace BomBiEn.CommandHandlers.FlashCards
{
    public class FlashCardCategoryCommandHandler : ICommandHandler<DeleteFlashcardCategoryCommand>
    {
        private readonly IMapper _mapper;
        private readonly IMongoDbWriteRepository _writeRepository;

        public FlashCardCategoryCommandHandler(
            IMapper mapper,
            IMongoDbWriteRepository writeRepository)
        {
            _mapper = mapper;
            _writeRepository = writeRepository;
        }

        public void Handle(DeleteFlashcardCategoryCommand command)
        {
            var FlashCardCategory = _writeRepository.Get<FlashCardCategory>(command.Id);
            var filter = Builders<FlashCard>.Filter.Eq("FlashCardCategoryId", command.Id);
            var result = _writeRepository.Find<FlashCard>(filter).ToList();
            Contract.Assert(FlashCardCategory != null);
            //_writeRepository.Delete(FlashCardCategory);
        }

        private bool deleteDependentcomponents(string id)
        {


            return true;
        }
    }
}