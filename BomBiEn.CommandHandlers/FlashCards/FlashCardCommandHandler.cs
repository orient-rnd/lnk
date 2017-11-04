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
using BomBiEn.Commands.FlashCards;

namespace BomBiEn.CommandHandlers.FlashCards
{
    public class FlashCardCommandHandler : ICommandHandler<CreateFlashCardCommand>
    {
        private readonly IMapper _mapper;
        private readonly IMongoDbWriteRepository _writeRepository;

        public FlashCardCommandHandler(
            IMapper mapper,
            IMongoDbWriteRepository writeRepository)
        {
            _mapper = mapper;
            _writeRepository = writeRepository;
        }
        public void Handle(CreateFlashCardCommand command)
        {
            var flashCard = _mapper.Map<FlashCard>(command);
            if (String.IsNullOrEmpty(flashCard.Id))
            {
                flashCard.Id = Guid.NewGuid().ToString("N");
            }

            if (String.IsNullOrEmpty(flashCard.CreatedBy))
            {
                flashCard.CreatedBy = "HuyTran-dev";
            }

            _writeRepository.Create(flashCard);
        }
    }
}