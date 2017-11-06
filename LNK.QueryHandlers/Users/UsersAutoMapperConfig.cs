using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LNK.Commands.Users;
using LNK.Domain.Users.Models;
using LNK.Queries.Users;

namespace LNK.QueryHandlers.Users
{
    public class UsersAutoMapperConfig : Profile
    {
        public UsersAutoMapperConfig()
        {
            // Users
            CreateMap<User, UserOverview>();
            CreateMap<User, UserEmailOverview>();
            CreateMap<User, UserDetails>();
            CreateMap<UserAppToken, UserDetailsAppToken>();

            CreateMap<UserDetails, UpdateUserCommand>();

            // Roles
            CreateMap<Role, RoleOverview>();
            CreateMap<Role, RoleDetails>();

            CreateMap<RoleDetails, UpdateRoleCommand>();
        }
    }
}