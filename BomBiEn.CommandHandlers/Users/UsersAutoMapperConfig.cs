using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BomBiEn.Commands.Users;
using BomBiEn.Domain.Users.Models;

namespace BomBiEn.CommandHandlers.Users
{
    public class UsersAutoMapperConfig : Profile
    {
        public UsersAutoMapperConfig()
        {
            // Users
            CreateMap<CreateUserCommand, User>();
            CreateMap<SignUpCommand, User>();
            CreateMap<UpdateUserCommand, User>();
            CreateMap<User, UpdateUserCommand>();

            // Roles
            CreateMap<CreateRoleCommand, Role>();
            CreateMap<UpdateRoleCommand, Role>();
        }
    }
}