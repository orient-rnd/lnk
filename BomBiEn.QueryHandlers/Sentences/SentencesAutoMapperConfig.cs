using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BomBiEn.Queries.Sentences;
using BomBiEn.Domain.Sentences.Models;
using BomBiEn.Commands.Sentences;

namespace BomBiEn.QueryHandlers.Sentences
{
    public class SentencesAutoMapperConfig : Profile
    {
        public SentencesAutoMapperConfig()
        {
            CreateMap<Sentence, SentenceOverview>();
            CreateMap<Sentence, SentenceBasic>();
            CreateMap<Sentence, SentenceDetails>();
            CreateMap<SentenceDetails, UpdateSentenceCommand>();
            CreateMap<Dictionary, DictionaryQuery>();
        }
    }
}