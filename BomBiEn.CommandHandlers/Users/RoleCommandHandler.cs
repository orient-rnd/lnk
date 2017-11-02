using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Bson;
using BomBiEn.Commands.Users;
using BomBiEn.Domain.Users.Models;
using BomBiEn.Infrastructure.Commands;
using BomBiEn.Infrastructure.MongoDb;

namespace BomBiEn.CommandHandlers.Users
{
    /// <summary>
    /// Role command handler
    /// </summary>
    public class RoleCommandHandler :
        ICommandHandler<CreateRoleCommand>,
        ICommandHandler<UpdateRoleCommand>,
        ICommandHandler<DeleteRoleCommand>
    {
        private readonly IMapper _mapper;
        private readonly IMongoDbWriteRepository _writeRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="writeRepository"></param>
        /// <param name="auditLogService"></param>
        public RoleCommandHandler(
            IMapper mapper,
            IMongoDbWriteRepository writeRepository)
        {
            _mapper = mapper;
            _writeRepository = writeRepository;
        }

        /// <summary>
        /// Handle create Role
        /// </summary>
        /// <param name="command"></param>
        public void Handle(CreateRoleCommand command)
        {
            var role = _mapper.Map<Role>(command);
            if (String.IsNullOrEmpty(role.Id))
            {
                role.Id = Guid.NewGuid().ToString();
            }

            _writeRepository.Create(role);
        }

        /// <summary>
        /// Handle update Role
        /// </summary>
        /// <param name="command"></param>
        public void Handle(UpdateRoleCommand command)
        {
            var role = _writeRepository.Get<Role>(command.Id);
            Contract.Assert(role != null);

            var originalJson = role.ToJson();
            _mapper.Map(command, role);

            _writeRepository.Replace(role);
        }

        /// <summary>
        /// Handle delete Role
        /// </summary>
        /// <param name="command"></param>
        public void Handle(DeleteRoleCommand command)
        {
            var role = _writeRepository.Get<Role>(command.Id);
            Contract.Assert(role != null);

            _writeRepository.Delete(role);
        }
    }
}