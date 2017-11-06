using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BomBiEn.Domain.FlashCards.Models;
using BomBiEn.Queries.FlashCards;

namespace BomBiEn.QueryHandlers.FlashCards
{
    public class FlashCardsAutoMapperConfig : Profile
    {
        public FlashCardsAutoMapperConfig()
        {
            CreateMap<FlashCardCategory, FlashCardCategoryOverview>();
        }
    }
}