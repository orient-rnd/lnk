using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LNK.Commands.Users;
using LNK.Domain.Users.Models;

namespace LNK.CommandHandlers.Users
{
    public class UsersAutoMapperConfig : Profile
    {
        public UsersAutoMapperConfig()
        {
            // Users
            CreateMap<CreateUserCommand, User>();
            CreateMap<SignUpCommand, User>();
            CreateMap<UpdateUserCommand, User>();

            // Roles
            CreateMap<CreateRoleCommand, Role>();
            CreateMap<UpdateRoleCommand, Role>();
        }
    }
}