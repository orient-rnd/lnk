using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BomBiEn.Commands.Agencies;
using BomBiEn.Domain.Agencies.Models;
using BomBiEn.Queries.Agencies;

namespace BomBiEn.QueryHandlers.Agencies
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
