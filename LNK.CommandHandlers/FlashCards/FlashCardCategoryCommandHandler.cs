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
using LNK.Domain.Users.Models;
using LNK.Commands.FlashCards;
using MongoDB.Driver;


namespace LNK.CommandHandlers.FlashCards
{
    public class FlashCardCategoryCommandHandler :
        ICommandHandler<CreateFlashCardCategoryCommand>,
        ICommandHandler<DeleteFlashcardCategoryCommand>,
        ICommandHandler<UpdateFlashCardCategoryCommand>
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
            if (this.deleteDependentcomponents(command.Id))
            {
                _writeRepository.Delete<FlashCardCategory>(command.Id);
            }
            //Contract.Assert(FlashCardCategory != null);
        }

        private bool deleteDependentcomponents(string id)
        {
            try
            {
                var filter = Builders<FlashCard>.Filter.Eq("FlashCardCategoryId", id);
                _writeRepository.DeleteMany<FlashCard>(filter);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void Handle(CreateFlashCardCategoryCommand command)
        {
            var flashCardCategory = _mapper.Map<FlashCardCategory>(command);
            _writeRepository.Create(flashCardCategory);
            //_auditLogService.LogCreate<Sentence>(Sentence.Id, Sentence.CreatedBy, Sentence.ToJson());
        }

        public void Handle(UpdateFlashCardCategoryCommand command)
        {
            var flashCardCategory = _writeRepository.Get<FlashCardCategory>(command.Id);
            Contract.Assert(flashCardCategory != null);

            var originalJson = flashCardCategory.ToJson();
            _mapper.Map(command, flashCardCategory);

            _writeRepository.Replace(flashCardCategory);
        }
    }
}