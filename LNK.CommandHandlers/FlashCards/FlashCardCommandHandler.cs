using AutoMapper;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using LNK.Domain.FlashCards.Models;
using LNK.Infrastructure.Commands;
using LNK.Infrastructure.MongoDb;
using LNK.Commands.FlashCards;

namespace LNK.CommandHandlers.FlashCards
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