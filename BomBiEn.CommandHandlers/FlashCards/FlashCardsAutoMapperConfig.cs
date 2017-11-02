using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BomBiEn.Commands.FlashCards;
using BomBiEn.Domain.FlashCards.Models;

namespace BomBiEn.CommandHandlers.FlashCards
{
    public class FlashCardsAutoMapperConfig : Profile
    {
        public FlashCardsAutoMapperConfig()
        {
            CreateMap<CreateFlashCardCommand, FlashCard>();
            CreateMap<UpdateFlashCardCommand, FlashCard>();

            CreateMap<CreateFlashCardCategoryCommand, FlashCardCategory>();
            CreateMap<UpdateFlashCardCategoryCommand, FlashCardCategory>();
        }
    }
}