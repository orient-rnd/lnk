using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BomBiEn.Commands.Users;
using BomBiEn.Domain.Users.Models;
using BomBiEn.Queries.Users;

namespace BomBiEn.QueryHandlers.Users
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