using AutoMapper;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using BomBiEn.Commands.FlashCards;
using BomBiEn.Domain.FlashCards.Models;
using BomBiEn.Infrastructure.Commands;
using BomBiEn.Infrastructure.MongoDb;

namespace BomBiEn.CommandHandlers.FlashCards
{
    public class FlashCardCommandHandler :
        ICommandHandler<CreateFlashCardCommand>,
        ICommandHandler<UpdateFlashCardCommand>,
        ICommandHandler<DeleteFlashCardCommand>,
        ICommandHandler<SyncViewNumberCommand>
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
            var FlashCard = _mapper.Map<FlashCard>(command);
            if (String.IsNullOrEmpty(FlashCard.Id))
            {
                FlashCard.Id = Guid.NewGuid().ToString("N");
            }

            if (!string.IsNullOrEmpty(command.FlashCardCategoryId))
            {
                var cat = _writeRepository.Get<FlashCardCategory>(command.FlashCardCategoryId);
                FlashCard.FlashCardCategoryName = cat.Name;
                FlashCard.UserEmail = cat.UserEmail;
            }

            _writeRepository.Create(FlashCard);
            //_auditLogService.LogCreate<FlashCard>(FlashCard.Id, FlashCard.CreatedBy, FlashCard.ToJson());
        }

        public void Handle(UpdateFlashCardCommand command)
        {
            var FlashCard = _writeRepository.Get<FlashCard>(command.Id);
            Contract.Assert(FlashCard != null);

            var originalJson = FlashCard.ToJson();
            _mapper.Map(command, FlashCard);

            if (!string.IsNullOrEmpty(command.FlashCardCategoryId))
            {
                var cat = _writeRepository.Get<FlashCardCategory>(command.FlashCardCategoryId);
                FlashCard.FlashCardCategoryName = cat.Name;
                FlashCard.UserEmail = cat.UserEmail;
            }

            _writeRepository.Replace(FlashCard);
            //_auditLogService.LogUpdate<FlashCard>(command.Id, command.ModifiedBy, originalJson, FlashCard.ToJson());
        }

        public void Handle(DeleteFlashCardCommand command)
        {
            var FlashCard = _writeRepository.Get<FlashCard>(command.Id);
            Contract.Assert(FlashCard != null);

            _writeRepository.Delete(FlashCard);
            //_auditLogService.LogDelete<FlashCard>(command.Id, command.DeletedBy, FlashCard.ToJson());
        }

        public void Handle(SyncViewNumberCommand command)
        {
            foreach (var item in command.Views)
            {
                var FlashCard = _writeRepository.Get<FlashCard>(item.Id);
                FlashCard.ViewNumber += item.Viewed;
                _writeRepository.Replace(FlashCard);
            }
        }
    }
}