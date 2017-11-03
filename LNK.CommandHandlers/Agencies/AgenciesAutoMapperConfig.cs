using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LNK.Commands.Agencies;
using LNK.Domain.Agencies.Models;

namespace LNK.CommandHandlers.Agencies
{
    public class AgenciesAutoMapperConfig : Profile
    {
        public AgenciesAutoMapperConfig()
        {
            CreateMap<CreateAgencyCommand, Agency>();
            CreateMap<UpdateAgencyCommand, Agency>();
        }
    }
}