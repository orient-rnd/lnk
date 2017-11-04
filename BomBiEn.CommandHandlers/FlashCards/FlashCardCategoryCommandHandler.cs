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

namespace BomBiEn.CommandHandlers.FlashCards
{
    public class FlashCardCategoryCommandHandler:
        ICommandHandler<CreateFlashCardCategoryCommand>
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

        public void Handle(CreateFlashCardCategoryCommand command)
        {
            var flashCardCategory = _mapper.Map<FlashCardCategory>(command);            
            _writeRepository.Create(flashCardCategory);
            //_auditLogService.LogCreate<Sentence>(Sentence.Id, Sentence.CreatedBy, Sentence.ToJson());
        }

    }
}