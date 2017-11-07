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
    public class FlashCardCommandHandler: ICommandHandler<UpdateFlashCardCommand>
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

        public void Handle (UpdateFlashCardCommand command)
        {
            var flashCard = _writeRepository.Get<FlashCard>(command.Id);
            Contract.Assert(flashCard != null);

            _mapper.Map(command, flashCard);

            _writeRepository.Replace<FlashCard>(flashCard);

        }
    }
}