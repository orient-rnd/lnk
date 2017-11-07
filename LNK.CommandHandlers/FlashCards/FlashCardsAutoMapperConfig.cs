using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LNK.Commands.FlashCards;
using LNK.Domain.FlashCards.Models;

namespace LNK.CommandHandlers.FlashCards
{
    public class FlashCardsAutoMapperConfig : Profile
    {
        public FlashCardsAutoMapperConfig()
        {

            //FlashCard
            CreateMap<CreateFlashCardCommand, FlashCard>();
            CreateMap<UpdateFlashCardCommand, FlashCard>();

            //FlashCategory
            CreateMap<CreateFlashCardCategoryCommand, FlashCardCategory>();
            CreateMap<UpdateFlashCardCategoryCommand, FlashCardCategory>();

        }
    }
}