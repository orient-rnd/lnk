﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LNK.Queries.FlashCards;
using LNK.Domain.FlashCards.Models;
using LNK.Commands.FlashCards;

namespace LNK.QueryHandlers.FlashCards
{
    public class FlashCardsAutoMapperConfig : Profile
    {
        public FlashCardsAutoMapperConfig()
        {      
            // Email template categories
            CreateMap<FlashCardCategory, FlashCardCategoryDetails>();
            CreateMap<FlashCardCategoryDetails, UpdateFlashCardCategoryCommand>();
        }
    }
}