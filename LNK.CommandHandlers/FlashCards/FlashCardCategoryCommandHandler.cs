using AutoMapper;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using LNK.Commands.FlashCards;
using LNK.Domain.FlashCards.Models;
using LNK.Infrastructure.Commands;
using LNK.Infrastructure.MongoDb;
using LNK.Domain.Users.Models;

namespace LNK.CommandHandlers.FlashCards
{
    public class FlashCardCategoryCommandHandler :
        ICommandHandler<CreateFlashCardCategoryCommand>,
        ICommandHandler<UpdateFlashCardCategoryCommand>,
        ICommandHandler<DeleteFlashCardCategoryCommand>
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
            var FlashCardCategory = _mapper.Map<FlashCardCategory>(command);
            if (String.IsNullOrEmpty(FlashCardCategory.Id))
            {
                FlashCardCategory.Id = Guid.NewGuid().ToString("N");
            }

            if (!string.IsNullOrEmpty(command.UserId))
            {
                var user = _writeRepository.Get<User>(command.UserId);
                FlashCardCategory.UserEmail = user.Email;
            }

            _writeRepository.Create(FlashCardCategory);
        }

        public void Handle(UpdateFlashCardCategoryCommand command)
        {
            var FlashCardCategory = _writeRepository.Get<FlashCardCategory>(command.Id);
            Contract.Assert(FlashCardCategory != null);

            var originalJson = FlashCardCategory.ToJson();
            _mapper.Map(command, FlashCardCategory);

            if (!string.IsNullOrEmpty(command.UserId))
            {
                var user = _writeRepository.Get<User>(command.UserId);
                FlashCardCategory.UserEmail = user.Email;
            }

            _writeRepository.Replace(FlashCardCategory);
        }

        public void Handle(DeleteFlashCardCategoryCommand command)
        {
            var FlashCardCategory = _writeRepository.Get<FlashCardCategory>(command.Id);
            Contract.Assert(FlashCardCategory != null);

            _writeRepository.Delete(FlashCardCategory);
        }
    }
}
