using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LNK.Commands.Agencies;
using LNK.Domain.Agencies.Models;
using LNK.Queries.Agencies;

namespace LNK.QueryHandlers.Agencies
{
    public class AgenciesAutoMapperConfig : Profile
    {
        public AgenciesAutoMapperConfig()
        {
            CreateMap<Agency, AgencyOverview>();
            CreateMap<Agency, AgencyDetails>();

            CreateMap<AgencyDetails, UpdateAgencyCommand>();
        }
    }
}
