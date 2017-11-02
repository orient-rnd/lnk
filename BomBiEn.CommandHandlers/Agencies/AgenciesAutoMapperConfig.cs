using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BomBiEn.Commands.Agencies;
using BomBiEn.Domain.Agencies.Models;

namespace BomBiEn.CommandHandlers.Agencies
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