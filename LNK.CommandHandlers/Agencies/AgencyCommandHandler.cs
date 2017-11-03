using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Bson;
using LNK.Commands.Agencies;
using LNK.Domain.Agencies.Models;
using LNK.Infrastructure.Commands;
using LNK.Infrastructure.MongoDb;

namespace LNK.CommandHandlers.Agencies
{
    public class AgencyCommandHandler :
        ICommandHandler<CreateAgencyCommand>,
        ICommandHandler<UpdateAgencyCommand>,
        ICommandHandler<DeleteAgencyCommand>
    {
        private readonly IMapper _mapper;
        private readonly IMongoDbWriteRepository _writeRepository;

        public AgencyCommandHandler(
            IMapper mapper,
            IMongoDbWriteRepository writeRepository)
        {
            _mapper = mapper;
            _writeRepository = writeRepository;
        }

        public void Handle(CreateAgencyCommand command)
        {
            var item = _mapper.Map<Agency>(command);
            if (String.IsNullOrEmpty(item.Id))
            {
                item.Id = Guid.NewGuid().ToString("N");
            }

            _writeRepository.Create(item);
        }

        public void Handle(UpdateAgencyCommand command)
        {
            var item = _writeRepository.Get<Agency>(command.Id);
            Contract.Assert(item != null);

            var originalJson = item.ToJson();
            _mapper.Map(command, item);

            _writeRepository.Replace(item);
        }

        public void Handle(DeleteAgencyCommand command)
        {
            var item = _writeRepository.Get<Agency>(command.Id);
            Contract.Assert(item != null);

            _writeRepository.Delete(item);
        }
    }
}