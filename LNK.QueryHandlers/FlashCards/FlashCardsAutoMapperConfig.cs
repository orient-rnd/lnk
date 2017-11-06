using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LNK.Queries.FlashCards;
using LNK.Domain.FlashCards.Models;
using LNK.Commands.FlashCards;
using LNK.Queries.Categories;

namespace LNK.QueryHandlers.FlashCards
{
    public class FlashCardsAutoMapperConfig : Profile
    {
        public FlashCardsAutoMapperConfig()
        {
            CreateMap<FlashCard, FlashCardOverview>();

            // Email template categories
            CreateMap<FlashCardCategory, FlashCardCategoryOverview>();
            CreateMap<FlashCardCategory, FlashCardCategoryDetails>();
            CreateMap<FlashCardCategoryDetails, UpdateFlashCardCategoryCommand>();
            CreateMap<FlashCardCategory, FlashCardCategoryInfoOverview>();
        }
    }
}