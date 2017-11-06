using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BomBiEn.Domain.FlashCards.Models;
using BomBiEn.Commands.FlashCards;

namespace BomBiEn.CommandHandlers.FlashCards
{
    public class FlashCardsAutoMapperConfig : Profile
    {
        public FlashCardsAutoMapperConfig()
        {
            CreateMap<CreateFlashCardCommand, FlashCard>();
            CreateMap<CreateFlashCardCategoryCommand, FlashCardCategory>();
        }
    }
}