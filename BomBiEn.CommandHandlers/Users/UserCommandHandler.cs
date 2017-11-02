using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Bson;
using BomBiEn.Commands.Users;
using BomBiEn.Domain.Users.Models;
using BomBiEn.Domain.Users.Services;
using BomBiEn.Infrastructure.Commands;
using BomBiEn.Infrastructure.Domain;
using BomBiEn.Infrastructure.MongoDb;
using BomBiEn.Shared.Constants;
using MongoDB.Driver;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace BomBiEn.CommandHandlers.Users
{
    public class UserCommandHandler :
        ICommandHandler<SignUpCommand>,
        ICommandHandler<SignInCommand>,
        ICommandHandler<CreateUserCommand>,
        ICommandHandler<UpdateUserCommand>,
        ICommandHandler<DeleteUserCommand>,
        ICommandHandler<CreateUserTokenCommand>
    {
        private readonly IMapper _mapper;
        private readonly IMongoDbWriteRepository _writeRepository;
        private readonly IUserService _userService;
        private readonly ICommandBus _commandBus;

        public UserCommandHandler(
            IMapper mapper,
            IMongoDbWriteRepository writeRepository,
            IUserService userService,
            ICommandBus commandBus)
        {
            _mapper = mapper;
            _writeRepository = writeRepository;
            _userService = userService;
            _commandBus = commandBus;
        }

        public void Handle(SignUpCommand command)
        {
            var user = _mapper.Map<User>(command);
            if (String.IsNullOrEmpty(user.Id))
            {
                user.Id = Guid.NewGuid().ToString("N");
            }

            user.UserName = user.Email;
            user.Status = Shared.Enums.UserStatus.Approved;

            var result = _userService.SignUpAsync(user, command.Password).Result;
            if (!result.Succeeded)
            {
                throw new DomainException(result.Errors
                    .Select(it => new DomainExceptionError()
                    {
                        Code = it.Code,
                        Description = it.Description
                    }));
            }
        }

        public void Handle(SignInCommand command)
        {
            var result = _userService.SignInAsync(command.Email, command.Password, command.RememberMe).Result;
            if (!result.Succeeded)
            {
                throw new DomainException(
                    HttpStatusCode.Unauthorized,
                    new DomainExceptionError()
                    {
                        Code = Errors.InvalidCredentialsCode,
                        Description = Errors.InvalidCredentialsDescription
                    });
            }

            var user = _userService.FindByEmailAsync(command.Email).Result;
            var token = _userService.GenerateAppToken(user);

            command.CommandResult = new SignInOrSignUpCommandResult()
            {
                User = user,
                Token = token
            };
        }

        public void Handle(CreateUserCommand command)
        {
            var user = _mapper.Map<User>(command);
            if (String.IsNullOrEmpty(user.Id))
            {
                user.Id = Guid.NewGuid().ToString("N");
            }

            user.UserName = user.Email;

            var result = _userService.SignUpAsync(user, command.Password).Result;
            if (!result.Succeeded)
            {
                throw new DomainException(result.Errors
                    .Select(it => new DomainExceptionError()
                    {
                        Code = it.Code,
                        Description = it.Description
                    }));
            }
        }

        public void Handle(UpdateUserCommand command)
        {
            var user = _writeRepository.Get<User>(command.Id);
            Contract.Assert(user != null);

            if (!String.IsNullOrEmpty(command.Password))
            {
                var token = _userService.GeneratePasswordResetTokenAsync(user).Result;
                var result = _userService.ResetPasswordAsync(user, token, command.Password).Result;
                if (!result.Succeeded)
                {
                    throw new DomainException(result.Errors
                        .Select(it => new DomainExceptionError()
                        {
                            Code = it.Code,
                            Description = it.Description
                        }));
                }
            }

            var originalJson = user.ToJson();
            _mapper.Map(command, user);

            _writeRepository.Replace(user);
        }

        public void Handle(DeleteUserCommand command)
        {
            var user = _writeRepository.Get<User>(command.Id);
            Contract.Assert(user != null);

            _writeRepository.Delete(user);
        }

        public void Handle(CreateUserTokenCommand command)
        {
            var user = _writeRepository.Get<User>(command.UserId);
            Contract.Assert(user != null);

            if (user.AppTokens == null)
            {
                user.AppTokens = new List<UserAppToken>();
            }

            user.AppTokens.Add(new UserAppToken()
            {
                UserId = command.UserId,
                Token = command.Token,
                ExpiryDate = DateTime.UtcNow.AddDays(command.NumberOfExpirationDays)
            });

            _writeRepository.Replace(user);
        }
    }
}