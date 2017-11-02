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
using BomBiEn.Domain.Users.Models;

namespace BomBiEn.CommandHandlers.FlashCards
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
