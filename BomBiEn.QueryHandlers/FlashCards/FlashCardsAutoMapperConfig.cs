using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BomBiEn.Queries.FlashCards;
using BomBiEn.Domain.FlashCards.Models;
using BomBiEn.Commands.FlashCards;

namespace BomBiEn.QueryHandlers.FlashCards
{
    public class FlashCardsAutoMapperConfig : Profile
    {
        public FlashCardsAutoMapperConfig()
        {
            CreateMap<FlashCard, FlashCardOverview>();
            CreateMap<FlashCard, FlashCardDetails>();
            CreateMap<FlashCardDetails, UpdateFlashCardCommand>();

            // Email template categories
            CreateMap<FlashCardCategory, FlashCardCategoryOverview>();
            CreateMap<FlashCardCategory, FlashCardCategoryDetails>();
            CreateMap<FlashCardCategoryDetails, UpdateFlashCardCategoryCommand>();
        }
    }
}