using System;
using System.Collections.Generic;
using AutoMapper;
using LNK.Infrastructure.Queries;
using LNK.Commands.Users;
using LNK.Queries.Users;

namespace LNK.AppServices.Lnk.Models.Account
{
    public class AccountsAutoMapperConfig : Profile
    {
        private readonly IQueryBus _queryBus;

        public AccountsAutoMapperConfig(IQueryBus queryBus)
        {
            _queryBus = queryBus;

            CreateMap<SignUpRequestModel, SignUpCommand>();
            CreateMap<SignInRequestModel, SignInCommand>();
            CreateMap<SignInCommand, SignInRequestModel>();

            CreateMap<UserDetails, UserResponseModel>()
                .ForMember(dest => dest.DateOfBirth, opts => opts.ResolveUsing(src => src.DateOfBirth?.ToString("yyyy-MM-dd")));
        }
    }
}